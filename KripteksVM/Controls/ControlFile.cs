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
    public class ControlFile
    {
        public  ST_CONTROLLER_PROPERTIES fbGetControllerProperties()
        {
            ST_CONTROLLER_PROPERTIES stControllerProperties = new ST_CONTROLLER_PROPERTIES();

            string path = Application.StartupPath;
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
                    if (values[0] == "ControllerCycleMs") stControllerProperties.iControllerCycleMs = int.Parse(values[1]);
                    if (values[0] == "BeckhoffAMSNetID") stControllerProperties.stControllerBeckhoff.sBeckhoffAMSNetID = values[1];
                    if (values[0] == "BeckhoffPortNo") stControllerProperties.stControllerBeckhoff.sBeckhoffPortNo = values[1];


                    yazi = sw.ReadLine();
                }

                sw.Close();
                fs.Close();

            }
            else
            {
                fbSetControllerProperties(stControllerProperties);
            }
            return stControllerProperties;
        }
        public void fbSetControllerProperties(ST_CONTROLLER_PROPERTIES stControllerProperties)
        {
            string path = Application.StartupPath;
            string dosya_yolu = path + "\\Config\\ControllerProperties.ini";

            if (File.Exists(dosya_yolu)) File.Delete(dosya_yolu);

            try
            {
                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("ControllerType" + "=" + stControllerProperties.sControllerType);
                sw.WriteLine("ControllerCycleMs" + "=" + stControllerProperties.iControllerCycleMs);
                sw.WriteLine("BeckhoffAMSNetID" + "=" + stControllerProperties.stControllerBeckhoff.sBeckhoffAMSNetID);
                sw.WriteLine("BeckhoffPortNo" + "=" + stControllerProperties.stControllerBeckhoff.sBeckhoffPortNo);

                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch
            {

            }

        }

    }
}
