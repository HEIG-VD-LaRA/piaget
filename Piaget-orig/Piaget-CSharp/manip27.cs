using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Windows.Forms;

namespace LaRA_manip27
{
    class manip27
    {
        public enum tMotorType { DC, PAP };
        private static Galil.Galil DMC1425;
        const int msgDelay = 5;
        const int msgDelay2 = 30000;

        public class Controller
        {
            public Controller(string address)
            {
                ipAddress = address;
                DMC1425 = new Galil.Galil();
                DMC1425.address = ipAddress;
              //  ControllerInfo = DMC1425.connection();
            }

            public void Connect()
            {
                ControllerInfo = DMC1425.connection();
            }

            public void Reset()
            {
                DMC1425.command("RS", "\r", ":", true);
            }

            private static string ipAddress;
            public string IPAddress
            {
                get { return Controller.ipAddress; }
                set { Controller.ipAddress = value; }
            }            

            private string controllerInfo;
            public string ControllerInfo
            {
                get { return controllerInfo; }
                set 
                { 
                    if (value == null)
                        throw new ArgumentNullException();
                    controllerInfo = value; 
                }
            }

            public void UpdateValues(Motor mDC, Motor mPAP)
            {
                try
                {
 //                   mDC.CPosition = (int)DMC1425.commandValue("PR?");      // EHe 014.10.08, PA? <> PR? !!!
                    mDC.CSpeed = (int)DMC1425.commandValue("SP?"); 
                    mDC.CAcceleration = (int)DMC1425.commandValue("AC?"); 
                    mDC.CDeceleration = (int)DMC1425.commandValue("DC?"); 

                    mDC.KP = (float)DMC1425.commandValue("KP?"); 
                    mDC.KD = (float)DMC1425.commandValue("KD?"); 
                    mDC.KI = (float)DMC1425.commandValue("KI?");
 //                   mPAP.CPosition = (int)DMC1425.commandValue("PR,?");    // EHe 014.10.08, PA? <> PR? !!!
                    mPAP.CSpeed = (int)DMC1425.commandValue("SP,?"); 
//                    mPAP.CSpeed = (int)DMC1425.commandValue("SPB=?"); 
                    mPAP.CAcceleration = (int)DMC1425.commandValue("AC,?"); 
                    mPAP.CDeceleration = (int)DMC1425.commandValue("DC,?"); 

                    Object r = DMC1425.record("QR"); 
                    mDC.IsMov = Convert.ToBoolean(DMC1425.sourceValue(r, "_BGA")); 
                    mDC.Position = (int)DMC1425.sourceValue(r, "_TPA"); 
                    mDC.Speed = (int)DMC1425.sourceValue(r, "_TVA"); 
                    mDC.PosErr = (int)DMC1425.sourceValue(r, "_TEA"); 
                    mDC.UCommand = DMC1425.sourceValue(r, "_TTA");
                    mDC.powEnable = Convert.ToBoolean(DMC1425.sourceValue(r, "@OUT[03]"));
                    mDC.MotorState = !Convert.ToBoolean(DMC1425.sourceValue(r, "_MOA")) && mDC.powEnable;
       
                    mPAP.IsMov = Convert.ToBoolean(DMC1425.sourceValue(r, "_BGB"));
                    mPAP.Position = (int)DMC1425.sourceValue(r, "_TDB");
                    mPAP.powEnable = !Convert.ToBoolean(DMC1425.sourceValue(r, "@OUT[01]"));
                    bool frage = !Convert.ToBoolean(DMC1425.sourceValue(r, "_MOB"));
                    mPAP.MotorState = frage && mPAP.powEnable;
                    //mPAP.MotorState =  !Convert.ToBoolean(DMC1425.sourceValue(r, "_MOB")) && mPAP.powEnable;

//                    mPAP.MotorState = /* !Convert.ToBoolean(DMC1425.sourceValue(r, "_MOB")) && */ mPAP.powEnable;
                                             // EHe 014.10.08
                }
                catch (Exception)
                {                   
                    
                    throw;
                }

            }

            public string SendValue(string command, string value, tMotorType moteur, bool abs)
            {
                string m = (moteur == tMotorType.DC)?"A=":"B=";
                
                if ((command == "PR") && (abs))    // seulement si PR --> PA
                    command = command.Substring(0,1) + "A";

                command += m + value;
                return DMC1425.command(command, "\r", ":", true);
            }

        }

        public class Motor
        {
            private readonly tMotorType motorType;

            internal tMotorType MotorType
            {
                get { return motorType; }
            } 

            public Motor(tMotorType type)
            {
                motorType = type;
            }

            public int CPosition { get; set; }
            public int Position { get; set; }

            private int cSpeed;
            public int CSpeed
            {
                get { return cSpeed; }
                set // DC 0 - 12'000'000, PAP 0-3'000'000
                {
                    switch (MotorType)
                    {
                        case tMotorType.DC:
                            if (value < 0 || value > 12000000)
                                throw new ArgumentOutOfRangeException("Speed", "Plage de consigne vitesse moteur DC : 0 à 12'000'000");
                            value -= value % 2; // vitesse DC est un nombre pair
                            break;
                        case tMotorType.PAP:
                            if (value < 0 || value > 3000000)
                                throw new ArgumentOutOfRangeException("Speed", "Plage de consigne vitesse moteur PAP : 0 à 8'000'000");
                            break;
                    }
                    cSpeed = value;
                }

            }
            public int Speed;

            public bool IsMov { get; set; }
            public bool IsAcc { get; set; }

            private int cAcceleration;
            public int CAcceleration
            {
                get { return cAcceleration; }
                set
                {
                    if (value < 1024 || value > 67107840)
                        throw new ArgumentOutOfRangeException("Acceleration", "Plage de consigne d'accélération : 1024 à 67'107'840");
                    cAcceleration = value;
                }
            }

            private int cDeceleration;
            public int CDeceleration
            {
                get { return cDeceleration; }
                set
                {
                    if (value < 1024 || value > 67107840)
                        throw new ArgumentOutOfRangeException("Deceleration", "Plage de consigne de décélération : 1024 à 67'107'840");
                    cDeceleration = value;
                }
            }

            private float reduction;
            public float Reduction
            {
                get { return reduction; }
                set
                {
                    if (value <= 0)
                        throw new ArgumentOutOfRangeException("Reduction", "Plage de consigne de décélération : 1024 à 67'107'840");
                    reduction = value;
                }
            }

            private double kp;
            public double KP
            {
                get { return kp; }
                set // 0 - 1023.875
                {
                    if (value < 0 || value > 1023.875)
                        throw new ArgumentOutOfRangeException("KP", "Plage de valeurs KP : 0 à 1023.875");
                    kp = value;
                }
            }

            private double kd;
            public double KD
            {
                get { return kd; }
                set // 0 - 4095.875
                {
                    if (value < 0 || value > 4095.875)
                        throw new ArgumentOutOfRangeException("KD", "Plage de valeurs KD : 0 à 4095.875");
                    kd = value; 
                }
            }

            private double ki;
            public double KI
            {
                get { return ki; }
                set // 0 - 2047.875
                {
                    if (value < 0 || value > 2047.875)
                        throw new ArgumentOutOfRangeException("KD", "Plage de valeurs KD : 0 à 2047.875");
                    ki = value;
                }
            }

            public int PosErr { get; set; }

            public double UCommand { get; set; }

            public bool MotorState { get; set; }

            public bool uStepState { get; set; }

            public bool powEnable { get; set; }

            public bool toggle { get; set; }

            public async void MotorOff()
            {
                string m = (MotorType == tMotorType.DC) ? "A" : "B";
                string c = (MotorType == tMotorType.DC) ? "CB3" : "SB1";

                string r = DMC1425.command(c, "\r", ":", true); // Disable Power
                await Task.Delay(msgDelay);
            }

            public async void MotorOn()
            {
                string m = (MotorType == tMotorType.DC) ? "A" : "B";
                string c = (MotorType == tMotorType.DC) ? "SB3" : "CB1";

                DMC1425.commandValue("SH" + m); // Both motors ! Reset erreur moteur DC // EHe 014.10.08
                string r = DMC1425.command(c); // Enable Power
                await Task.Delay(msgDelay);
                int op = (int)DMC1425.commandValue("OP?");
                if ((((op & 4) == 0) && (MotorType == tMotorType.DC) ) || (((op & 1) != 0) && (MotorType == tMotorType.PAP))) 
                    MessageBox.Show("Commutateur de puissance du moteur " + ((MotorType == tMotorType.DC) ? "DC" : "PAP") + " forcé sur DISABLE");
                else
                    await Task.Delay(msgDelay);
            }

            public async void Move(string command, string value)
            {
                string relMov = "";
                if (!IsMov && MotorState)       // You cannot give another BG command until current BG motion has been completed EHe/Galil
                {
                    string m = (MotorType == tMotorType.DC) ? "A" : "B";
 
                    string r = DMC1425.command(command + m + "=" + value, "\r", ":", true);
                    relMov = DMC1425.command("PR ?,?", "\r", ":", true); // EHe
                    
//                    await Task.Delay(msgDelay);     // EHe
//                    Thread.Sleep(msgDelay);         // EHe

                    DMC1425.command("BG" + m, "\r", ":", true);
                }
            }

            public string Stop()
            {
                string m = (MotorType == tMotorType.DC) ? "A" : "B";
                return DMC1425.command("ST" + m, "\r", ":", true);
            }

            public void uStep(bool state)
            {
                string c = (state) ? "CB2" : "SB2";
                string r = DMC1425.command(c);
                uStepState = state;
            }

            public void resPos()
            {
                string m = (MotorType == tMotorType.DC) ? "A" : "B";
                string r = DMC1425.command("DP" + m + "=0", "\r", ":", true);
            }
        }
    }
}
