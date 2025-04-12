using System;
using System.Windows.Forms;

namespace KripteksVM.Concrete
{
    interface IDataGridViewVariables
    {
        void DataGripViewRefresh(DataGridView dgv, Int16[] w, bool[] isForced);
        void DataGripViewRefresh(DataGridView dgv, double[] d, bool[] isForced);
        void DataGripViewRefresh(DataGridView dgv, bool[] bo, bool[] isForced);
        void DataGridViewInit(DataGridView dgv, DataGridViewVariableDirection dgvVariableDirection, DataGridViewVariableType dgvVariableType, VirtualMachine virtualMachine);
        void DataGridViewForced(VirtualMachine virtualMachine);


    }
}
