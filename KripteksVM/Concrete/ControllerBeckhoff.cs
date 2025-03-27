using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;
using System.Drawing;
using KripteksVM.Concrete;
using System.Windows.Forms;

namespace KripteksVM.Concrete
{
    public class ControllerBeckhoff : IController
    {
        private General _general = General.GetInstance();
        private TcAdsClient _adsClient = new TcAdsClient();
        private int _retryCount = 0;
                
        #region public class
        public void Connect(ControllerSettings controllerSettings)
        {
            ControllerBeckhoffConnect(controllerSettings);
            _general.LogText(controllerSettings.controllerBeckhoff.AMSNetID + ":" + controllerSettings.controllerBeckhoff.portNo + " connected.");
            _general.LogText("Controller is " + controllerSettings.controllerType + ".");
        }
        public void Disconnect(ControllerSettings controllerSettings)
        {
            ControllerBeckhoffDisconnect();
            _general.LogText("Controller disconnected.");
        }
        public VirtualMachine Init(VirtualMachine virtualMachine)
        {
            virtualMachine.virtualApplication.CID = _general.CID();
            return virtualMachine;
        }
        public VirtualMachine RefreshVariables(VirtualMachine virtualMachine)
        {
            virtualMachine = _ControllerBeckhoffRefresh(virtualMachine);
            return virtualMachine;
        }
        public VirtualMachine GetComments(VirtualMachine virtualMachine)
        {
            virtualMachine = ControllerBeckhoffGetComments(virtualMachine);
            return virtualMachine;
        }
        #endregion

        #region beckhoff
        private VirtualMachine _ControllerBeckhoffRefresh(VirtualMachine virtualMachine)
        {
            try
            {
                // Beckhoff bagli ise degiskenleri guncelle
                if (_adsClient.IsConnected)
                {
                    virtualMachine.controllerStatus.isConnnected = true;

                    // live bit formda gostermek icin
                    int ihboControllerToApiLive = _adsClient.CreateVariableHandle("KVM.gstKVM.stStatus.boLive");
                    virtualMachine.controllerStatus.isLive = (System.Boolean)_adsClient.ReadAny(ihboControllerToApiLive, typeof(System.Boolean));
                                       
                    int ihboApiToControllerLive = _adsClient.CreateVariableHandle("KVM.gstKVM.stStatus.boAppLive");
                    _adsClient.WriteAny(ihboApiToControllerLive, virtualMachine.controllerStatus.isLive);

                    int ihdElapsedTime = _adsClient.CreateVariableHandle("KVM.gstKVM.stStatus.lrElapsedTimeSec");
                    virtualMachine.controllerStatus.elapsedTime = _general.FloatingPoint((double)_adsClient.ReadAny(ihdElapsedTime, typeof(double)), 2);


                    // session id
                    int ihwControllerToApiSID = _adsClient.CreateVariableHandle("KVM.gstKVM.stApp.wSID");
                    virtualMachine.virtualApplication.SID = ((UInt16)_adsClient.ReadAny(ihwControllerToApiSID, typeof(UInt16))).ToString();

                    // application id
                    int ihwControllerToApiAID = _adsClient.CreateVariableHandle("KVM.gstKVM.stApp.wAID");
                    virtualMachine.virtualApplication.AID = ((UInt16)_adsClient.ReadAny(ihwControllerToApiAID, typeof(UInt16))).ToString();

                    // controller id
                    int ihwApiToControllerCID = _adsClient.CreateVariableHandle("KVM.gstKVM.stApp.sCID");
                    _adsClient.WriteAny(ihwApiToControllerCID, virtualMachine.virtualApplication.CID, new int[] { 8 });

                    // degiskenler guncelleniyor
                    // word
                    int ihwCAx = _adsClient.CreateVariableHandle("KVM.gstKVM.stCA.wCA");
                    virtualMachine.controllerToApplicationVariables.wordArray = (UInt16[])_adsClient.ReadAny(ihwCAx, typeof(UInt16[]), new int[] { Constants.WordArraySize });

                    int ihwACx = _adsClient.CreateVariableHandle("KVM.gstKVM.stAC.wAC");
                    _adsClient.WriteAny(ihwACx, virtualMachine.applicationToControllerVariables.wordArray);

                    // double
                    int ihdCAx = _adsClient.CreateVariableHandle("KVM.gstKVM.stCA.lrCA");
                    virtualMachine.controllerToApplicationVariables.doubleArray = (double[])_adsClient.ReadAny(ihdCAx, typeof(double[]), new int[] { Constants.DoubleArraySize });

                    int ihdACx = _adsClient.CreateVariableHandle("KVM.gstKVM.stAC.lrAC");
                    _adsClient.WriteAny(ihdACx, virtualMachine.applicationToControllerVariables.doubleArray);

                    // bool
                    int ihboCAx = _adsClient.CreateVariableHandle("KVM.gstKVM.stCA.boCA");
                    virtualMachine.controllerToApplicationVariables.boolArray = (System.Boolean[])_adsClient.ReadAny(ihboCAx, typeof(System.Boolean[]), new int[] { Constants.BoolArraySize });

                    int ihboACx = _adsClient.CreateVariableHandle("KVM.gstKVM.stAC.boAC");
                    _adsClient.WriteAny(ihboACx, virtualMachine.applicationToControllerVariables.boolArray);

                    // controller live degiskenleri
                    virtualMachine.controllerStatus.liveCounter++;
                    if (virtualMachine.controllerStatus.liveCounter > 99) virtualMachine.controllerStatus.liveCounter = 0;
                }
                else
                {
                    virtualMachine.controllerStatus.isConnnected = false;
                    virtualMachine.controllerStatus.liveCounter = 0;
                }

                // ilk seferde baglantiyi koparmasin
                _retryCount = 0;
            }
            catch
            {
                _retryCount++;
                if (_retryCount > 100)
                {
                    // Deger guncellemede hata olusursa baglantiyi kopar
                    ControllerBeckhoffDisconnect();
                    virtualMachine.virtualApplication.AID = "";
                    virtualMachine.virtualApplication.SID = "";
                }
            }
            return virtualMachine;
        }
        private void ControllerBeckhoffConnect(ControllerSettings controllerProperties)
        {
            try
            {
                // Connect to local PLC - Runtime 1 - TwinCAT2 Port=801, TwinCAT3 Port=851
                _adsClient.Connect(controllerProperties.controllerBeckhoff.AMSNetID, int.Parse(controllerProperties.controllerBeckhoff.portNo));
                //adsClient.Connect("192.168.1.102.1.1", 851);
                _adsClient.ReadState();
            }
            catch
            {
                //stKVM.stStatus.wLiveCounter = 0;
                //stKVM.stApp.sAID = "";
                //stKVM.stApp.sSID = "";
            }
        }
        private void ControllerBeckhoffDisconnect()
        {
            if (_adsClient.IsConnected)
            {
                _adsClient.Disconnect();
            }
        }
        private VirtualMachine ControllerBeckhoffGetComments(VirtualMachine virtualMachine)
        {
            try
            {
                // Beckhoff bagli ise degiskenleri guncelle
                if (_adsClient.IsConnected)
                {
                    // app info
                    int hsName = _adsClient.CreateVariableHandle("KVM.gstKVM.stApp.sName");
                    virtualMachine.virtualApplication.name = (System.String)_adsClient.ReadAny(hsName, typeof(System.String), new int[] { 63 }).ToString();

                    int hsInfo =_adsClient.CreateVariableHandle("KVM.gstKVM.stApp.sInfo");
                    virtualMachine.virtualApplication.info = (System.String)_adsClient.ReadAny(hsInfo, typeof(System.String), new int[] { 255 }).ToString();


                    // double
                    int[] hsdCA = new int[Constants.DoubleArraySize];
                    int[] hsdAC = new int[Constants.DoubleArraySize];

                    for (int i = 0; i < Constants.DoubleArraySize; i++)
                    {
                        hsdCA[i] = _adsClient.CreateVariableHandle("KVM.gstKVM.stCA.slrCAComments[" + i.ToString() + "]");
                        virtualMachine.controllerToApplicationVariables.doubleArrayComments[i] = (System.String)_adsClient.ReadAny(hsdCA[i], typeof(System.String), new int[] { 30 }).ToString();

                        hsdAC[i] = _adsClient.CreateVariableHandle("KVM.gstKVM.stAC.slrACComments[" + i.ToString() + "]");
                        virtualMachine.applicationToControllerVariables.doubleArrayComments[i] = (System.String)_adsClient.ReadAny(hsdAC[i], typeof(System.String), new int[] { 30 }).ToString();
                    }

                    // word
                    int[] hswCA = new int[Constants.WordArraySize];
                    int[] hswAC = new int[Constants.WordArraySize];

                    for (int i = 0; i < Constants.WordArraySize; i++)
                    {
                        hswCA[i] = _adsClient.CreateVariableHandle("KVM.gstKVM.stCA.swCAComments[" + i.ToString() + "]");
                        virtualMachine.controllerToApplicationVariables.wordArrayComments[i] = (System.String)_adsClient.ReadAny(hswCA[i], typeof(System.String), new int[] { 30 }).ToString();

                        hswAC[i] = _adsClient.CreateVariableHandle("KVM.gstKVM.stAC.swACComments[" + i.ToString() + "]");
                        virtualMachine.applicationToControllerVariables.wordArrayComments[i] = (System.String)_adsClient.ReadAny(hswAC[i], typeof(System.String), new int[] { 30 }).ToString();
                    }

                    // bool
                    int[] hsboCA = new int[Constants.BoolArraySize];
                    int[] hsboAC = new int[Constants.BoolArraySize];

                    for (int i = 0; i < Constants.BoolArraySize; i++)
                    {
                        hsboCA[i] = _adsClient.CreateVariableHandle("KVM.gstKVM.stCA.sboCAComments[" + i.ToString() + "]");
                        virtualMachine.controllerToApplicationVariables.boolArrayComments[i] = (System.String)_adsClient.ReadAny(hsboCA[i], typeof(System.String), new int[] { 30 }).ToString();

                        hsboAC[i] = _adsClient.CreateVariableHandle("KVM.gstKVM.stAC.sboACComments[" + i.ToString() + "]");
                        virtualMachine.applicationToControllerVariables.boolArrayComments[i] = (System.String)_adsClient.ReadAny(hsboAC[i], typeof(System.String), new int[] { 30 }).ToString();
                    }
                }
            }
            catch
            {

            }
            return virtualMachine;
        }

        #endregion

    }

}
