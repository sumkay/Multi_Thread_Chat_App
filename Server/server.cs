using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Server
{
    public partial class Server : Form
    {
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
        TcpClient client;
        Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>();
        CancellationTokenSource cancellation = new CancellationTokenSource();
        List<string> chat = new List<string>();

        public Server()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            cancellation = new CancellationTokenSource();
            startServer();
        }

        public void updateUI(String m)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBox1.AppendText(">>" + m + Environment.NewLine);
            });
        }

        public async void startServer()
        {
            listener.Start();
            updateUI("Server Başlatıldı.");
            updateUI("Server dinliyor: " + listener.LocalEndpoint);
            updateUI("Kullanıcılar bekleniyor...");
            try
            {
                int counter = 0;
                while (true)
                {
                    counter++;
                    client = await Task.Run(() => listener.AcceptTcpClientAsync(), cancellation.Token);

                    byte[] name = new byte[50];
                    NetworkStream stre = client.GetStream();
                    stre.Read(name, 0, name.Length);
                    String username = Encoding.ASCII.GetString(name);
                    username = username.Substring(0, username.IndexOf("$"));

                    clientList.Add(username, client);
                    listBox1.Items.Add(username);
                    updateUI("Kullanıcı bağlandı " + username + " - " + client.Client.RemoteEndPoint);
                    announce(username + " Katıldı ", username, false);

                    await Task.Delay(1000).ContinueWith(t => sendUsersList());

                    var c = new Thread(() => ServerReceive(client, username));
                    c.Start();
                }
            }
            catch (Exception)
            {
                listener.Stop();
            }
        }

        public void announce(string msg, string uName, bool flag)
        {
            try
            {
                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;

                    if (flag)
                    {
                        chat.Add("gChat");
                        chat.Add(uName + " adlı kullanıcının mesajı : " + msg);
                        broadcastBytes = ObjectToByteArray(chat);
                    }
                    else
                    {
                        chat.Add("gChat");
                        chat.Add(msg);
                        broadcastBytes = ObjectToByteArray(chat);
                    }

                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                    chat.Clear();
                }
            }
            catch (Exception)
            {
                
            }
        }

        public Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

        public byte[] ObjectToByteArray(Object obj)
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public void ServerReceive(TcpClient clientn, String username)
        {
            byte[] data = new byte[10025];
            while (true)
            {
                try
                {
                    NetworkStream stream = clientn.GetStream();
                    int bytesRead = stream.Read(data, 0, data.Length);
                    if (bytesRead == 0) break;

                   
                    var obj = ByteArrayToObject(data.Take(bytesRead).ToArray());
                    List<string> parts = obj as List<string>;
                    if (parts == null || parts.Count == 0)
                        continue;

                    switch (parts[0])
                    {
                        case "gChat":
                            this.Invoke((MethodInvoker)delegate
                            {
                                textBox1.Text += username + ": " + parts[1] + Environment.NewLine;
                            });
                            announce(parts[1], username, true);
                            SaveMessageToDb(username, parts[1]);
                            break;
                        
                        case "pChat":
                            // parts[1]: alıcı, parts[2]: mesaj
                            string alici = parts[1];
                            string mesaj = parts[2];

                            if (clientList.ContainsKey(alici))
                            {
                                
                                List<string> paket = new List<string>();
                                paket.Add("pChat");
                                paket.Add(username); // gönderen
                                paket.Add(mesaj);

                                byte[] privateMsg = ObjectToByteArray(paket);

                                TcpClient aliciClient = clientList[alici];
                                NetworkStream aliciStream = aliciClient.GetStream();
                                aliciStream.Write(privateMsg, 0, privateMsg.Length);
                                aliciStream.Flush();

                                
                                SavePrivateMessageToDb(username, alici, mesaj);
                            }
                            break;

                    }
                }
                catch (Exception)
                {
                    updateUI("Kullanıcı Ayrıldı: " + username);
                    announce("Kullanıcı Ayrıldı: " + username, username, false);
                    clientList.Remove(username);

                    this.Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Remove(username);
                    });
                    sendUsersList();
                    break;
                }
            }
        }

        private void btnServerStop_Click(object sender, EventArgs e)
        {
            try
            {
                listener.Stop();
                updateUI("Server Durduruldu");
                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket = (TcpClient)Item.Value;
                    broadcastSocket.Close();
                }
            }
            catch (SocketException)
            {
                
            }
        }

        public void sendUsersList()
        {
            try
            {
                string[] clist = listBox1.Items.OfType<string>().ToArray();
                List<string> users = new List<string>();

                users.Add("userList");
                foreach (String name in clist)
                {
                    users.Add(name);
                }
                byte[] userList = ObjectToByteArray(users);

                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    broadcastStream.Write(userList, 0, userList.Length);
                    broadcastStream.Flush();
                }
            }
            catch (SocketException)
            {
              
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }

       
        public void SaveMessageToDb(string username, string message)
        {
            string connectionString = "Server=HP\\SQLEXPRESS;Database=ChatApp;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ChatMessages (UserName, MessageText) VALUES (@UserName, @MessageText)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@MessageText", message);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        private void Private_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                String clientName = listBox1.GetItemText(listBox1.SelectedItem);

                chat.Clear();
                chat.Add("gChat");
                chat.Add("Admin : " + inputPrivate.Text);

                byte[] byData = ObjectToByteArray(chat);
                TcpClient workerSocket = clientList.FirstOrDefault(x => x.Key == clientName).Value;

                NetworkStream stm = workerSocket.GetStream();
                stm.Write(byData, 0, byData.Length);
                stm.Flush();
                chat.Clear();
            }
        }
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient workerSocket = null;
                String clientName = listBox1.GetItemText(listBox1.SelectedItem);
                workerSocket = clientList.FirstOrDefault(x => x.Key == clientName).Value;
                workerSocket.Close();
            }
            catch (SocketException)
            {
                
            }
        }
        public void SavePrivateMessageToDb(string sender, string receiver, string message)
        {
            string connectionString = "Server=HP\\SQLEXPRESS;Database=ChatApp;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO PrivateMessages (Sender, Receiver, MessageText, SentAt) 
                         VALUES (@Sender, @Receiver, @MessageText, @SentAt)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Sender", sender);
                cmd.Parameters.AddWithValue("@Receiver", receiver);
                cmd.Parameters.AddWithValue("@MessageText", message);
                cmd.Parameters.AddWithValue("@SentAt", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }


    }
}
