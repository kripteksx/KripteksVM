using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KripteksVM.Controls
{

    public class ControlClass
    {
        public const int iBoolSize = 32;
        public const int iDoubleSize = 8;
        public const int iWordSize = 8;

        public class ST_KVM
        {
            public ST_KVM_Status stStatus = new ST_KVM_Status();
            public ST_KVM_App stApp = new ST_KVM_App();
            public ST_KVM_CA stCA = new ST_KVM_CA();
            public ST_KVM_AC stAC = new ST_KVM_AC();
            
        }
        public class ST_KVM_CA
        {
            public double[] dCA = new double[iDoubleSize];
            public UInt16[] wCA = new UInt16[iWordSize];
            public bool[] boCA = new bool[iBoolSize];

            public string[] sdCAComments = new string[iDoubleSize];
            public string[] swCAComments = new string[iWordSize];
            public string[] sboCAComments = new string[iBoolSize];
            public ST_KVM_CA()
            {
                for (int i = 0; i < iDoubleSize; i++)
                {
                    this.sdCAComments[i] = i.ToString();
                    this.dCA[i] = 0.0;
                }
                for (int i = 0; i < iWordSize; i++)
                {
                    this.swCAComments[i] = i.ToString();
                    this.wCA[i] = 0;
                }
                for (int i = 0; i < iBoolSize; i++)
                {
                    this.sboCAComments[i] = i.ToString();
                    this.boCA[i] = false;
                }
            }
        }
        public class ST_KVM_AC
        {
            public double[] dAC = new double[iDoubleSize];
            public UInt16[] wAC = new UInt16[iWordSize];
            public bool[] boAC = new bool[iBoolSize];

            public string[] sdACComments = new string[iDoubleSize];
            public string[] swACComments = new string[iWordSize];
            public string[] sboACComments = new string[iBoolSize];
            public ST_KVM_AC()
            {
                for (int i = 0; i < iDoubleSize; i++)
                {
                    this.sdACComments[i] = i.ToString();
                    this.dAC[i] = 0.0;
                }
                for (int i = 0; i < iWordSize; i++)
                {
                    this.swACComments[i] = i.ToString();
                    this.wAC[i] = 0;
                }
                for (int i = 0; i < iBoolSize; i++)
                {
                    this.sboACComments[i] = i.ToString();
                    this.boAC[i] = false;
                }
            }
        }
        public class ST_KVM_App
        {
            // classlar arasi
            public string sCID = "";
            public string sSID = "0";
            public string sAID = "0";
            public string sName = "";
            public string sInfo = "";
            public ST_KVM_App()
            {
                this.sCID = "";
                this.sSID = "";
                this.sAID = "";
                this.sName = "";
                this.sInfo = "";
            }
        }
        public class ST_KVM_Status
        {
            public bool boLive;
            public bool boAppLive;
            public bool boWebLive;
            public double dElapsedTimeSec;
            public UInt16 wLiveCounter;

            public ST_KVM_Status()
            {
                this.boLive = false;
                this.boAppLive = false;
                this.boWebLive = false;
                this.dElapsedTimeSec = 0;
                this.wLiveCounter = 0;
            }
        }

    }
    public class ST_CONTROLLER_PROPERTIES
    {
        public string sControllerType;
        public string sBeckhoffAMSNetID;
        public string sBeckhoffPortNo;
        public ST_CONTROLLER_PROPERTIES()
        {
            this.sControllerType = "Beckhoff";
            this.sBeckhoffAMSNetID = "local";
            this.sBeckhoffPortNo = "851";
        }
    }

}
