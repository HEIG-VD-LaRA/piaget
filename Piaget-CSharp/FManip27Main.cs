using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Globalization;

namespace LaRA_manip27
{
    public partial class FManip27Main : Form
    {
        public static bool simulation_Manip27 = false;

        struct simul
        {
            public int CPosition,
                   CSpeed,
                   CAcceleration,
                   CDeceleration;
            public double KP,
                   KD,
                   KI;
            public int PAP_CPosition,
                   PAP_CSpeed,
                   PAP_CAcceleration,
                   PAP_CDeceleration;
        };
        simul s = new simul { CPosition = 0, CSpeed = 3200, CAcceleration = 3072, CDeceleration = 3072, KP = 10, KD = 60, KI = 1,
        PAP_CPosition=0, PAP_CSpeed=320 , PAP_CAcceleration=1024, PAP_CDeceleration=1024};

        public FManip27Main()
        {
            InitializeComponent();
            if (simulation_Manip27)
            {
                InitVariables();


            }
        }

        const string ControllerIP = "172.16.17.31";

        manip27.Controller cG;
        manip27.Motor mDC;
        manip27.Motor mPAP;

        bool updateTxtBox;

        private void InitVariables()
        {
            tBDCPosCon.Text = s.CPosition.ToString();
            tBDCSpeed.Text = s.CSpeed.ToString();
            tBDCAcc.Text = s.CAcceleration.ToString();
            tBDCDec.Text = s.CDeceleration.ToString();
            tBDCKP.Text = s.KP.ToString("F1", CultureInfo.InvariantCulture);
            tBDCKD.Text = s.KD.ToString("F1", CultureInfo.InvariantCulture);
            tBDCKI.Text = s.KI.ToString("F1", CultureInfo.InvariantCulture);

            tBPAPPosCon.Text = s.PAP_CPosition.ToString();
            tBPAPSpeed.Text = s.PAP_CSpeed.ToString();
            tBPAPAcc.Text = s.PAP_CAcceleration.ToString();
            tBPAPDec.Text = s.PAP_CDeceleration.ToString();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!simulation_Manip27)
                {
                    cG = new manip27.Controller(ControllerIP);
                    cG.Connect();
                    this.Text = cG.ControllerInfo;

                    mDC = new manip27.Motor(manip27.tMotorType.DC);
                    mPAP = new manip27.Motor(manip27.tMotorType.PAP);

                    updateTxtBox = true;

                    timer1.Start();

                    cBDCMode.SelectedIndex = 0;
                    cBDCMode_SelectionChangeCommitted(cBDCMode, e);

                    cBPAPMode.SelectedIndex = 0;
                    cBPAPMode_SelectionChangeCommitted(cBPAPMode, e);

                    cBPAPStep.Checked = true;
                    cBPAPStep_CheckedChanged(cBPAPStep, e);
                }
                else
                {
                    timer1.Start();
                    cBDCMode.SelectedIndex = 0;
                    cBPAPMode.SelectedIndex = 0;
                }

               

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(ex.Message + "\nVerifier que le système est enclenché et le câble réseau branché\n\nLe programme va se terminer");
                System.Windows.Forms.Application.Exit();
            }
        }

        private void exit(int p)
        {
            throw new NotImplementedException();
        }

        private bool IsInt(string p)
        {
            throw new NotImplementedException();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!simulation_Manip27)
            {
                cG.UpdateValues(mDC, mPAP);

                if (updateTxtBox)
                {
                    tBDCPosCon.Text = mDC.CPosition.ToString();
                    tBDCSpeed.Text = mDC.CSpeed.ToString();
                    tBDCAcc.Text = mDC.CAcceleration.ToString();
                    tBDCDec.Text = mDC.CDeceleration.ToString();
                    tBDCKP.Text = mDC.KP.ToString("F1", CultureInfo.InvariantCulture);
                    tBDCKD.Text = mDC.KD.ToString("F1", CultureInfo.InvariantCulture);
                    tBDCKI.Text = mDC.KI.ToString("F1", CultureInfo.InvariantCulture);

                    tBPAPPosCon.Text = mPAP.CPosition.ToString();
                    tBPAPSpeed.Text = mPAP.CSpeed.ToString();
                    tBPAPAcc.Text = mPAP.CAcceleration.ToString();
                    tBPAPDec.Text = mPAP.CDeceleration.ToString();

                    updateTxtBox = false;
                }

                tBDCPosAct.Text = mDC.Position.ToString();
                tBDCPosAct.BackColor = (mDC.IsMov) ? Color.LightGreen : SystemColors.Control;
                tBPosErr.Text = mDC.PosErr.ToString();
                tBSpeedAct.Text = mDC.Speed.ToString();
                tBUCommand.Text = mDC.UCommand.ToString("G3");
                lDCMotorState.BackColor = (mDC.MotorState) ? Color.Lime : Color.Red;
                lDCMotorState.ForeColor = (mDC.MotorState) ? SystemColors.ControlText : SystemColors.ButtonHighlight;
                lDCMotorState.Text = (mDC.MotorState) ? "ON" : "OFF";

                tBPAPPosTh.Text = mPAP.Position.ToString();
                tBPAPPosTh.BackColor = (mPAP.IsMov) ? Color.LightGreen : SystemColors.Control;
                lPAPMotorState.BackColor = (mPAP.MotorState) ? Color.Lime : Color.Red;
                lPAPMotorState.ForeColor = (mPAP.MotorState) ? SystemColors.ControlText : SystemColors.ButtonHighlight;
                lPAPMotorState.Text = (mPAP.MotorState) ? "ON" : "OFF";

                tBDCDec.Enabled = (mDC.IsMov && (cBDCMode.SelectedIndex == 1 || cBDCMode.SelectedIndex == 2 || cBDCMode.SelectedIndex == 3)) ? false : true;
                bDCResetPos.Enabled = (mDC.IsMov) ? false : true;
                cBDCMode.Enabled = (mDC.IsMov) ? false : true;
                tBDCPosCon.Enabled = (mDC.IsMov && mDC.toggle) ? false : true;
                tBPAPDec.Enabled = (mPAP.IsMov && (cBPAPMode.SelectedIndex == 1 || cBPAPMode.SelectedIndex == 2 || cBPAPMode.SelectedIndex == 3)) ? false : true;
                cBPAPStep.Enabled = (mPAP.IsMov) ? false : true;
                bPAPResetPos.Enabled = (mPAP.IsMov) ? false : true;
                cBPAPMode.Enabled = (mPAP.IsMov) ? false : true;
                tBPAPPosCon.Enabled = (mPAP.IsMov && mPAP.toggle) ? false : true;

                bDCMove.Enabled = mDC.MotorState && !mDC.IsMov;

                bPAPMove.Enabled = mPAP.MotorState && !mPAP.IsMov;

                if (mDC.toggle && !mDC.IsMov)
                {
                    tBDCPosCon.Text = Convert.ToString(-Convert.ToInt32(tBDCPosCon.Text));
                    bDCMove_Click(sender, e);
                }

                if (mPAP.toggle && !mPAP.IsMov)
                {
                    tBPAPPosCon.Text = Convert.ToString(-Convert.ToInt32(tBPAPPosCon.Text));
                    bPAPMove_Click(sender, e);
                }
            }
            else
            {
                if (updateTxtBox)
                {
                    tBDCPosCon.Text = s.CPosition.ToString();
                    tBDCSpeed.Text = s.CSpeed.ToString();
                    tBDCAcc.Text = s.CAcceleration.ToString();
                    tBDCDec.Text = s.CDeceleration.ToString();
                    tBDCKP.Text = s.KP.ToString("F1", CultureInfo.InvariantCulture);
                    tBDCKD.Text = s.KD.ToString("F1", CultureInfo.InvariantCulture);
                    tBDCKI.Text = s.KI.ToString("F1", CultureInfo.InvariantCulture);
                    
                    tBPAPPosCon.Text = s.PAP_CPosition.ToString();
                    tBPAPSpeed.Text = s.PAP_CSpeed.ToString();
                    tBPAPAcc.Text = s.PAP_CAcceleration.ToString();
                    tBPAPDec.Text = s.PAP_CDeceleration.ToString();

                    tBDCPosAct.Text = "0101010";
                    tBPosErr.Text = "9696";
                    tBPAPPosTh.Text = "1010101";

               
                    updateTxtBox = false;
                }
                tBDCPosAct.BackColor = SystemColors.Control;
                tBSpeedAct.Text = "0000";
                tBUCommand.Text = "0000";
                lDCMotorState.BackColor = Color.Red;
                lDCMotorState.ForeColor = SystemColors.ButtonHighlight;
                lDCMotorState.Text = "OFF";

                tBPAPPosTh.BackColor = SystemColors.Control;
                lPAPMotorState.BackColor = Color.Red;
                lPAPMotorState.ForeColor = SystemColors.ButtonHighlight;
                lPAPMotorState.Text = "OFF";

                tBDCDec.Enabled = true;
                bDCResetPos.Enabled = true;
                cBDCMode.Enabled = true;
                tBDCPosCon.Enabled = true;
                tBPAPDec.Enabled = true;
                cBPAPStep.Enabled = true;
                bPAPResetPos.Enabled = true;
                cBPAPMode.Enabled = true;
                tBPAPPosCon.Enabled = true;

                bDCMove.Enabled = true;

                bPAPMove.Enabled = true;
            }

        }

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                UpdateValue(sender, e);
            }
        }

        private void UpdateValue(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;


            if (!simulation_Manip27)
            {
                bool abs = (cBDCMode.SelectedIndex == 1) ? true : false;
                manip27.Motor m = (TB.Name.Substring(2, 2) == "DC") ? (manip27.Motor)mDC : (manip27.Motor)mPAP;
                if (m.MotorType == manip27.tMotorType.PAP)
                    abs = (cBPAPMode.SelectedIndex == 1) ? true : false;

                try
                {
                    switch (TB.Tag.ToString())
                    {
                        case "PR":
                            m.CPosition = Convert.ToInt32(TB.Text);
                            break;
                        case "SP":
                            m.CSpeed = Convert.ToInt32(TB.Text);
                            break;
                        case "AC":
                            m.CAcceleration = Convert.ToInt32(TB.Text);
                            break;
                        case "DC":
                            m.CDeceleration = Convert.ToInt32(TB.Text);
                            break;
                        case "KP":
                            m.KP = Convert.ToDouble(TB.Text);
                            break;
                        case "KD":
                            m.KD = Convert.ToDouble(TB.Text);
                            break;
                        case "KI":
                            m.KI = Convert.ToDouble(TB.Text);
                            break;
                    }
                    cG.SendValue(TB.Tag.ToString(), TB.Text, m.MotorType, abs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {   
               
                    switch (TB.Tag.ToString())
                    {
                        case "PR":
                            if (TB.Name.Substring(2, 2) == "DC") s.CPosition = Convert.ToInt32(TB.Text);
                            else s.PAP_CPosition = Convert.ToInt32(TB.Text);
                            break;
                        case "SP":
                            if (TB.Name.Substring(2, 2) == "DC") s.CSpeed = Convert.ToInt32(TB.Text);
                            else s.PAP_CSpeed = Convert.ToInt32(TB.Text);
                            break;
                        case "AC":
                            if (TB.Name.Substring(2, 2) == "DC") s.CAcceleration = Convert.ToInt32(TB.Text);
                            else s.PAP_CAcceleration = Convert.ToInt32(TB.Text);
                            break;
                        case "DC":
                            if (TB.Name.Substring(2, 2) == "DC") s.CDeceleration = Convert.ToInt32(TB.Text);
                            else s.PAP_CDeceleration = Convert.ToInt32(TB.Text);
                            break;
                        case "KP":
                            s.KP = Convert.ToDouble(TB.Text);
                            break;
                        case "KD":
                            s.KD = Convert.ToDouble(TB.Text);
                            break;
                        case "KI":
                            s.KI = Convert.ToDouble(TB.Text);
                            break;
                    }

            }
            updateTxtBox = true;
            
        }

        private void bDCMove_Click(object sender, EventArgs e)
        {
            string c = "";
            string v = "";
            switch (cBDCMode.SelectedIndex)
            {
                case 0:
                    c = "MO";
                    break;
                case 1:
                    c = "PA";
                    v = tBDCPosCon.Text;
                    break;
                case 2:
                    c = "PR";
                    v = tBDCPosCon.Text;
                    break;
                case 3:
                    c = "PR";
                    v = tBDCPosCon.Text;
                    mDC.toggle = true;
                    break;
                case 4:
                    c = "JG";
                    v = tBDCSpeed.Text;
                    break;
            }
            if (!simulation_Manip27)
            mDC.Move(c, v);
        }

        private void bPAPMove_Click(object sender, EventArgs e)
        {
            string c = "";
            string v = "";
            switch (cBPAPMode.SelectedIndex)
            {
                case 0:
                    c = "MO";
                    break;
                case 1:
                    c = "PA";
                    v = tBPAPPosCon.Text;
                    break;
                case 2:
                    c = "PR";
                    v = tBPAPPosCon.Text;
                    break;
                case 3:
                    c = "PR";
                    v = tBPAPPosCon.Text;
                    mPAP.toggle = true;
                    break;
                case 4:
                    c = "JG";
                    v = tBPAPSpeed.Text;
                    break;
            }
            if (!simulation_Manip27) mPAP.Move(c, v);
        }
           
        private void cBDCMode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox) sender;

            tBDCPosCon.Enabled = true;
            if (!simulation_Manip27)
            {
                if (senderComboBox.SelectedIndex == 0)
                    mDC.MotorOff();
                else
                {
                    if (senderComboBox.SelectedIndex == 5)
                        bDCMove.Enabled = false;

                    mDC.MotorOn();
                }
            }
            if (senderComboBox.SelectedIndex == 4)
                tBDCPosCon.Enabled = false;
        }

        private void cBPAPMode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;

            tBPAPPosCon.Enabled = true;
            if (!simulation_Manip27)
            {
                if (senderComboBox.SelectedIndex == 0)
                    mPAP.MotorOff();
                else
                    mPAP.MotorOn();
            }
            if (senderComboBox.SelectedIndex == 4)
                tBPAPPosCon.Enabled = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (mDC != null)
                    mDC.MotorOff();
                simulation_Manip27 = false;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        private void bDCStop_Click(object sender, EventArgs e)
        {
            if (!simulation_Manip27)
            {
                mDC.Stop();
                mDC.toggle = false;
            }
        }

        private void cBPAPStep_CheckedChanged(object sender, EventArgs e)
        {
            if (!simulation_Manip27) mPAP.uStep(cBPAPStep.Checked);
        }

        private void bPAPStop_Click(object sender, EventArgs e)
        {
            if (!simulation_Manip27)
            {
                mPAP.Stop();
                mPAP.toggle = false;
            }
        }

        private void ResetPos(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (!simulation_Manip27)
            {
                manip27.Motor m = (b.Tag.ToString() == "DC") ? (manip27.Motor)mDC : (manip27.Motor)mPAP;
                m.resPos();
            }
            else
            {
                if (b.Tag.ToString() == "DC")
                {
                    tBDCPosAct.Text = "0";
                    tBPosErr.Text = "0";
                }
                else tBPAPPosTh.Text = "0"; ;
                
            }
        }

        private async void bResetGalil_Click(object sender, EventArgs e)
        {
            if (!simulation_Manip27)  cG.Reset();
            else 
            this.Enabled = false;
            await Task.Delay(500);
            MainForm_Load(sender, e);
            this.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)   //Quitter
        {
            System.Windows.Forms.Application.Exit();
        }


    }
}
