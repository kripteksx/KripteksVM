using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using KripteksVM.Controls;

namespace KripteksVM.Controls
{
    public class ControlConfig
    {
        public string path = Application.StartupPath;
        public ST_CONTROLLER_PROPERTIES stControllerProperties = new ST_CONTROLLER_PROPERTIES();


        public void fbGetControllerProperties()
        {
            string dosya_yolu = path + "\\Config\\ControllerProperties.ini";
            if (File.Exists(dosya_yolu))
            {
                
                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                string yazi = sw.ReadLine();

                while (yazi != null)
                {
                    string[] values = yazi.Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    // controller
                    if (values[0] == "ControllerType") stControllerProperties.sControllerType = values[1];
                    if (values[0] == "BeckhoffAMSNetID") stControllerProperties.sBeckhoffAMSNetID = values[1];
                    if (values[0] == "BeckhoffPortNo") stControllerProperties.sBeckhoffPortNo = values[1];



                    yazi = sw.ReadLine();
                }

                sw.Close();
                fs.Close();
                
            }
            else
            {
                fbSetControllerProperties();
            }
        }
        public void fbSetControllerProperties()
        {
            string dosya_yolu = path + "\\Config\\ControllerProperties.ini";

            if (File.Exists(dosya_yolu)) File.Delete(dosya_yolu);
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);


            sw.WriteLine("ControllerType" + "=" + stControllerProperties.sControllerType);
            sw.WriteLine("BeckhoffAMSNetID" + "=" + stControllerProperties.sBeckhoffAMSNetID);
            sw.WriteLine("BeckhoffPortNo" + "=" + stControllerProperties.sBeckhoffPortNo);

            sw.Flush();
            sw.Close();
            fs.Close();
            

        }

    }
}
