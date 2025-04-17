using System;
using System.IO;
using System.Windows.Forms;

namespace KripteksVM.Concrete
{
    public class ControllerSettingsFile : IControllerSettingsFile
    {
        public ControllerSettings GetControllerSettings()
        {
            ControllerSettings controllerSettings = new ControllerSettings();

            string path = Application.StartupPath;
            string dosyaYolu = path + "\\Config\\ControllerProperties.ini";
            if (File.Exists(dosyaYolu))
            {
                FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                string yazi = sw.ReadLine();

                while (yazi != null)
                {
                    string[] values = yazi.Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    // controller
                    if (values[0] == "ControllerType") controllerSettings.controllerType = values[1];
                    if (values[0] == "ControllerCycleMs") controllerSettings.cycleTime = int.Parse(values[1]);
                    if (values[0] == "BeckhoffAMSNetID") controllerSettings.controllerBeckhoff.AMSNetID = values[1];
                    if (values[0] == "BeckhoffPortNo") controllerSettings.controllerBeckhoff.portNo = values[1];
                    if (values[0] == "ModbusTCPIpAddress") controllerSettings.controllerModbusTCP.IPAddress = values[1];
                    if (values[0] == "ModbusTCPPortNo") controllerSettings.controllerModbusTCP.portNo = Convert.ToUInt16(values[1]);

                    yazi = sw.ReadLine();
                }

                sw.Close();
                fs.Close();
            }
            else
            {
                SetControllerSettings(controllerSettings);
            }
            return controllerSettings;
        }
        public void SetControllerSettings(ControllerSettings controllerSettings)
        {
            string path = Application.StartupPath;
            string dosyaYolu = path + "\\Config\\ControllerProperties.ini";

            if (File.Exists(dosyaYolu)) File.Delete(dosyaYolu);

            try
            {
                FileStream fs = new FileStream(dosyaYolu, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("ControllerType" + "=" + controllerSettings.controllerType);
                sw.WriteLine("ControllerCycleMs" + "=" + controllerSettings.cycleTime);
                sw.WriteLine("BeckhoffAMSNetID" + "=" + controllerSettings.controllerBeckhoff.AMSNetID);
                sw.WriteLine("BeckhoffPortNo" + "=" + controllerSettings.controllerBeckhoff.portNo);
                sw.WriteLine("ModbusTCPIpAddress" + "=" + controllerSettings.controllerModbusTCP.IPAddress);
                sw.WriteLine("ModbusTCPPortNo" + "=" + controllerSettings.controllerModbusTCP.portNo);

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
