using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KripteksVM.Concrete
{
    interface IController
    {
        void Connect(ControllerSettings controllerProperties);
        void Disconnect(ControllerSettings controllerProperties);
        VirtualMachine Init(VirtualMachine virtualMachine);
        VirtualMachine RefreshVariables(VirtualMachine virtualMachine);
        VirtualMachine GetComments(VirtualMachine virtualMachine);
    }
}
