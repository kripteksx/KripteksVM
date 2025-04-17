namespace KripteksVM.Concrete
{
    public class ControllerSettings
    {
        public string controllerType;
        public int cycleTime;
        public ControllerBeckhoff controllerBeckhoff;
        public ControllerModbusTCP controllerModbusTCP;
        public ControllerSettings()
        {
            this.controllerType = "Beckhoff";
            this.cycleTime = 100;
            this.controllerBeckhoff = new ControllerBeckhoff();
            this.controllerModbusTCP = new ControllerModbusTCP();
        }

        public class ControllerBeckhoff
        {
            public string AMSNetID;
            public string portNo;
            public ControllerBeckhoff()
            {
                this.AMSNetID = "local";
                this.portNo = "851";
            }

        }
        public class ControllerModbusTCP
        {
            public string IPAddress;
            public int portNo;
            public bool isClient;
            public ControllerModbusTCP()
            {
                this.IPAddress = "127.0.0.1";
                this.portNo = 502;
                this.isClient = true;
            }
        }
    }
}
