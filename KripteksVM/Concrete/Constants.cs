using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KripteksVM.Concrete
{
    public static class Constants
    {
        public static readonly int BoolArraySize = 32;
        public static readonly int DoubleArraySize = 8;
        public static readonly int WordArraySize = 8;
        public static int MainPanelExplorerWidth = 300;
        public static string Host = "http://www.kripteks.net";
        //public static string Host = "http://localhost:56436";
    }
    public enum DataGridViewVariableDirection : int
    {
        None = 0,
        ControllerToApplication = 1,
        ApplicationToController = 2
    }
    public enum DataGridViewVariableType : int
    {
        None = 0,
        Word = 1,
        Double = 2,
        Bool = 3
    }
    public enum CameraNo : int
    {
        None = 0 ,
        Free = 1 ,
        Person = 2
    }

}
