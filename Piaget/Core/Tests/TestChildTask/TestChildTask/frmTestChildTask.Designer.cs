namespace TestChildTask {
    partial class frmTestChildTask {
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
            this.label1 = new System.Windows.Forms.Label();
            this.nbMaxLevel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nbMaxLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(195, 223);
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
            this.tbMessages.Size = new System.Drawing.Size(258, 193);
            this.tbMessages.TabIndex = 22;
            this.tbMessages.TabStop = false;
            this.tbMessages.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Max level of tasks :";
            // 
            // nbMaxLevel
            // 
            this.nbMaxLevel.Location = new System.Drawing.Point(113, 225);
            this.nbMaxLevel.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nbMaxLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbMaxLevel.Name = "nbMaxLevel";
            this.nbMaxLevel.Size = new System.Drawing.Size(42, 20);
            this.nbMaxLevel.TabIndex = 24;
            this.nbMaxLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmTestChildTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 322);
            this.Controls.Add(this.nbMaxLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMessages);
            this.Controls.Add(this.btnGo);
            this.Name = "frmTestChildTask";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nbMaxLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox tbMessages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nbMaxLevel;
    }
}

