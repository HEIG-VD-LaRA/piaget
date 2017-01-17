using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modbus;


namespace Piaget_CSharp
{
    class ThBeck
    {

        public delegate void BeckhoffDelegate(string api);

        public static void Beckhoff(string api)
        {
            byte unit_id = 1;
            int bitsIn = 0, test;
            ushort bitsOut = 0, count = 1;
                

            ModbusMasterTCP tcpmM25 = new ModbusMasterTCP("172.16.22.2", 502),
                            tcpmRHY = new ModbusMasterTCP("???.???.???.???",502);

            switch(uPanel.Platform)
            {
                case uPanel.tPlatform.MANIP25 :
                    tcpmM25.Connect();
                    test = tcpmM25.ReadHoldingRegisters(unit_id, 0x4003, 1).First();

                    switch (api)
                    {
                        case "BC9020_ON":
                            if (!((test == 0) || (test == 2)))
                            {
                                tcpmM25.WriteSingleRegister(unit_id, 0x4003, 0);
                            }
                            // LECTURE
                            bitsIn = tcpmM25.ReadHoldingRegisters(unit_id, 0x4000, 1).First();
                            for (int i = 1; i < 7; i++)
                            {
                                    if ((bitsIn % 2) == 1)
                                    {
                                        uPanel.SignauxIn[i].EtatVF = true;
                                    }
                                    else
                                    {
                                        uPanel.SignauxIn[i].EtatVF = false;
                                    }
 
                                bitsIn /= 2;
                            
                            }
                            // ECRITURE
                            for (int i = 1; i < 7; i++ )
                            {
                                if (uPanel.SignauxOut[i].EtatVF)
                                {
                                    bitsOut += count;
                                }
    //                            else
      //                          {
        //                        }
                                count *= 2;
                            }
                            tcpmM25.WriteSingleRegister(unit_id, 0x4002, bitsOut);
                            tcpmM25.Disconnect();
                            uMTasks.Work[6].TaskStatus = uMTasks.tPhase.Faite;

                            break;

                        case "BC9020_OFF":
                            if (test == 0)
                            {
                                // release the valves
                                tcpmM25.WriteSingleRegister(unit_id, 0x4002, 0);
                                // sets the TaskControlMarker to 1 (Beckhoff Control)
                                tcpmM25.WriteSingleRegister(unit_id, 0x4003, 1);
                            }
                            tcpmM25.Disconnect();
                            uMTasks.Work[6].TaskStatus = uMTasks.tPhase.Suspendue;

                            break;
                    }
                    // Disconnect the IP address
                    break;
            }
            }
        }

}
