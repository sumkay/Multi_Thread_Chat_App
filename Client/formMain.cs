using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class formMain : Form
    {
        public TcpClient clientSocket;
        public NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        Thread ctThread;
        String name = null;        
        List<string> chat = new List<string>();

        public void setName(String title)
        {
            this.Text = title;
            name = title;
        }

        public formMain()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!input.Text.Equals(""))
                {
                    chat.Add("gChat");
                    chat.Add(input.Text);
                    byte[] outStream = ObjectToByteArray(chat);

                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    input.Text = "";
                    chat.Clear();
                }
            }
            catch (Exception er)
            {
                btnConnect.Enabled = true;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            clientSocket = new TcpClient();
            try
            {
                clientSocket.Connect("127.0.0.1", 5000);
                readData = "Sunucuya Bağlanıldı...";
                msg();

                serverStream = clientSocket.GetStream();

                byte[] outStream = Encoding.ASCII.GetBytes(name + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                btnConnect.Enabled = false;

                ctThread = new Thread(getMessage);
                ctThread.Start();
            }
            catch (Exception er)
            {
                MessageBox.Show("Sunucu Başlatılmadı.");
            }
        }

        public void getUsers(List<string> parts)
        {
            this.Invoke((MethodInvoker)delegate
            {
                cmbUsers.Items.Clear();
                for (int i = 1; i < parts.Count; i++)
                {
                    cmbUsers.Items.Add(parts[i]);
                }
            });
        }

        private void getMessage()
        {
            try
            {
                while (true)
                {
                    serverStream = clientSocket.GetStream();
                    byte[] inStream = new byte[10025];
                    int bytesRead = serverStream.Read(inStream, 0, inStream.Length);

                    if (!SocketConnected(clientSocket))
                    {
                        MessageBox.Show("Bağlantınız Kesildi");
                        ctThread.Abort();
                        clientSocket.Close();
                        btnConnect.Enabled = true;
                    }

                   
                    List<string> parts = (List<string>)ByteArrayToObject(inStream.Take(bytesRead).ToArray());

                    switch (parts[0])
                    {
                        case "userList":
                            getUsers(parts);
                            break;

                        case "gChat":
                            readData = "" + parts[1];
                            msg();
                            break;

                        case "pChat":
                            // parts[1]: gönderen, parts[2]: mesaj
                            readData = "[Özel Mesaj] " + parts[1] + ": " + parts[2];
                            msg();
                            break;
                    }

                    if (readData != null && readData.Length > 0 && readData[0].Equals('\0'))
                    {
                        readData = "Tekrar Bağlan";
                        msg();

                        this.Invoke((MethodInvoker)delegate
                        {
                            btnConnect.Enabled = true;
                        });

                        ctThread.Abort();
                        clientSocket.Close();
                        break;
                    }
                    chat.Clear();
                }
            }
            catch (Exception e)
            {
                try
                {
                    ctThread.Abort();
                }
                catch { }
                try
                {
                    clientSocket.Close();
                }
                catch { }
                btnConnect.Enabled = true;
                Console.WriteLine(e);
            }
        }

        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                history.Text = history.Text + Environment.NewLine + " >> " + readData;
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Çıkmak istiyor musunuz? ", "Çıkış Yap", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    ctThread.Abort();
                    clientSocket.Close();
                }
                catch (Exception ee) { }

                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public byte[] ObjectToByteArray(object _Object)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, _Object);
                return stream.ToArray();
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

        bool SocketConnected(TcpClient s)
        {
            bool flag = false;
            try
            {
                bool part1 = s.Client.Poll(10, SelectMode.SelectRead);
                bool part2 = (s.Available == 0);
                if (part1 && part2)
                {
                    indicator.BackColor = Color.Red;
                    this.Invoke((MethodInvoker)delegate
                    {
                        btnConnect.Enabled = true;
                    });
                    flag = false;
                }
                else
                {
                    indicator.BackColor = Color.Green;
                    flag = true;
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er);
            }
            return flag;
        }
        private void btnClr_Click(object sender, EventArgs e)
        {
            history.Clear();
        }

        private void history_TextChanged(object sender, EventArgs e)
        {
            history.SelectionStart = history.TextLength;
            history.ScrollToCaret();
        }

        private void btnPrivateSend_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
                return;
            }
            if (string.IsNullOrWhiteSpace(input.Text))
            {
                MessageBox.Show("Lütfen mesajınızı yazın.");
                return;
            }

            List<string> paket = new List<string>();
            paket.Add("pChat"); 
            paket.Add(cmbUsers.SelectedItem.ToString()); 
            paket.Add(input.Text);

            byte[] outStream = ObjectToByteArray(paket);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            
            history.AppendText(Environment.NewLine + " [Özel Mesaj] " + cmbUsers.SelectedItem.ToString() + " >> " + input.Text);

            input.Clear();
        }
    }
}
