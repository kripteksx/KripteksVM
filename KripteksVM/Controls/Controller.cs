using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;
using System.Drawing;
using KripteksVM.Controls;

namespace KripteksVM.Controls
{
    public class Controller
    {
        // controllerden cek
        public bool boFirstCycle = false;
        public int iRetryCount = 0;

        // guncellenen degiskenler
        public ControlClass.ST_KVM stKVM = new ControlClass.ST_KVM();

        // beckhoff controller icin
        private TcAdsClient adsClient = new TcAdsClient();

        // controller tanimlama
        public ST_CONTROLLER_PROPERTIES stControllerProperties = new ST_CONTROLLER_PROPERTIES();
        private static System.Timers.Timer tmrController = new System.Timers.Timer();


        // ilgili buton ve labeller
        public bool boConnectControllerVisible = true;
        public bool boDisconnectControllerVisible = false;
        public Color colorControllerStatus = Color.Red;
        
        public void fbInit()
        {
            fbCID();
            fbConnect();

            // controller degisken guncelle
            tmrController.Elapsed += new System.Timers.ElapsedEventHandler(tmrController_Tick);
            tmrController.Interval = 100;
            tmrController.Enabled = true;
            tmrController.AutoReset = true;

            
        }

        private void fbCID()
        {
            Random rndNo = new Random();
            for (int i = 0; i <= 7; i++)
                if (i == 0)
                    stKVM.stApp.sCID = stKVM.stApp.sCID + rndNo.Next(1, 9);
                else
                    stKVM.stApp.sCID = stKVM.stApp.sCID + rndNo.Next(0, 9);

        }

        #region beckhoff
        private void fbControllerBeckhoffRefresh()
        {
            try
            {
                // Beckhoff bagli ise degiskenleri guncelle
                if (adsClient.IsConnected)
                {
                    // live bit formda gostermek icin
                    int ihboControllerToApiLive = adsClient.CreateVariableHandle("KVM.gstKVM.stStatus.boLive");
                    stKVM.stStatus.boLive = (System.Boolean)adsClient.ReadAny(ihboControllerToApiLive, typeof(System.Boolean));

                    if (stKVM.stStatus.boLive)
                        colorControllerStatus = Color.Green;
                    else
                        colorControllerStatus = Color.Red;


                    int ihboApiToControllerLive = adsClient.CreateVariableHandle("KVM.gstKVM.stStatus.boAppLive");
                    adsClient.WriteAny(ihboApiToControllerLive, stKVM.stStatus.boLive);

                    int ihdElapsedTime = adsClient.CreateVariableHandle("KVM.gstKVM.stStatus.lrElapsedTimeSec");
                    stKVM.stStatus.dElapsedTimeSec = fbFloatingPoint((double)adsClient.ReadAny(ihdElapsedTime, typeof(double)), 2);


                    // session id
                    int ihwControllerToApiSID = adsClient.CreateVariableHandle("KVM.gstKVM.stApp.wSID");
                    stKVM.stApp.sSID = ((UInt16)adsClient.ReadAny(ihwControllerToApiSID, typeof(UInt16))).ToString();

                    // application id
                    int ihwControllerToApiAID = adsClient.CreateVariableHandle("KVM.gstKVM.stApp.wAID");
                    stKVM.stApp.sAID = ((UInt16)adsClient.ReadAny(ihwControllerToApiAID, typeof(UInt16))).ToString();

                    // controller id
                    int ihwApiToControllerCID = adsClient.CreateVariableHandle("KVM.gstKVM.stApp.sCID");
                    adsClient.WriteAny(ihwApiToControllerCID, stKVM.stApp.sCID, new int[] { 8 });

                    // degiskenler guncelleniyor
                    // word
                    int ihwCAx = adsClient.CreateVariableHandle("KVM.gstKVM.stCA.wCA");
                    stKVM.stCA.wCA = (UInt16[])adsClient.ReadAny(ihwCAx, typeof(UInt16[]), new int[] { ControlClass.iWordSize });

                    int ihwACx = adsClient.CreateVariableHandle("KVM.gstKVM.stAC.wAC");
                    if (boFirstCycle) stKVM.stAC.wAC = (UInt16[])adsClient.ReadAny(ihwACx, typeof(UInt16[]), new int[] { ControlClass.iWordSize });
                    else adsClient.WriteAny(ihwACx, stKVM.stAC.wAC);

                    // double
                    int ihdCAx = adsClient.CreateVariableHandle("KVM.gstKVM.stCA.lrCA");
                    stKVM.stCA.dCA = (double[])adsClient.ReadAny(ihdCAx, typeof(double[]), new int[] { ControlClass.iDoubleSize });

                    int ihdACx = adsClient.CreateVariableHandle("KVM.gstKVM.stAC.lrAC");
                    if (boFirstCycle) stKVM.stAC.dAC = (double[])adsClient.ReadAny(ihdACx, typeof(double[]), new int[] { ControlClass.iDoubleSize });
                    else adsClient.WriteAny(ihdACx, stKVM.stAC.dAC);

                    // bool
                    int ihboCAx = adsClient.CreateVariableHandle("KVM.gstKVM.stCA.boCA");
                    stKVM.stCA.boCA = (System.Boolean[])adsClient.ReadAny(ihboCAx, typeof(System.Boolean[]), new int[] { ControlClass.iBoolSize });

                    int ihboACx = adsClient.CreateVariableHandle("KVM.gstKVM.stAC.boAC");
                    if (boFirstCycle) adsClient.WriteAny(ihboACx, stKVM.stAC.boAC);
                    else stKVM.stAC.boAC = (System.Boolean[])adsClient.ReadAny(ihboACx, typeof(System.Boolean[]), new int[] { ControlClass.iBoolSize });

                    boFirstCycle = true;


                    boConnectControllerVisible = false;
                    boDisconnectControllerVisible = true;
                    if (colorControllerStatus == Color.Green) colorControllerStatus = Color.Red;
                    else colorControllerStatus = Color.Green;

                    // controller live degiskenleri
                    stKVM.stStatus.wLiveCounter++;
                    if (stKVM.stStatus.wLiveCounter > 99) stKVM.stStatus.wLiveCounter = 0;
                }
                else
                {

                    boConnectControllerVisible = true;
                    boDisconnectControllerVisible = false;
                    colorControllerStatus = Color.Red;

                    stKVM.stStatus.wLiveCounter = 0;
                }


                // ilk seferde baglantiyi koparmasin
                iRetryCount = 0;
            }
            catch
            {
                iRetryCount++;
                if (iRetryCount > 100)
                {
                    // Deger guncellemede hata olusursa baglantiyi kopar
                    fbControllerBeckhoffDisconnect();
                }
            }
        }
        private void fbControllerBeckhoffConnect()
        {
            try
            {
                // Connect to local PLC - Runtime 1 - TwinCAT2 Port=801, TwinCAT3 Port=851
                adsClient.Connect(stControllerProperties.stControllerBeckhoff.sBeckhoffAMSNetID, int.Parse(stControllerProperties.stControllerBeckhoff.sBeckhoffPortNo));
                //adsClient.Connect("192.168.1.102.1.1", 851);
                adsClient.ReadState();
            }
            catch
            {
            }
        }
        private void fbControllerBeckhoffDisconnect()
        {
            if (adsClient.IsConnected)
            {
                adsClient.Disconnect();
            }
        }
        public void fbControllerBeckhoffGetComments()
        {
            try
            {
                // Beckhoff bagli ise degiskenleri guncelle
                if (adsClient.IsConnected)
                {
                    // app info
                    int ihsName = adsClient.CreateVariableHandle("KVM.gstKVM.stApp.sName");
                    stKVM.stApp.sName = (System.String)adsClient.ReadAny(ihsName, typeof(System.String), new int[] { 63 }).ToString();

                    int ihsInfo = adsClient.CreateVariableHandle("KVM.gstKVM.stApp.sInfo");
                    stKVM.stApp.sInfo = (System.String)adsClient.ReadAny(ihsInfo, typeof(System.String), new int[] { 255 }).ToString();


                    // double
                    int[] ihsdCA = new int[ControlClass.iDoubleSize];
                    int[] ihsdAC = new int[ControlClass.iDoubleSize];

                    for (int i = 0; i < ControlClass.iDoubleSize; i++)
                    {
                        ihsdCA[i] = adsClient.CreateVariableHandle("KVM.gstKVM.stCA.slrCAComments[" + i.ToString() + "]");
                        stKVM.stCA.sdCAComments[i] = (System.String)adsClient.ReadAny(ihsdCA[i], typeof(System.String), new int[] { 30 }).ToString();

                        ihsdAC[i] = adsClient.CreateVariableHandle("KVM.gstKVM.stAC.slrACComments[" + i.ToString() + "]");
                        stKVM.stAC.sdACComments[i] = (System.String)adsClient.ReadAny(ihsdAC[i], typeof(System.String), new int[] { 30 }).ToString();
                    }

                    // word
                    int[] ihswCA = new int[ControlClass.iWordSize];
                    int[] ihswAC = new int[ControlClass.iWordSize];

                    for (int i = 0; i < ControlClass.iWordSize; i++)
                    {
                        ihswCA[i] = adsClient.CreateVariableHandle("KVM.gstKVM.stCA.swCAComments[" + i.ToString() + "]");
                        stKVM.stCA.swCAComments[i] = (System.String)adsClient.ReadAny(ihswCA[i], typeof(System.String), new int[] { 30 }).ToString();

                        ihswAC[i] = adsClient.CreateVariableHandle("KVM.gstKVM.stAC.swACComments[" + i.ToString() + "]");
                        stKVM.stAC.swACComments[i] = (System.String)adsClient.ReadAny(ihswAC[i], typeof(System.String), new int[] { 30 }).ToString();
                    }

                    // bool
                    int[] ihsboCA = new int[ControlClass.iBoolSize];
                    int[] ihsboAC = new int[ControlClass.iBoolSize];

                    for (int i = 0; i < ControlClass.iBoolSize; i++)
                    {
                        ihsboCA[i] = adsClient.CreateVariableHandle("KVM.gstKVM.stCA.sboCAComments[" + i.ToString() + "]");
                        stKVM.stCA.sboCAComments[i] = (System.String)adsClient.ReadAny(ihsboCA[i], typeof(System.String), new int[] { 30 }).ToString();

                        ihsboAC[i] = adsClient.CreateVariableHandle("KVM.gstKVM.stAC.sboACComments[" + i.ToString() + "]");
                        stKVM.stAC.sboACComments[i] = (System.String)adsClient.ReadAny(ihsboAC[i], typeof(System.String), new int[] { 30 }).ToString();
                    }
                }
            }
            catch
            {

            }
        }

        public double fbFloatingPoint(double dValue, int iFloating)
        {
            double dMul = 0;
            double dReturn = 0;

            dMul = Math.Pow(10, iFloating);
            dValue = dValue * dMul;
            Int32 diValue = Convert.ToInt32(dValue);
            dReturn = Convert.ToDouble(diValue);
            dReturn = dReturn / dMul;

            return dReturn;
        }
        #endregion

        public void fbConnect()
        {
            if (stControllerProperties.sControllerType == "Beckhoff")
            {
                fbControllerBeckhoffConnect();
            }
            else if (stControllerProperties.sControllerType == "Arduino")
            {

            }
        }

        public void fbDisconnect()
        {
            if (stControllerProperties.sControllerType == "Beckhoff")
            {
                fbControllerBeckhoffDisconnect();
            }
            else if (stControllerProperties.sControllerType == "Arduino")
            {

            }
        }

        private void tmrController_Tick(object sender, EventArgs e)
        {
            if (stControllerProperties.sControllerType == "Beckhoff")
            {
                fbControllerBeckhoffRefresh();
            }
            else if (stControllerProperties.sControllerType == "Arduino")
            {

            }
        }

    }

}
