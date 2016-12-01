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
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
namespace Chat_APP
{
    public partial class Form1 : Form
    {
        Socket mySocket;
        EndPoint epLocal, epRemote;
        byte[] buffer;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        string EchoMode = "0"; 

        private void Form1_Load(object sender, EventArgs e)
        {
            //Process.Start(myStart);
            //set up socket
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            mySocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            //get user IP
            LtxtLocalIP.Text    = GetLocalIP();
            btnSend.Visible     = false;
            txtMessage.Enabled  = false;
            groupBox1.Visible   = false;
            label5.Visible      = false;
            label8.Visible      = false;
            label9.Visible      = false;
       }

       private string GetLocalIP()
       {
            IPHostEntry myHost;
            myHost = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in myHost.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            txtMessage.Enabled = true;
            txtRemoteIP.Enabled = false;
            //epLocal = new IPEndPoint(IPAddress.Parse(LtxtLocalIP.Text), Convert.ToInt32(txtLocalPort.Text));
            epLocal = new IPEndPoint(IPAddress.Parse(LtxtLocalIP.Text), Convert.ToInt32("1024"));
            mySocket.Bind(epLocal);
            //Connecting To Remote IP
            //epRemote = new IPEndPoint(IPAddress.Parse(txtRemoteIP.Text), Convert.ToInt32(txtRemotePort.Text));
            epRemote = new IPEndPoint(IPAddress.Parse(txtRemoteIP.Text), Convert.ToInt32("1024"));
            mySocket.Connect(epRemote);
            //Listening TO specific Port
            buffer = new byte[1500];
            mySocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            //Changing btnCOnnect text
            BtnConnect.Text = "Connected";
            BtnConnect.Enabled = false;
        }
        
        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                byte[] RecivedData = new byte[1500];
                RecivedData = (byte[])aResult.AsyncState;
                //converting byte[] into string
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                string RecivedMessage = aEncoding.GetString(RecivedData);
                //Adding this message to listbox
                //Friend
                if (bSelfTest.BackColor == System.Drawing.Color.Lime)
                { 
                }
                else
                {
                    ListMessages.Items.Add("" + RecivedMessage);
                    ListMessages.SelectedIndex = ListMessages.Items.Count - 1;
                    label5.Text = ListMessages.SelectedItem.ToString();

                    if (label5.Text == "EchoMode(another Com) : ON")
                    {
                        label8.BackColor = System.Drawing.Color.Lime;
                        EchoMode = "1";
                        label5.Text = "EchoMode(another Com) : ON";
                    }
                    else if (label5.Text == "EchoMode(another Com) : OFF")
                    {
                        label8.BackColor = System.Drawing.Color.Red;
                        EchoMode ="0";
                        label5.Text = "EchoMode(another Com) : OFF";
                    }
                    else if (label5.Text == "SelfTest(another Com)")
                    {
                        Application.Restart();
                    }
                    else 
                    { 
                    }
                }
                buffer = new byte[1500];
                mySocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtRemoteIP_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtLocalIP_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (((bEchoMode.BackColor == System.Drawing.Color.Lime)&&EchoMode=="1")||(bEchoMode.BackColor == System.Drawing.Color.Lime)&&(bSelfTest.BackColor == System.Drawing.Color.Lime) )
                {                
                    int i;
                    Task.Factory.StartNew(() =>
                    {
                        DialogResult dresult = MessageBox.Show("Do you want to stop Echo ? ", "Echo");
                        if (dresult == DialogResult.OK)
                        {
                            i = -1;
                        }
                    });
                    for(i = 0; i!=-1; i++)
                    {
                        btnSend_Click(sender, e);
                        if (i==-1)
                        {
                            bEchoMode.BackColor = System.Drawing.Color.Red;
                            ASCIIEncoding aEncoding = new ASCIIEncoding();
                            byte[] SendingMessage = new byte[1500];
                            SendingMessage = aEncoding.GetBytes("EchoMode(another Com) : OFF");
                            //sending Encoding message      
                            mySocket.Send(SendingMessage);
                            break;
                        }
                    }
                }
                else
                {
                    ASCIIEncoding aEncoding = new ASCIIEncoding();
                    byte[] SendingMessage = new byte[1500];

                    int maxLines = txtMessage.Lines.Length;
                    if (maxLines > 0)
                    {
                        string lastLine = txtMessage.Lines[maxLines - 1];
                        string lastWord = lastLine.Split(' ').Last();
                        label9.Text = lastWord;
                    }
                    
                    SendingMessage = aEncoding.GetBytes(label9.Text);
                    //sending Encoding message               
                    mySocket.Send(SendingMessage);

                    if ((bSelfTest.BackColor == System.Drawing.Color.Lime) || EchoMode == "1")
                    {
                        ListMessages.Items.Add("" + label9.Text);
                        ListMessages.SelectedIndex = ListMessages.Items.Count - 1;
                    }
                    else{ 
                    }
                }
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
        }

        private void bEchoMode_Click(object sender, EventArgs e)
        {
            if (bEchoMode.BackColor == System.Drawing.Color.Lime)
            {
                bEchoMode.BackColor = System.Drawing.Color.Red;
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                byte[] SendingMessage = new byte[1500];
                SendingMessage = aEncoding.GetBytes("EchoMode(another Com) : OFF");
                //sending Encoding message      
                mySocket.Send(SendingMessage);
            }
            else
            {
                bEchoMode.BackColor = System.Drawing.Color.Lime;
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                byte[] SendingMessage = new byte[1500];
                SendingMessage = aEncoding.GetBytes("EchoMode(another Com) : ON");
                //sending Encoding message      
                mySocket.Send(SendingMessage);
            }
        }

        private void bSelfTest_Click(object sender, EventArgs e)
        {
            if (bSelfTest.BackColor == System.Drawing.Color.Lime)
            {
                bSelfTest.BackColor = System.Drawing.Color.Red;
                BtnConnect.Enabled = true;
                Application.Restart();
            }
            else
            {
                bSelfTest.BackColor = System.Drawing.Color.Lime;
                txtRemoteIP.Text = GetLocalIP();
                this.BtnConnect.PerformClick();
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                byte[] SendingMessage = new byte[1500];
                SendingMessage = aEncoding.GetBytes("SelfTest(another Com)");
                //sending Encoding message      
                mySocket.Send(SendingMessage);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] SendingMessage = new byte[1500];
            int maxLines = txtMessage.Lines.Length;
            if (maxLines > 0)
            {
                string lastLine = txtMessage.Lines[maxLines - 1];
                string lastWord = lastLine.Split(' ').Last();
                label9.Text = lastWord;
            }
            SendingMessage = aEncoding.GetBytes(label9.Text);
            //sending Encoding message               
            mySocket.Send(SendingMessage);
            //adding to listbox
            //ME:
            ListMessages.Items.Add("" + label9.Text);
            ListMessages.SelectedIndex = ListMessages.Items.Count - 1;
        }

        private void ListMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ListMessages.Items.Clear();
        }
        
        private void bReset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void txtRemoteIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BtnConnect.PerformClick();
            }
        }
    }
}
