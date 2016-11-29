using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;


namespace Piaget_CSharp
{
    public class ConfigReadWrite
    {
        public String line;
    public void WriteToCfg()
        {
        using (StreamWriter sw = new StreamWriter("..\\..\\cfg\\cfg.txt")) 
            {
                // Add some text to the file.
                sw.WriteLine("[TicksParSeconde]" + DateTime.Now);
                sw.WriteLine("966799");
                sw.WriteLine("[PasParCmGauche=4*17.9500;  PasParCmDroite=4*17.9500] "+ DateTime.Now);
                sw.WriteLine("48.570000 49.570000"); 
           
            }

        }

    public void ReadFromCfg()
        {
        using (StreamReader sr = new StreamReader("..\\..\\cfg\\cfg.txt")) 
                { string[] arLine = new string[10];//can take array of 10 params at a time
                  char[] splitter = { ' ' };

                  line = sr.ReadLine();//tag
                  line = sr.ReadLine();//value
                
                  line = sr.ReadLine();//tag
                  line = sr.ReadLine();//value                  
                    arLine = line.Split(splitter);
                  
                  line = arLine[1];//
                    
                }

        
        } 
    
    }
}