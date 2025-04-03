using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KripteksVM.Concrete
{
    interface IControllerSettingsFile
    {
        ControllerSettings GetControllerSettings();
        void SetControllerSettings(ControllerSettings controllerSettings);
    }
}
