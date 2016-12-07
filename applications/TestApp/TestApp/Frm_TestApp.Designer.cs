namespace TestApp {
    partial class Frm_TestApp {
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
            this.SuspendLayout();
            // 
            // Btn_Go
            // 
            this.Btn_Go.Location = new System.Drawing.Point(101, 126);
            this.Btn_Go.Name = "Btn_Go";
            this.Btn_Go.Size = new System.Drawing.Size(75, 23);
            this.Btn_Go.TabIndex = 0;
            this.Btn_Go.Text = "Go";
            this.Btn_Go.UseVisualStyleBackColor = true;
            this.Btn_Go.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // Frm_TestApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Btn_Go);
            this.Name = "Frm_TestApp";
            this.Text = "TestApp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Go;
    }
}