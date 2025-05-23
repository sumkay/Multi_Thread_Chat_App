﻿namespace Server
{
    partial class Server
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
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblOnline = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnServerStop = new System.Windows.Forms.Button();
            this.inputPrivate = new System.Windows.Forms.TextBox();
            this.Private = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Blue;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(346, 25);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 119);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Başlat";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Location = new System.Drawing.Point(99, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(241, 254);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(81, 303);
            this.listBox1.TabIndex = 3;
            // 
            // lblOnline
            // 
            this.lblOnline.AutoSize = true;
            this.lblOnline.ForeColor = System.Drawing.Color.White;
            this.lblOnline.Location = new System.Drawing.Point(12, 9);
            this.lblOnline.Name = "lblOnline";
            this.lblOnline.Size = new System.Drawing.Size(81, 13);
            this.lblOnline.TabIndex = 4;
            this.lblOnline.Text = "Aktif Kullanıcılar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(96, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mesaj Geçmişi";
            // 
            // btnServerStop
            // 
            this.btnServerStop.BackColor = System.Drawing.Color.Red;
            this.btnServerStop.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnServerStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServerStop.ForeColor = System.Drawing.Color.White;
            this.btnServerStop.Location = new System.Drawing.Point(346, 150);
            this.btnServerStop.Name = "btnServerStop";
            this.btnServerStop.Size = new System.Drawing.Size(102, 129);
            this.btnServerStop.TabIndex = 7;
            this.btnServerStop.Text = "Durdur";
            this.btnServerStop.UseVisualStyleBackColor = false;
            this.btnServerStop.Click += new System.EventHandler(this.btnServerStop_Click);
            // 
            // inputPrivate
            // 
            this.inputPrivate.Location = new System.Drawing.Point(99, 285);
            this.inputPrivate.Multiline = true;
            this.inputPrivate.Name = "inputPrivate";
            this.inputPrivate.Size = new System.Drawing.Size(146, 38);
            this.inputPrivate.TabIndex = 8;
            // 
            // Private
            // 
            this.Private.BackColor = System.Drawing.Color.Crimson;
            this.Private.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Private.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Private.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Private.ForeColor = System.Drawing.Color.White;
            this.Private.Location = new System.Drawing.Point(251, 285);
            this.Private.Name = "Private";
            this.Private.Size = new System.Drawing.Size(89, 38);
            this.Private.TabIndex = 9;
            this.Private.Text = "Özel Mesaj Gönder";
            this.Private.UseVisualStyleBackColor = false;
            this.Private.Click += new System.EventHandler(this.Private_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(485, 428);
            this.Controls.Add(this.Private);
            this.Controls.Add(this.inputPrivate);
            this.Controls.Add(this.btnServerStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOnline);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnStart);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(501, 467);
            this.Name = "Server";
            this.Text = "Sunucu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblOnline;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnServerStop;
        private System.Windows.Forms.TextBox inputPrivate;
        private System.Windows.Forms.Button Private;
    }
}

