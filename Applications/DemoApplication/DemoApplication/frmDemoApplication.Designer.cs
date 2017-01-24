namespace DemoApplication {
    partial class frmDemoApplication {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnGo = new System.Windows.Forms.Button();
            this.tbMessages = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(12, 454);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tbMessages
            // 
            this.tbMessages.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMessages.Location = new System.Drawing.Point(12, 12);
            this.tbMessages.Multiline = true;
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.ReadOnly = true;
            this.tbMessages.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMessages.Size = new System.Drawing.Size(258, 424);
            this.tbMessages.TabIndex = 23;
            this.tbMessages.TabStop = false;
            this.tbMessages.WordWrap = false;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(195, 454);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 24;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmDemoApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 489);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.tbMessages);
            this.Controls.Add(this.btnGo);
            this.Name = "frmDemoApplication";
            this.Text = "Demo application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDemoApplication_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox tbMessages;
        private System.Windows.Forms.Button btnStop;
    }
}

