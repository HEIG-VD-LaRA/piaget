namespace LaRA_manip27
{
    partial class FManip27Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gBDC = new System.Windows.Forms.GroupBox();
            this.bDCResetPos = new System.Windows.Forms.Button();
            this.bDCStop = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tBDCKI = new System.Windows.Forms.TextBox();
            this.tBDCKD = new System.Windows.Forms.TextBox();
            this.tBDCKP = new System.Windows.Forms.TextBox();
            this.lDCMotorState = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBUCommand = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tBDCDec = new System.Windows.Forms.TextBox();
            this.tBDCPosCon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBDCAcc = new System.Windows.Forms.TextBox();
            this.tBPosErr = new System.Windows.Forms.TextBox();
            this.cBDCMode = new System.Windows.Forms.ComboBox();
            this.tBSpeedAct = new System.Windows.Forms.TextBox();
            this.tBDCSpeed = new System.Windows.Forms.TextBox();
            this.tBDCPosAct = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bDCMove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bPAPResetPos = new System.Windows.Forms.Button();
            this.lPAPMotorState = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cBPAPMode = new System.Windows.Forms.ComboBox();
            this.bPAPStop = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.tBPAPPosTh = new System.Windows.Forms.TextBox();
            this.cBPAPStep = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.bPAPMove = new System.Windows.Forms.Button();
            this.tBPAPDec = new System.Windows.Forms.TextBox();
            this.tBPAPAcc = new System.Windows.Forms.TextBox();
            this.tBPAPSpeed = new System.Windows.Forms.TextBox();
            this.tBPAPPosCon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.bResetGalil = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gBDC.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gBDC
            // 
            this.gBDC.Controls.Add(this.bDCResetPos);
            this.gBDC.Controls.Add(this.bDCStop);
            this.gBDC.Controls.Add(this.label13);
            this.gBDC.Controls.Add(this.label12);
            this.gBDC.Controls.Add(this.label11);
            this.gBDC.Controls.Add(this.tBDCKI);
            this.gBDC.Controls.Add(this.tBDCKD);
            this.gBDC.Controls.Add(this.tBDCKP);
            this.gBDC.Controls.Add(this.lDCMotorState);
            this.gBDC.Controls.Add(this.label8);
            this.gBDC.Controls.Add(this.label3);
            this.gBDC.Controls.Add(this.tBUCommand);
            this.gBDC.Controls.Add(this.label10);
            this.gBDC.Controls.Add(this.tBDCDec);
            this.gBDC.Controls.Add(this.tBDCPosCon);
            this.gBDC.Controls.Add(this.label7);
            this.gBDC.Controls.Add(this.tBDCAcc);
            this.gBDC.Controls.Add(this.tBPosErr);
            this.gBDC.Controls.Add(this.cBDCMode);
            this.gBDC.Controls.Add(this.tBSpeedAct);
            this.gBDC.Controls.Add(this.tBDCSpeed);
            this.gBDC.Controls.Add(this.tBDCPosAct);
            this.gBDC.Controls.Add(this.label6);
            this.gBDC.Controls.Add(this.label9);
            this.gBDC.Controls.Add(this.label5);
            this.gBDC.Controls.Add(this.label4);
            this.gBDC.Controls.Add(this.bDCMove);
            this.gBDC.Controls.Add(this.label2);
            this.gBDC.Location = new System.Drawing.Point(12, 12);
            this.gBDC.Name = "gBDC";
            this.gBDC.Size = new System.Drawing.Size(485, 240);
            this.gBDC.TabIndex = 3;
            this.gBDC.TabStop = false;
            this.gBDC.Text = "moteur DC";
            // 
            // bDCResetPos
            // 
            this.bDCResetPos.Location = new System.Drawing.Point(369, 195);
            this.bDCResetPos.Name = "bDCResetPos";
            this.bDCResetPos.Size = new System.Drawing.Size(100, 23);
            this.bDCResetPos.TabIndex = 15;
            this.bDCResetPos.Tag = "DC";
            this.bDCResetPos.Text = "Pos = 0";
            this.bDCResetPos.UseVisualStyleBackColor = true;
            this.bDCResetPos.Click += new System.EventHandler(this.ResetPos);
            // 
            // bDCStop
            // 
            this.bDCStop.Location = new System.Drawing.Point(369, 166);
            this.bDCStop.Name = "bDCStop";
            this.bDCStop.Size = new System.Drawing.Size(100, 23);
            this.bDCStop.TabIndex = 14;
            this.bDCStop.Text = "Stop";
            this.bDCStop.UseVisualStyleBackColor = true;
            this.bDCStop.Click += new System.EventHandler(this.bDCStop_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 211);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "KI";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 185);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "KD";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "KP";
            // 
            // tBDCKI
            // 
            this.tBDCKI.Location = new System.Drawing.Point(98, 208);
            this.tBDCKI.Name = "tBDCKI";
            this.tBDCKI.Size = new System.Drawing.Size(100, 20);
            this.tBDCKI.TabIndex = 11;
            this.tBDCKI.Tag = "KI";
            this.tBDCKI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tBDCKI, "Gain action Intégrale\r\nRéel 0 - 2047.875");
            this.tBDCKI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.tBDCKI.Leave += new System.EventHandler(this.UpdateValue);
            // 
            // tBDCKD
            // 
            this.tBDCKD.Location = new System.Drawing.Point(98, 182);
            this.tBDCKD.Name = "tBDCKD";
            this.tBDCKD.Size = new System.Drawing.Size(100, 20);
            this.tBDCKD.TabIndex = 10;
            this.tBDCKD.Tag = "KD";
            this.tBDCKD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tBDCKD, "Gain action Dérivée\r\nRéel 0 - 4095.875");
            this.tBDCKD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.tBDCKD.Leave += new System.EventHandler(this.UpdateValue);
            // 
            // tBDCKP
            // 
            this.tBDCKP.Location = new System.Drawing.Point(98, 156);
            this.tBDCKP.Name = "tBDCKP";
            this.tBDCKP.Size = new System.Drawing.Size(100, 20);
            this.tBDCKP.TabIndex = 9;
            this.tBDCKP.Tag = "KP";
            this.tBDCKP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tBDCKP, "Gain action Proportionnel\r\nRéel 0 à 1023.875");
            this.tBDCKP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.tBDCKP.Leave += new System.EventHandler(this.UpdateValue);
            // 
            // lDCMotorState
            // 
            this.lDCMotorState.BackColor = System.Drawing.SystemColors.Control;
            this.lDCMotorState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lDCMotorState.Location = new System.Drawing.Point(433, 94);
            this.lDCMotorState.Name = "lDCMotorState";
            this.lDCMotorState.Size = new System.Drawing.Size(36, 21);
            this.lDCMotorState.TabIndex = 26;
            this.lDCMotorState.Text = "OFF";
            this.lDCMotorState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Mesures";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Consignes";
            // 
            // tBUCommand
            // 
            this.tBUCommand.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBUCommand.Location = new System.Drawing.Point(369, 59);
            this.tBUCommand.Name = "tBUCommand";
            this.tBUCommand.ReadOnly = true;
            this.tBUCommand.Size = new System.Drawing.Size(100, 19);
            this.tBUCommand.TabIndex = 22;
            this.tBUCommand.TabStop = false;
            this.tBUCommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(318, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Tension";
            // 
            // tBDCDec
            // 
            this.tBDCDec.Location = new System.Drawing.Point(98, 120);
            this.tBDCDec.Name = "tBDCDec";
            this.tBDCDec.Size = new System.Drawing.Size(100, 20);
            this.tBDCDec.TabIndex = 8;
            this.tBDCDec.Tag = "DC";
            this.tBDCDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tBDCDec, "Consigne de décélération\r\n[Impulsions de l\'encodeur / s^2]\r\nThe parameters input " +
        "will be rounded down to the nearest factor of 1024");
            this.tBDCDec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.tBDCDec.Leave += new System.EventHandler(this.UpdateValue);
            // 
            // tBDCPosCon
            // 
            this.tBDCPosCon.Location = new System.Drawing.Point(98, 32);
            this.tBDCPosCon.Name = "tBDCPosCon";
            this.tBDCPosCon.Size = new System.Drawing.Size(100, 20);
            this.tBDCPosCon.TabIndex = 5;
            this.tBDCPosCon.Tag = "PR";
            this.tBDCPosCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tBDCPosCon, "Consigne de position \r\n[impulsions de l\'encodeur]");
            this.tBDCPosCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.tBDCPosCon.Leave += new System.EventHandler(this.UpdateValue);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Erreur";
            // 
            // tBDCAcc
            // 
            this.tBDCAcc.Location = new System.Drawing.Point(98, 94);
            this.tBDCAcc.Name = "tBDCAcc";
            this.tBDCAcc.Size = new System.Drawing.Size(100, 20);
            this.tBDCAcc.TabIndex = 7;
            this.tBDCAcc.Tag = "AC";
            this.tBDCAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tBDCAcc, "Consigne d\'accélération\r\n[Impulsions de l\'encodeur / s^2]\r\nThe parameters input w" +
        "ill be rounded down to the nearest factor of 1024");
            this.tBDCAcc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.tBDCAcc.Leave += new System.EventHandler(this.UpdateValue);
            // 
            // tBPosErr
            // 
            this.tBPosErr.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBPosErr.Location = new System.Drawing.Point(369, 32);
            this.tBPosErr.Name = "tBPosErr";
            this.tBPosErr.ReadOnly = true;
            this.tBPosErr.Size = new System.Drawing.Size(100, 19);
            this.tBPosErr.TabIndex = 19;
            this.tBPosErr.TabStop = false;
            this.tBPosErr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cBDCMode
            // 
            this.cBDCMode.BackColor = System.Drawing.SystemColors.Window;
            this.cBDCMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBDCMode.FormattingEnabled = true;
            this.cBDCMode.Items.AddRange(new object[] {
            "Désactivé",
            "Position Absolue",
            "Position Relative",
            "Position Relative Alternée",
            "Vitesse"});
            this.cBDCMode.Location = new System.Drawing.Point(277, 94);
            this.cBDCMode.Name = "cBDCMode";
            this.cBDCMode.Size = new System.Drawing.Size(150, 21);
            this.cBDCMode.TabIndex = 12;
            this.cBDCMode.SelectionChangeCommitted += new System.EventHandler(this.cBDCMode_SelectionChangeCommitted);
            // 
            // tBSpeedAct
            // 
            this.tBSpeedAct.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBSpeedAct.Location = new System.Drawing.Point(204, 59);
            this.tBSpeedAct.Name = "tBSpeedAct";
            this.tBSpeedAct.ReadOnly = true;
            this.tBSpeedAct.Size = new System.Drawing.Size(100, 19);
            this.tBSpeedAct.TabIndex = 18;
            this.tBSpeedAct.TabStop = false;
            this.tBSpeedAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tBDCSpeed
            // 
            this.tBDCSpeed.Location = new System.Drawing.Point(98, 58);
            this.tBDCSpeed.Name = "tBDCSpeed";
            this.tBDCSpeed.Size = new System.Drawing.Size(100, 20);
            this.tBDCSpeed.TabIndex = 6;
            this.tBDCSpeed.Tag = "SP";
            this.tBDCSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tBDCSpeed, "Consigne de vitesse\r\n[Impulsions de l\'encodeur / s]");
            this.tBDCSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.tBDCSpeed.Leave += new System.EventHandler(this.UpdateValue);
            // 
            // tBDCPosAct
            // 
            this.tBDCPosAct.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBDCPosAct.Location = new System.Drawing.Point(204, 32);
            this.tBDCPosAct.Name = "tBDCPosAct";
            this.tBDCPosAct.ReadOnly = true;
            this.tBDCPosAct.Size = new System.Drawing.Size(100, 19);
            this.tBDCPosAct.TabIndex = 17;
            this.tBDCPosAct.TabStop = false;
            this.tBDCPosAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Décélération";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(237, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Mode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Accélération";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Vitesse";
            // 
            // bDCMove
            // 
            this.bDCMove.Location = new System.Drawing.Point(369, 136);
            this.bDCMove.Name = "bDCMove";
            this.bDCMove.Size = new System.Drawing.Size(100, 23);
            this.bDCMove.TabIndex = 13;
            this.bDCMove.Text = "Déplacement";
            this.bDCMove.UseVisualStyleBackColor = true;
            this.bDCMove.Click += new System.EventHandler(this.bDCMove_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 35);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Position";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bPAPResetPos);
            this.groupBox1.Controls.Add(this.lPAPMotorState);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.cBPAPMode);
            this.groupBox1.Controls.Add(this.bPAPStop);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.tBPAPPosTh);
            this.groupBox1.Controls.Add(this.cBPAPStep);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.bPAPMove);
            this.groupBox1.Controls.Add(this.tBPAPDec);
            this.groupBox1.Controls.Add(this.tBPAPAcc);
            this.groupBox1.Controls.Add(this.tBPAPSpeed);
            this.groupBox1.Controls.Add(this.tBPAPPosCon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Location = new System.Drawing.Point(12, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 214);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "moteur PAP";
            // 
            // bPAPResetPos
            // 
            this.bPAPResetPos.Location = new System.Drawing.Point(369, 177);
            this.bPAPResetPos.Name = "bPAPResetPos";
            this.bPAPResetPos.Size = new System.Drawing.Size(100, 23);
            this.bPAPResetPos.TabIndex = 28;
            this.bPAPResetPos.Tag = "PAP";
            this.bPAPResetPos.Text = "Pos = 0";
            this.bPAPResetPos.UseVisualStyleBackColor = true;
            this.bPAPResetPos.Click += new System.EventHandler(this.ResetPos);
            // 
            // lPAPMotorState
            // 
            this.lPAPMotorState.BackColor = System.Drawing.SystemColors.Control;
            this.lPAPMotorState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lPAPMotorState.Location = new System.Drawing.Point(433, 76);
            this.lPAPMotorState.Name = "lPAPMotorState";
            this.lPAPMotorState.Size = new System.Drawing.Size(36, 21);
            this.lPAPMotorState.TabIndex = 37;
            this.lPAPMotorState.Text = "OFF";
            this.lPAPMotorState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(237, 79);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 13);
            this.label19.TabIndex = 36;
            this.label19.Text = "Mode";
            // 
            // cBPAPMode
            // 
            this.cBPAPMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBPAPMode.FormattingEnabled = true;
            this.cBPAPMode.Items.AddRange(new object[] {
            "Désactivé",
            "Position Absolue",
            "Position Relative",
            "Position Relative Alternée",
            "Vitesse"});
            this.cBPAPMode.Location = new System.Drawing.Point(277, 76);
            this.cBPAPMode.Name = "cBPAPMode";
            this.cBPAPMode.Size = new System.Drawing.Size(150, 21);
            this.cBPAPMode.TabIndex = 25;
            this.cBPAPMode.SelectionChangeCommitted += new System.EventHandler(this.cBPAPMode_SelectionChangeCommitted);
            // 
            // bPAPStop
            // 
            this.bPAPStop.Location = new System.Drawing.Point(369, 148);
            this.bPAPStop.Name = "bPAPStop";
            this.bPAPStop.Size = new System.Drawing.Size(100, 23);
            this.bPAPStop.TabIndex = 27;
            this.bPAPStop.Text = "Stop";
            this.bPAPStop.UseVisualStyleBackColor = true;
            this.bPAPStop.Click += new System.EventHandler(this.bPAPStop_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(204, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Impulsions";
            // 
            // tBPAPPosTh
            // 
            this.tBPAPPosTh.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBPAPPosTh.Location = new System.Drawing.Point(204, 36);
            this.tBPAPPosTh.Name = "tBPAPPosTh";
            this.tBPAPPosTh.ReadOnly = true;
            this.tBPAPPosTh.Size = new System.Drawing.Size(100, 19);
            this.tBPAPPosTh.TabIndex = 32;
            this.tBPAPPosTh.TabStop = false;
            this.tBPAPPosTh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cBPAPStep
            // 
            this.cBPAPStep.AutoSize = true;
            this.cBPAPStep.Location = new System.Drawing.Point(369, 36);
            this.cBPAPStep.Name = "cBPAPStep";
            this.cBPAPStep.Size = new System.Drawing.Size(54, 17);
            this.cBPAPStep.TabIndex = 24;
            this.cBPAPStep.Text = "µStep";
            this.cBPAPStep.UseVisualStyleBackColor = true;
            this.cBPAPStep.CheckedChanged += new System.EventHandler(this.cBPAPStep_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(95, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "Consignes";
            // 
            // bPAPMove
            // 
            this.bPAPMove.Location = new System.Drawing.Point(369, 118);
            this.bPAPMove.Name = "bPAPMove";
            this.bPAPMove.Size = new System.Drawing.Size(100, 23);
            this.bPAPMove.TabIndex = 26;
            this.bPAPMove.Text = "Déplacement";
            this.bPAPMove.UseVisualStyleBackColor = true;
            this.bPAPMove.Click += new System.EventHandler(this.bPAPMove_Click);
            // 
            // tBPAPDec
            // 
            this.tBPAPDec.Location = new System.Drawing.Point(98, 124);
            this.tBPAPDec.Name = "tBPAPDec";
            this.tBPAPDec.Size = new System.Drawing.Size(100, 20);
            this.tBPAPDec.TabIndex = 23;
            this.tBPAPDec.Tag = "DC";
            this.tBPAPDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBPAPDec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.tBPAPDec.Leave += new System.EventHandler(this.UpdateValue);
            // 
            // tBPAPAcc
            // 
            this.tBPAPAcc.Location = new System.Drawing.Point(98, 98);
            this.tBPAPAcc.Name = "tBPAPAcc";
            this.tBPAPAcc.Size = new System.Drawing.Size(100, 20);
            this.tBPAPAcc.TabIndex = 22;
            this.tBPAPAcc.Tag = "AC";
            this.tBPAPAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBPAPAcc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.tBPAPAcc.Leave += new System.EventHandler(this.UpdateValue);
            // 
            // tBPAPSpeed
            // 
            this.tBPAPSpeed.Location = new System.Drawing.Point(98, 62);
            this.tBPAPSpeed.Name = "tBPAPSpeed";
            this.tBPAPSpeed.Size = new System.Drawing.Size(100, 20);
            this.tBPAPSpeed.TabIndex = 21;
            this.tBPAPSpeed.Tag = "SP";
            this.tBPAPSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBPAPSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.tBPAPSpeed.Leave += new System.EventHandler(this.UpdateValue);
            // 
            // tBPAPPosCon
            // 
            this.tBPAPPosCon.Location = new System.Drawing.Point(98, 36);
            this.tBPAPPosCon.Name = "tBPAPPosCon";
            this.tBPAPPosCon.Size = new System.Drawing.Size(100, 20);
            this.tBPAPPosCon.TabIndex = 20;
            this.tBPAPPosCon.Tag = "PR";
            this.tBPAPPosCon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBPAPPosCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.tBPAPPosCon.Leave += new System.EventHandler(this.UpdateValue);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Décélération";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 101);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Accélération";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Vitesse";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 39);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "Position";
            // 
            // bResetGalil
            // 
            this.bResetGalil.BackColor = System.Drawing.Color.Red;
            this.bResetGalil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bResetGalil.ForeColor = System.Drawing.Color.White;
            this.bResetGalil.Location = new System.Drawing.Point(12, 484);
            this.bResetGalil.Name = "bResetGalil";
            this.bResetGalil.Size = new System.Drawing.Size(111, 23);
            this.bResetGalil.TabIndex = 35;
            this.bResetGalil.Text = "Reset Contrôleur";
            this.bResetGalil.UseVisualStyleBackColor = false;
            this.bResetGalil.Click += new System.EventHandler(this.bResetGalil_Click);
            // 
            // FManip27Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 519);
            this.Controls.Add(this.bResetGalil);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBDC);
            this.MaximizeBox = false;
            this.Name = "FManip27Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LaRA - manip27 - Galil";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gBDC.ResumeLayout(false);
            this.gBDC.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox gBDC;
        private System.Windows.Forms.Button bDCMove;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBPosErr;
        private System.Windows.Forms.TextBox tBSpeedAct;
        private System.Windows.Forms.TextBox tBDCPosAct;
        private System.Windows.Forms.TextBox tBDCPosCon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBDCDec;
        private System.Windows.Forms.TextBox tBDCAcc;
        private System.Windows.Forms.TextBox tBDCSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBDCMode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBUCommand;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lDCMotorState;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tBDCKI;
        private System.Windows.Forms.TextBox tBDCKD;
        private System.Windows.Forms.TextBox tBDCKP;
        private System.Windows.Forms.Button bDCStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cBPAPStep;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button bPAPMove;
        private System.Windows.Forms.TextBox tBPAPDec;
        private System.Windows.Forms.TextBox tBPAPAcc;
        private System.Windows.Forms.TextBox tBPAPSpeed;
        private System.Windows.Forms.TextBox tBPAPPosCon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tBPAPPosTh;
        private System.Windows.Forms.Button bPAPStop;
        private System.Windows.Forms.Label lPAPMotorState;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cBPAPMode;
        private System.Windows.Forms.Button bDCResetPos;
        private System.Windows.Forms.Button bPAPResetPos;
        private System.Windows.Forms.Button bResetGalil;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

