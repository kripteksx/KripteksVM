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
        public ControllerSettings()
        {
            this.controllerType = "Beckhoff";
            this.cycleTime = 100;
            this.controllerBeckhoff = new ControllerBeckhoff();
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
    }
}
