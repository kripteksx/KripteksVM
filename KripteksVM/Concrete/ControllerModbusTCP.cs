using ModbusTCP;
using System;
using System.Collections;
using System.Linq;

namespace KripteksVM.Concrete
{
    public class ControllerModbusTCP : IController
    {
        private General _general = General.GetInstance();
        private ModbusTCP.Master modbusTCPClient;
        private VirtualMachine _virtualMachine = new VirtualMachine();
        private int _retryCount = 0;
        public void Connect(ControllerSettings controllerSettings)
        {
            ControllerModbusConnect(controllerSettings);
        }
        public void Disconnect(ControllerSettings controllerSettings)
        {
            ControllerModbusDisconnect();
        }
        public VirtualMachine Init(VirtualMachine virtualMachine)
        {
            virtualMachine.virtualApplication.SID = _general.SID();
            return virtualMachine;
        }
        private byte[] GetData(Int16[] _int16)
        {
            byte[] bytes = new byte[_int16.Length * 2];
            for (int i = 0; i < _int16.Length; i++)
            {
                UInt16 uint16;
                if (_int16[i] < 0) uint16 = Convert.ToUInt16(Convert.ToInt32(_int16[i] + 65536));
                else uint16 = Convert.ToUInt16(_int16[i]);
                bytes[i * 2] = Convert.ToByte(uint16 / 256);
                bytes[i * 2 + 1] = Convert.ToByte(uint16 % 256);
            }
            return bytes;
        }
        private byte[] GetData(double[] _double)
        {
            byte[] bytes = new byte[_double.Length * 2];
            for (int i = 0; i < _double.Length; i++)
            {
                UInt16 uint16;
                double _doubleHelp = _double[i] * 10;
                if (_doubleHelp > 32767) _doubleHelp = 32767;
                if (_doubleHelp < -32768) _doubleHelp = -32768;
                if (_doubleHelp < 0) uint16 = Convert.ToUInt16(Convert.ToInt32(_doubleHelp + 65536));
                else uint16 = Convert.ToUInt16(_doubleHelp);
                bytes[i * 2] = Convert.ToByte(uint16 / 256);
                bytes[i * 2 + 1] = Convert.ToByte(uint16 % 256);
            }
            return bytes;
        }
        private byte ConvertToByte(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }
        public VirtualMachine RefreshVariables(VirtualMachine virtualMachine)
        {
            try
            {
                if (modbusTCPClient != null)
                {
                    if (modbusTCPClient.connected)
                    {
                        virtualMachine.controllerStatus.isConnnected = true;

                        //modbusClient.ReadDiscreteInputs(2, 0, 0, 32);
                        //bitleri word tarafina tasidik
                        modbusTCPClient.ReadInputRegister(4, 0, 0, 20);


                        // gonderilen 
                        byte[] data = new byte[40];

                        // word
                        byte[] dataWord = GetData(virtualMachine.applicationToControllerVariables.wordArray);
                        for (int i = 0; i < Constants.WordArraySize * 2; i++)
                        {
                            data[i] = dataWord[i];
                        }

                        // double
                        byte[] dataDouble = GetData(virtualMachine.applicationToControllerVariables.doubleArray);
                        for (int i = 0; i < Constants.DoubleArraySize * 2; i++)
                        {
                            data[16 + i] = dataDouble[i];
                        }

                        // bits
                        for (int i = 0; i < 4; i++)
                        {
                            bool[] bpBit = new bool[8];

                            for (int j = 0; j < 8; j++)
                            {
                                bpBit[j] = virtualMachine.applicationToControllerVariables.boolArray[i * 8 + j];
                            }
                            BitArray bitArray = new BitArray(bpBit);
                            data[32 + i] = ConvertToByte(bitArray);
                        }

                        modbusTCPClient.WriteMultipleRegister(8, 0, 20, data);

                        // onceki cevrimden guncellenen
                        virtualMachine.controllerToApplicationVariables = _virtualMachine.controllerToApplicationVariables;
                        virtualMachine.virtualApplication.AID = _virtualMachine.virtualApplication.AID;
                        virtualMachine.virtualApplication.CID = _virtualMachine.virtualApplication.CID;
                        virtualMachine.controllerStatus.isLive = _virtualMachine.controllerStatus.isLive;

                        // controller live degiskenleri
                        virtualMachine.controllerStatus.liveCounter++;
                        if (virtualMachine.controllerStatus.liveCounter > 99) virtualMachine.controllerStatus.liveCounter = 0;
                    }
                    else
                    {
                        virtualMachine.controllerStatus.isConnnected = false;
                        virtualMachine.controllerStatus.liveCounter = 0;
                    }
                }
                else
                {
                    virtualMachine.controllerStatus.isConnnected = false;
                    virtualMachine.controllerStatus.liveCounter = 0;
                }

                _retryCount = 0;
            }
            catch
            {
                _retryCount++;
                if (_retryCount > 100)
                {
                    // Deger guncellemede hata olusursa baglantiyi kopar
                    ControllerModbusDisconnect();
                    virtualMachine.virtualApplication.AID = "";
                    virtualMachine.virtualApplication.CID = "";
                }
            }
            return virtualMachine;
        }
        public VirtualMachine GetComments(VirtualMachine virtualMachine)
        {
            //virtualMachine = ControllerBeckhoffGetComments(virtualMachine);
            return virtualMachine;
        }
        private void ControllerModbusDisconnect()
        {
            try
            {
                if (modbusTCPClient != null)
                {
                    if (modbusTCPClient.connected)
                    {
                        modbusTCPClient.disconnect();
                        _general.LogText("Controller disconnected.");
                        modbusTCPClient = null;
                    }
                    else
                    {
                        _general.LogText("Controller has been disconnected.");
                    }
                }
                else
                {
                    _general.LogText("Controller has been disconnected.");
                }
            }
            catch (Exception e)
            {
                _general.LogText(e.Message);
            }

        }
        private void ControllerModbusConnect(ControllerSettings controllerSettings)
        {
            try
            {
                modbusTCPClient = new Master(controllerSettings.controllerModbusTCP.IPAddress, Convert.ToUInt16(controllerSettings.controllerModbusTCP.portNo), true);
                modbusTCPClient.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);

                _general.LogText(controllerSettings.controllerModbusTCP.IPAddress + ":" + controllerSettings.controllerModbusTCP.portNo.ToString() + " connected.");
                _general.LogText("Controller is " + controllerSettings.controllerType + ".");
            }
            catch (Exception e)
            {
                _general.LogText(e.Message);
                _general.LogText("Controller could not connect.");
            }
        }
        private void MBmaster_OnResponseData(ushort ID, byte unit, byte function, byte[] values)
        {


            // ------------------------------------------------------------------------
            // Identify requested data
            switch (ID)
            {
                case 1:
                    //grpData.Text = "Read coils";
                    //data = values;
                    //ShowAs(null, null);
                    break;
                case 2:
                    //grpData.Text = "Read discrete inputs";
                    /*UInt32 ui = Convert.ToUInt32(Convert.ToUInt32(values[3]) +65536 * 256 + Convert.ToUInt32(values[2]) * 65536 + Convert.ToUInt32(values[1]) * 256 + Convert.ToUInt32(values[0]));
                    BitArray myBA = new BitArray(BitConverter.GetBytes(ui).ToArray());
                    for (int i = 0; i < Constants.BoolArraySize; i++)
                    {
                        _virtualMachine.controllerToApplicationVariables.boolArray[i] = myBA[i];
                    }*/
                    //grpData.Text = "Read discrete inputs";
                    //data = values;
                    //ShowAs(null, null);
                    break;
                case 3:
                    //grpData.Text = "Read holding register";
                    //data = values;
                    //ShowAs(null, null);
                    break;
                case 4:
                    //grpData.Text = "Read input register";
                    byte[] data = new byte[values.Length];
                    data = values;
                    int[] wordArray = new int[Constants.WordArraySize];
                    for (int i = 0; i < Constants.WordArraySize; i++)
                    {
                        wordArray[i] = data[i * 2] * 256 + data[i * 2 + 1];
                        if (wordArray[i] > 32767) wordArray[i] = wordArray[i] - 65536;
                        _virtualMachine.controllerToApplicationVariables.wordArray[i] = Convert.ToInt16(wordArray[i]);
                    }

                    int[] appArray = new int[2];
                    for (int i = 0; i < 2; i++)
                    {
                        appArray[i] = data[i * 2 + 36] * 256 + data[i * 2 + 36 + 1];
                    }

                    _virtualMachine.virtualApplication.AID = appArray[0].ToString();
                    _virtualMachine.virtualApplication.CID = appArray[1].ToString();


                    int[] doubleArray = new int[Constants.DoubleArraySize];
                    for (int i = 0; i < Constants.DoubleArraySize; i++)
                    {
                        doubleArray[i] = data[(i + Constants.WordArraySize) * 2] * 256 + data[(i + Constants.WordArraySize) * 2 + 1];
                        if (doubleArray[i] > 32767) doubleArray[i] = doubleArray[i] - 65536;
                        _virtualMachine.controllerToApplicationVariables.doubleArray[i] = Convert.ToDouble(doubleArray[i]) / 10;
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        int iHelp = i;
                        iHelp = iHelp % 2;
                        if (iHelp == 0) iHelp = i + 1;
                        else iHelp = i - 1;
                        BitArray myByte = new BitArray(BitConverter.GetBytes(data[32 + iHelp]).ToArray());
                        for (int j = 0; j < 8; j++)
                        {
                            _virtualMachine.controllerToApplicationVariables.boolArray[i * 8 + j] = myByte[j];
                        }
                    }
                    _virtualMachine.controllerStatus.isLive = _virtualMachine.controllerToApplicationVariables.boolArray[31];
                    break;
                case 5:
                    //grpData.Text = "Write single coil";
                    break;
                case 6:
                    //grpData.Text = "Write multiple coils";
                    break;
                case 7:
                    //grpData.Text = "Write single register";
                    break;
                case 8:
                    //grpData.Text = "Write multiple register";
                    break;
            }
        }
    }
}
