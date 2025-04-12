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
