using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KripteksVM.Concrete
{
    public class VirtualMachineStatus
    {
        public bool isLive;
        public bool isConnnected;
        public bool isAppLive;
        public bool isWebLive;
        public double elapsedTime;
        public UInt16 liveCounter;

        public VirtualMachineStatus()
        {
            this.isLive = false;
            this.isConnnected = false;
            this.isAppLive = false;
            this.isWebLive = false;
            this.elapsedTime = 0;
            this.liveCounter = 0;
        }
    }
}
