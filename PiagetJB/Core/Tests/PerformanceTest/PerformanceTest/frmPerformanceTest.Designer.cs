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
            this.label1 = new System.Windows.Forms.Label();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbWithYields = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(195, 262);
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
            this.tbMeasures.Size = new System.Drawing.Size(258, 193);
            this.tbMeasures.TabIndex = 21;
            this.tbMeasures.TabStop = false;
            this.tbMeasures.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Task interruption style :";
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.Location = new System.Drawing.Point(12, 245);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(58, 17);
            this.rbNormal.TabIndex = 24;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // rbWithYields
            // 
            this.rbWithYields.AutoSize = true;
            this.rbWithYields.Location = new System.Drawing.Point(12, 268);
            this.rbWithYields.Name = "rbWithYields";
            this.rbWithYields.Size = new System.Drawing.Size(76, 17);
            this.rbWithYields.TabIndex = 25;
            this.rbWithYields.Text = "With yields";
            this.rbWithYields.UseVisualStyleBackColor = true;
            // 
            // frmPerformanceTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 302);
            this.Controls.Add(this.rbWithYields);
            this.Controls.Add(this.rbNormal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMeasures);
            this.Controls.Add(this.btnGo);
            this.Name = "frmPerformanceTest";
            this.Text = "Performance test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPerformanceTest_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox tbMeasures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbWithYields;
    }
}

