namespace Piaget_CSharp
{
    partial class FChat
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
            this.bReset = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bSelfTest = new System.Windows.Forms.Button();
            this.bEchoMode = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.ListMessages = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemoteIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.LtxtLocalIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(11, 339);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 23);
            this.bReset.TabIndex = 123;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(333, 339);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 23);
            this.bExit.TabIndex = 122;
            this.bExit.Text = "Exit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(252, 339);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 121;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bSelfTest
            // 
            this.bSelfTest.BackColor = System.Drawing.Color.Red;
            this.bSelfTest.Location = new System.Drawing.Point(81, 40);
            this.bSelfTest.Name = "bSelfTest";
            this.bSelfTest.Size = new System.Drawing.Size(65, 23);
            this.bSelfTest.TabIndex = 119;
            this.bSelfTest.Text = "SelfTest";
            this.bSelfTest.UseVisualStyleBackColor = false;
            this.bSelfTest.Click += new System.EventHandler(this.bSelfTest_Click);
            // 
            // bEchoMode
            // 
            this.bEchoMode.BackColor = System.Drawing.Color.Red;
            this.bEchoMode.Location = new System.Drawing.Point(9, 40);
            this.bEchoMode.Name = "bEchoMode";
            this.bEchoMode.Size = new System.Drawing.Size(73, 23);
            this.bEchoMode.TabIndex = 118;
            this.bEchoMode.Text = "EchoMode";
            this.bEchoMode.UseVisualStyleBackColor = false;
            this.bEchoMode.Click += new System.EventHandler(this.bEchoMode_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(7, 68);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(401, 126);
            this.txtMessage.TabIndex = 117;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            // 
            // ListMessages
            // 
            this.ListMessages.BackColor = System.Drawing.SystemColors.Menu;
            this.ListMessages.FormattingEnabled = true;
            this.ListMessages.Location = new System.Drawing.Point(7, 199);
            this.ListMessages.Name = "ListMessages";
            this.ListMessages.Size = new System.Drawing.Size(401, 134);
            this.ListMessages.TabIndex = 116;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(94, 340);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(24, 22);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 129;
            this.label6.Text = "Connect to";
            // 
            // txtRemoteIP
            // 
            this.txtRemoteIP.Location = new System.Drawing.Point(209, 12);
            this.txtRemoteIP.Name = "txtRemoteIP";
            this.txtRemoteIP.Size = new System.Drawing.Size(91, 20);
            this.txtRemoteIP.TabIndex = 127;
            this.txtRemoteIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemoteIP_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 124;
            this.label3.Text = "IP:";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(306, 12);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(70, 20);
            this.BtnConnect.TabIndex = 126;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // LtxtLocalIP
            // 
            this.LtxtLocalIP.AutoSize = true;
            this.LtxtLocalIP.Location = new System.Drawing.Point(32, 15);
            this.LtxtLocalIP.Name = "LtxtLocalIP";
            this.LtxtLocalIP.Size = new System.Drawing.Size(35, 13);
            this.LtxtLocalIP.TabIndex = 128;
            this.LtxtLocalIP.Text = "label5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 125;
            this.label1.Text = "IP:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(417, 368);
            this.shapeContainer1.TabIndex = 130;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 9;
            this.lineShape1.X2 = 405;
            this.lineShape1.Y1 = 35;
            this.lineShape1.Y2 = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 131;
            this.label5.Text = "label5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(349, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 132;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(226, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 133;
            this.label9.Text = "label9";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(75, 432);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 42);
            this.groupBox1.TabIndex = 115;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Me";
            // 
            // FChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 368);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemoteIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.LtxtLocalIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSelfTest);
            this.Controls.Add(this.bEchoMode);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.ListMessages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "FChat";
            this.Text = "Chat Application";
            this.Load += new System.EventHandler(this.FChat_Load);
            this.ResizeEnd += new System.EventHandler(this.FChat_resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bSelfTest;
        private System.Windows.Forms.Button bEchoMode;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox ListMessages;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemoteIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Label LtxtLocalIP;
        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}