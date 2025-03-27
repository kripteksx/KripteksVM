using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KripteksVM.Concrete
{
    class General
    {
        // ortak log 
        public TextBox txtLog { get; set; }

        private static readonly General _shared = new General();
        
        public static General GetInstance()
        {
            return _shared;
        }

        public double FloatingPoint(double value, int floatingPoint)
        {
            double power = 0;
            double newValue = 0;

            power = Math.Pow(10, floatingPoint);
            value = value * power;
            Int32 valueToDint = Convert.ToInt32(value);
            newValue = Convert.ToDouble(valueToDint);
            newValue = newValue / power;

            return newValue;
        }

        public string CID()
        {
            string cid = "";
            Random randomNo = new Random();
            for (int i = 0; i <= 7; i++)
                if (i == 0)
                    cid = cid + randomNo.Next(1, 9);
                else
                    cid = cid + randomNo.Next(0, 9);
            return cid;
        }

        public void LogText(string text)
        {
            try
            {
                txtLog.BeginInvoke((MethodInvoker)delegate () { txtLog.Text = createTimeStampString() + " | " + text + Environment.NewLine + txtLog.Text; });
            }
            catch
            {

            }
        }

        private string createTimeStampString()
        {
            string timeStampString = String.Empty;
            DateTime time = DateTime.Now;

            // use language independent format for logging. 
            string dateString = String.Empty; //  time.Day.ToString("00") + DATE_SEPARATOR + time.Month.ToString("00") + DATE_SEPARATOR + time.Year.ToString();
            string timeString = time.Hour.ToString("00") + ":" + time.Minute.ToString("00") + ":" + time.Second.ToString("00") + "." + time.Millisecond.ToString("000");
            timeStampString = dateString + " " + timeString;
            return timeStampString;
        }

        public static string ConvertHex(string hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 3)
                {
                    string hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    ulong decval = Convert.ToUInt64(hs, 16);
                    long deccc = Convert.ToInt64(hs, 16);
                    char character = Convert.ToChar(deccc);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            return string.Empty;
        }

        public void InvokerText(TextBox txt, string text)
        {
            txt.BeginInvoke((MethodInvoker)delegate () { txt.Text = text; });
        }

        public void InvokerEnabled(TextBox txt, bool value)
        {
            txt.BeginInvoke((MethodInvoker)delegate () { txt.Enabled = value; });
        }

        public void InvokerEnabled(Button btn, bool value)
        {
            try
            {
                btn.BeginInvoke((MethodInvoker)delegate () { btn.Enabled = value; });
            }
            catch
            {

            }
        }

        public void InvokerEnabled(ComboBox cb, bool value)
        {
            cb.BeginInvoke((MethodInvoker)delegate () { cb.Enabled = value; });
        }
    }
}
