namespace Chat_APP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.LtxtLocalIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemoteIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.ListMessages = new System.Windows.Forms.ListBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.bEchoMode = new System.Windows.Forms.Button();
            this.bSelfTest = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.bClear = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.label6 = new System.Windows.Forms.Label();
            this.bReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(82, 334);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(24, 22);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // LtxtLocalIP
            // 
            this.LtxtLocalIP.AutoSize = true;
            this.LtxtLocalIP.Location = new System.Drawing.Point(35, 11);
            this.LtxtLocalIP.Name = "LtxtLocalIP";
            this.LtxtLocalIP.Size = new System.Drawing.Size(35, 13);
            this.LtxtLocalIP.TabIndex = 4;
            this.LtxtLocalIP.Text = "label5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // txtRemoteIP
            // 
            this.txtRemoteIP.Location = new System.Drawing.Point(230, 8);
            this.txtRemoteIP.Name = "txtRemoteIP";
            this.txtRemoteIP.Size = new System.Drawing.Size(91, 20);
            this.txtRemoteIP.TabIndex = 4;
            this.txtRemoteIP.TextChanged += new System.EventHandler(this.txtRemoteIP_TextChanged);
            this.txtRemoteIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemoteIP_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "IP:";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(327, 8);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(70, 20);
            this.BtnConnect.TabIndex = 1;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // ListMessages
            // 
            this.ListMessages.BackColor = System.Drawing.SystemColors.Menu;
            this.ListMessages.FormattingEnabled = true;
            this.ListMessages.Location = new System.Drawing.Point(2, 196);
            this.ListMessages.Name = "ListMessages";
            this.ListMessages.Size = new System.Drawing.Size(401, 134);
            this.ListMessages.TabIndex = 2;
            this.ListMessages.SelectedIndexChanged += new System.EventHandler(this.ListMessages_SelectedIndexChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(2, 65);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(401, 126);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            // 
            // bEchoMode
            // 
            this.bEchoMode.BackColor = System.Drawing.Color.Red;
            this.bEchoMode.Location = new System.Drawing.Point(266, 39);
            this.bEchoMode.Name = "bEchoMode";
            this.bEchoMode.Size = new System.Drawing.Size(73, 23);
            this.bEchoMode.TabIndex = 5;
            this.bEchoMode.Text = "EchoMode";
            this.bEchoMode.UseVisualStyleBackColor = false;
            this.bEchoMode.Click += new System.EventHandler(this.bEchoMode_Click);
            // 
            // bSelfTest
            // 
            this.bSelfTest.BackColor = System.Drawing.Color.Red;
            this.bSelfTest.Location = new System.Drawing.Point(338, 39);
            this.bSelfTest.Name = "bSelfTest";
            this.bSelfTest.Size = new System.Drawing.Size(65, 23);
            this.bSelfTest.TabIndex = 6;
            this.bSelfTest.Text = "SelfTest";
            this.bSelfTest.UseVisualStyleBackColor = false;
            this.bSelfTest.Click += new System.EventHandler(this.bSelfTest_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(164, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(242, 15);
            this.label7.TabIndex = 107;
            this.label7.Text = "Apithep I. (Code) - HEIG-VD - 22 Mars 2016";
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(249, 333);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 109;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(328, 333);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 23);
            this.bExit.TabIndex = 110;
            this.bExit.Text = "Exit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(406, 373);
            this.shapeContainer1.TabIndex = 112;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rectangleShape1.Location = new System.Drawing.Point(2, 2);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(400, 33);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 113;
            this.label6.Text = "Connect to";
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(1, 333);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 23);
            this.bReset.TabIndex = 114;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 115;
            this.label5.Text = "label5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(244, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 116;
            this.label8.Text = "   ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(122, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 117;
            this.label9.Text = "label9";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(38, 404);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Me";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 373);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemoteIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bSelfTest);
            this.Controls.Add(this.LtxtLocalIP);
            this.Controls.Add(this.bEchoMode);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.ListMessages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "Form1";
            this.Text = "C# CHAT APPLICATION";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemoteIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.ListBox ListMessages;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label LtxtLocalIP;
        private System.Windows.Forms.Button bEchoMode;
        private System.Windows.Forms.Button bSelfTest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bExit;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

