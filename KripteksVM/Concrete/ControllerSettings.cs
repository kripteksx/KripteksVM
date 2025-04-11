using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KripteksVM.Concrete
{
    public class ControllerSettings
    {
        public string controllerType;
        public int cycleTime;
        public ControllerBeckhoff controllerBeckhoff;
        public ControllerModbus controllerModbus;
        public ControllerSettings()
        {
            this.controllerType = "Beckhoff";
            this.cycleTime = 100;
            this.controllerBeckhoff = new ControllerBeckhoff();
            this.controllerModbus = new ControllerModbus();
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
        public class ControllerModbus
        {
            public string IPAddress;
            public int portNo;
            public bool isClient;
            public ControllerModbus()
            {
                this.IPAddress = "127.0.0.1";
                this.portNo = 502;
                this.isClient = true;
            }
        }
    }
}
