namespace KripteksVM.Concrete
{
    interface IControllerSettingsFile
    {
        ControllerSettings GetControllerSettings();
        void SetControllerSettings(ControllerSettings controllerSettings);
    }
}
