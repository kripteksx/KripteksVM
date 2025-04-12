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
