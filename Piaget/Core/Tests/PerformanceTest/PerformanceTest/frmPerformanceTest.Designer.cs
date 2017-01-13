namespace PerformanceTest {
    partial class frmPerformanceTest {
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
            this.tbMeasures = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(12, 227);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tbMeasures
            // 
            this.tbMeasures.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbMeasures.Location = new System.Drawing.Point(12, 12);
            this.tbMeasures.Multiline = true;
            this.tbMeasures.Name = "tbMeasures";
            this.tbMeasures.ReadOnly = true;
            this.tbMeasures.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbMeasures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMeasures.Size = new System.Drawing.Size(203, 193);
            this.tbMeasures.TabIndex = 21;
            this.tbMeasures.TabStop = false;
            this.tbMeasures.WordWrap = false;
            // 
            // frmPerformanceTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbMeasures);
            this.Controls.Add(this.btnGo);
            this.Name = "frmPerformanceTest";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox tbMeasures;
    }
}

