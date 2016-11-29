using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
// using Piaget_CSharp.uPanel;

using Modbus;

namespace BC9020
{


    public partial class FApiBC9020 : Form
    {
        byte unit_id = 0;
        public static bool simulation_BC9020 = false;
        private bool blink = true; // pour la simulation des entrées
        private bool connected = false,
                     init_OK = false;

        // Create instance of modbus TCP
        ModbusMasterTCP tcpm = new ModbusMasterTCP("172.16.22.2", 502);
    

        public FApiBC9020()
        {
            InitializeComponent();

                int NS = 1;
                ushort bitsOut = 0;
                ushort count = 1;
               
                foreach (Control control in groupBox1.Controls)
                {
                    CheckBox checkBox_x = control as CheckBox;

                    if ((Piaget_CSharp.uPanel.SignauxOut[NS].EtatVF) /*|| (Piaget_CSharp.uPanel.SignauxOut[i].EtatVF) */ )
                    {
                        bitsOut += count;
                        checkBox_x.BackColor = Color.LimeGreen;
                        checkBox_x.Checked = true;
                    }
                    else
                    {
                        checkBox_x.BackColor = SystemColors.Control;
                        checkBox_x.Checked = false;
                    }
                    count *= 2; NS += 1;
                }
                init_OK = true;
        }


        private void Manip25Form_Load(object sender, EventArgs e)
        {
            if (!simulation_BC9020)
            {
               
            
                try
                {  
                    // Exec the connection
//                    if (!Piaget_CSharp.uPanel.BeckhoffEnLigne)
                    if (!connected)
                    {

                        tcpm.Connect(); connected = true;
//                        Piaget_CSharp.uPanel.BeckhoffEnLigne = true;

                        // sets the TaskControlMarker to 0 (C# Control)
                        tcpm.WriteSingleRegister(unit_id, 0x4003, 0);
                    }
                }
                catch
                {
                    MessageBox.Show("172.16.22.2 not found! Conected?");
                    MessageBox.Show("Change to simulation!");
                    simulation_BC9020 = true;
                }

            }

//            InitializeComponent();
            if (connected)
            {
                toolStripStatusLabel1.Text = "Connecté";
                
            }
        

        }


        private void detache(object sender, FormClosedEventArgs e)
        {
            if (!simulation_BC9020)
            {
                // release the valves
                tcpm.WriteSingleRegister(unit_id, 0x4002, 0);
                // sets the TaskControlMarker to 1 (Beckhoff Control)
                tcpm.WriteSingleRegister(unit_id, 0x4003, 1);
                // Disconnect the IP address
                tcpm.Disconnect(); connected = false;
//                Piaget_CSharp.uPanel.BeckhoffEnLigne = false;

            }
            simulation_BC9020 = false;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            // read the DigitalInputsMarker register (System Manager TwinCat -> 0x4000)
            int bits;

            if (connected)
                bits = tcpm.ReadHoldingRegisters(unit_id, 0x4000, 1).First();
            else
                if (blink)
                {
                    bits = 21;
                    blink = false;
                }
                else
                {
                    bits = 42;
                    blink = true;
                }

            foreach (Control control in gBEntreesDigitales.Controls)
            {
                Label iconLabel = control as Label;

                if ((bits % 2) == 1)
                {
                    iconLabel.BackColor = Color.LimeGreen;
                }
                else
                {
                    iconLabel.BackColor = SystemColors.Control;
                }
                bits /= 2;
            }


            int NS = 1;
            ushort bitsOut = 0;
            ushort count = 1;

            foreach (Control control in groupBox1.Controls)
            {
                CheckBox checkBox_x = control as CheckBox;

                if ((Piaget_CSharp.uPanel.SignauxOut[NS].EtatVF) /*|| (Piaget_CSharp.uPanel.SignauxOut[i].EtatVF) */ )
                {
                    bitsOut += count;
                    checkBox_x.BackColor = Color.LimeGreen;
                    checkBox_x.Checked = true;
                }
                else
                {
                    checkBox_x.BackColor = SystemColors.Control;
                    checkBox_x.Checked = false;
                }
                count *= 2; NS += 1;
            }

        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            ushort bitsOut = 0;
            ushort count = 1;
            int NS = 1;
            if (init_OK)
            {
                foreach (Control control in groupBox1.Controls)
                {
                    CheckBox checkBox_x = control as CheckBox;

                    if ((checkBox_x.Checked) /*|| (Piaget_CSharp.uPanel.SignauxOut[i].EtatVF) */ )
                    {
                        bitsOut += count;
                        checkBox_x.BackColor = Color.LimeGreen;
                        Piaget_CSharp.uPanel.SignauxOut[NS].EtatVF = true;
                    }
                    else
                    {
                        checkBox_x.BackColor = SystemColors.Control;
                        Piaget_CSharp.uPanel.SignauxOut[NS].EtatVF = false;
                    }
                    count *= 2; NS += 1;
                }
                /*            if (!simulation_BC9020)
                                // write to the DigitalOutputsMarker register (System Manager TwinCat -> 0x4002)
                                tcpm.WriteSingleRegister(unit_id, 0x4002, bitsOut);
 
                */
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox7.Checked)
            {
                if (!simulation_BC9020)
                    // write to the TasksControlMarker register (System Manager TwinCat -> 0x4003)
                    tcpm.WriteSingleRegister(unit_id, 0x4003, 2);
                checkBox4.Enabled = false;
            }
            else
            {
                if (!simulation_BC9020)
                    // write to the TasksControlMarker register (System Manager TwinCat -> 0x4003)
                    tcpm.WriteSingleRegister(unit_id, 0x4003, 0);
                checkBox4.Enabled = true;
            }
        }

 


 



    }





    public class BC9020withPiaget : FApiBC9020
    {
        byte unit_id = 0;


        // Create instance of modbus TCP
//        ModbusMasterTCP tcpm = new ModbusMasterTCP("172.16.22.2", 502);

        public BC9020withPiaget()
        {

            if (!Piaget_CSharp.uPanel.BeckhoffEnLigne)
            {
                try
                {
                    // Exec the connection
                    {   // tcpm.Connect();
                        Piaget_CSharp.uPanel.BeckhoffEnLigne = true;

                        // sets the TaskControlMarker to 0 (C# Control)
                        // tcpm.WriteSingleRegister(unit_id, 0x4003, 0);
                    }
                }
                catch
                {
                    MessageBox.Show("172.16.22.2 not found! Conected?");
                    MessageBox.Show("Change to simuation!");
                    Piaget_CSharp.uPanel.BeckhoffEnLigne = false;
                }

            }

        }
        
/*
        private void RefreshInputs()
        {
            int index = 1;

            foreach (Control control in gBEntreesDigitales.Controls)
            {
                Label iconLabel = control as Label;
                if (Piaget_CSharp.uPanel.SignauxIn[index].actif)
                {
                    if (iconLabel.BackColor == Color.LimeGreen)
                        Piaget_CSharp.uPanel.SignauxIn[index].EtatVF = true;
                    else
                        Piaget_CSharp.uPanel.SignauxIn[index].EtatVF = false;
                }
                index += 1;
            }
        }
 * 
 */


    }











}
