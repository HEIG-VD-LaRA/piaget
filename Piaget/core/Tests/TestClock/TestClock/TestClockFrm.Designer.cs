namespace TestClock {
    partial class TestClockFrm {
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
            this.lblMesuredTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRealTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAbsError = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(78, 144);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblMesuredTime
            // 
            this.lblMesuredTime.AutoSize = true;
            this.lblMesuredTime.Location = new System.Drawing.Point(109, 31);
            this.lblMesuredTime.Name = "lblMesuredTime";
            this.lblMesuredTime.Size = new System.Drawing.Size(81, 13);
            this.lblMesuredTime.TabIndex = 1;
            this.lblMesuredTime.Text = "lblMesuredTime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time elapsed in [ms] :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mesured :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Real :";
            // 
            // lblRealTime
            // 
            this.lblRealTime.AutoSize = true;
            this.lblRealTime.Location = new System.Drawing.Point(109, 54);
            this.lblRealTime.Name = "lblRealTime";
            this.lblRealTime.Size = new System.Drawing.Size(62, 13);
            this.lblRealTime.TabIndex = 4;
            this.lblRealTime.Text = "lblRealTime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Abs error :";
            // 
            // lblAbsError
            // 
            this.lblAbsError.AutoSize = true;
            this.lblAbsError.Location = new System.Drawing.Point(109, 76);
            this.lblAbsError.Name = "lblAbsError";
            this.lblAbsError.Size = new System.Drawing.Size(57, 13);
            this.lblAbsError.TabIndex = 6;
            this.lblAbsError.Text = "lblAbsError";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rel error :";
            // 
            // lblRelError
            // 
            this.lblRelError.AutoSize = true;
            this.lblRelError.Location = new System.Drawing.Point(109, 99);
            this.lblRelError.Name = "lblRelError";
            this.lblRelError.Size = new System.Drawing.Size(55, 13);
            this.lblRelError.TabIndex = 8;
            this.lblRelError.Text = "lblRelError";
            // 
            // TestClockFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRelError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAbsError);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRealTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMesuredTime);
            this.Controls.Add(this.btnGo);
            this.Name = "TestClockFrm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblMesuredTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRealTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAbsError;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRelError;
    }
}

