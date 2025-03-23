using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KripteksVM.Controls
{
    interface IController
    {
        string Init();
        string Connect();
        string Disconnect();
        void RefreshVar();
        string GetComments();
    }
}
