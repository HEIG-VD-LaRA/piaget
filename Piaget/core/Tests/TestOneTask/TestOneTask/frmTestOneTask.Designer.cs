namespace TestOneApp {
    partial class frmTestOneTask {
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
            this.Btn_Go = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAbsoluteError = new System.Windows.Forms.Label();
            this.lblRelativeError = new System.Windows.Forms.Label();
            this.lblAbsoluteDeltaError = new System.Windows.Forms.Label();
            this.lblRelativeDeltaError = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblElapsedTimeRef = new System.Windows.Forms.Label();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_Go
            // 
            this.Btn_Go.Location = new System.Drawing.Point(94, 186);
            this.Btn_Go.Name = "Btn_Go";
            this.Btn_Go.Size = new System.Drawing.Size(75, 23);
            this.Btn_Go.TabIndex = 0;
            this.Btn_Go.Text = "Go";
            this.Btn_Go.UseVisualStyleBackColor = true;
            this.Btn_Go.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Absolute error in [ms] :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Relative error in % :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Absolute delta error (m = 16) in [ms] :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Relative delta error (m = 16) in % :";
            // 
            // lblAbsoluteError
            // 
            this.lblAbsoluteError.AutoSize = true;
            this.lblAbsoluteError.Location = new System.Drawing.Point(140, 56);
            this.lblAbsoluteError.Name = "lblAbsoluteError";
            this.lblAbsoluteError.Size = new System.Drawing.Size(80, 13);
            this.lblAbsoluteError.TabIndex = 6;
            this.lblAbsoluteError.Text = "lblAbsoluteError";
            // 
            // lblRelativeError
            // 
            this.lblRelativeError.AutoSize = true;
            this.lblRelativeError.Location = new System.Drawing.Point(140, 78);
            this.lblRelativeError.Name = "lblRelativeError";
            this.lblRelativeError.Size = new System.Drawing.Size(78, 13);
            this.lblRelativeError.TabIndex = 7;
            this.lblRelativeError.Text = "lblRelativeError";
            // 
            // lblAbsoluteDeltaError
            // 
            this.lblAbsoluteDeltaError.AutoSize = true;
            this.lblAbsoluteDeltaError.Location = new System.Drawing.Point(207, 101);
            this.lblAbsoluteDeltaError.Name = "lblAbsoluteDeltaError";
            this.lblAbsoluteDeltaError.Size = new System.Drawing.Size(105, 13);
            this.lblAbsoluteDeltaError.TabIndex = 8;
            this.lblAbsoluteDeltaError.Text = "lblAbsoluteDeltaError";
            // 
            // lblRelativeDeltaError
            // 
            this.lblRelativeDeltaError.AutoSize = true;
            this.lblRelativeDeltaError.Location = new System.Drawing.Point(207, 124);
            this.lblRelativeDeltaError.Name = "lblRelativeDeltaError";
            this.lblRelativeDeltaError.Size = new System.Drawing.Size(103, 13);
            this.lblRelativeDeltaError.TabIndex = 9;
            this.lblRelativeDeltaError.Text = "lblRelativeDeltaError";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ref :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Measured :";
            // 
            // lblElapsedTimeRef
            // 
            this.lblElapsedTimeRef.AutoSize = true;
            this.lblElapsedTimeRef.Location = new System.Drawing.Point(67, 27);
            this.lblElapsedTimeRef.Name = "lblElapsedTimeRef";
            this.lblElapsedTimeRef.Size = new System.Drawing.Size(95, 13);
            this.lblElapsedTimeRef.TabIndex = 13;
            this.lblElapsedTimeRef.Text = "lblElapsedTimeRef";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(245, 27);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(78, 13);
            this.lblElapsedTime.TabIndex = 14;
            this.lblElapsedTime.Text = "lblElapsedTime";
            // 
            // frmTestOneTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 262);
            this.Controls.Add(this.lblElapsedTime);
            this.Controls.Add(this.lblElapsedTimeRef);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRelativeDeltaError);
            this.Controls.Add(this.lblAbsoluteDeltaError);
            this.Controls.Add(this.lblRelativeError);
            this.Controls.Add(this.lblAbsoluteError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Go);
            this.Name = "frmTestOneTask";
            this.Text = "TestApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Go;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAbsoluteError;
        private System.Windows.Forms.Label lblRelativeError;
        private System.Windows.Forms.Label lblAbsoluteDeltaError;
        private System.Windows.Forms.Label lblRelativeDeltaError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblElapsedTimeRef;
        private System.Windows.Forms.Label lblElapsedTime;
    }
}