namespace Client
{
    partial class formMain
    {
    
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

       
        private void InitializeComponent()
        {
            this.history = new System.Windows.Forms.TextBox();
            this.input = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnClr = new System.Windows.Forms.Button();
            this.indicator = new System.Windows.Forms.Panel();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.btnPrivateSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(12, 12);
            this.history.Multiline = true;
            this.history.Name = "history";
            this.history.ReadOnly = true;
            this.history.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.history.Size = new System.Drawing.Size(646, 150);
            this.history.TabIndex = 0;
            this.history.TextChanged += new System.EventHandler(this.history_TextChanged);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(12, 168);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(219, 20);
            this.input.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.Location = new System.Drawing.Point(12, 194);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Gönder";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(577, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Aktif Kullanıcılar";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(240, 168);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(79, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Bağlan";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnClr
            // 
            this.btnClr.Location = new System.Drawing.Point(325, 168);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(96, 23);
            this.btnClr.TabIndex = 7;
            this.btnClr.Text = "Sohbeti Temizle";
            this.btnClr.UseVisualStyleBackColor = true;
            this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // indicator
            // 
            this.indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicator.ForeColor = System.Drawing.Color.White;
            this.indicator.Location = new System.Drawing.Point(518, 175);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(10, 11);
            this.indicator.TabIndex = 6;
            // 
            // cmbUsers
            // 
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(580, 181);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(78, 21);
            this.cmbUsers.TabIndex = 9;
            // 
            // btnPrivateSend
            // 
            this.btnPrivateSend.Location = new System.Drawing.Point(93, 194);
            this.btnPrivateSend.Name = "btnPrivateSend";
            this.btnPrivateSend.Size = new System.Drawing.Size(138, 23);
            this.btnPrivateSend.TabIndex = 8;
            this.btnPrivateSend.Text = "Özel Mesaj Gönder";
            this.btnPrivateSend.UseVisualStyleBackColor = true;
            this.btnPrivateSend.Click += new System.EventHandler(this.btnPrivateSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(427, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Bağlantı Durumu";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(670, 228);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.btnPrivateSend);
            this.Controls.Add(this.btnClr);
            this.Controls.Add(this.indicator);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.input);
            this.Controls.Add(this.history);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formMain";
            this.Text = "Mesaj Uygulaması";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox history;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnClr;
        private System.Windows.Forms.Panel indicator;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Button btnPrivateSend;
        private System.Windows.Forms.Label label2;
    }
}

