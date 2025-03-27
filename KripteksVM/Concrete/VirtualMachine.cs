using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KripteksVM.Concrete
{
    public class VirtualMachine
    {
        public VirtualMachineStatus controllerStatus = new VirtualMachineStatus();
        public VirtualMachineApplication virtualApplication = new VirtualMachineApplication();
        public VirtrualMachineVariables controllerToApplicationVariables = new VirtrualMachineVariables();
        public VirtrualMachineVariables applicationToControllerVariables = new VirtrualMachineVariables();
    }
}
