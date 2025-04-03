using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KripteksVM.Concrete
{
    public class DataGridViewVariables : IDataGridViewVariables
    {
        public void DataGripViewRefresh(DataGridView dgv, UInt16[] w, bool[] isForced)
        {
            for (int i = 0; i < w.Length; i++)
            {
                if (Convert.ToBoolean(dgv.Rows[i].Cells[2].Value) == true)
                {
                    dgv.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    w[i] = Convert.ToUInt16(dgv.Rows[i].Cells[1].EditedFormattedValue);
                    isForced[i] = true;
                }
                else
                {
                    dgv.Rows[i].Cells[1].Style.BackColor = Color.White;
                    dgv.Rows[i].Cells[1].Value = w[i].ToString();
                    isForced[i] = false;
                }
            }
        }
        public void DataGripViewRefresh(DataGridView dgv, double[] d, bool[] isForced)
        {
            for (int i = 0; i < d.Length; i++)
            {
                if (Convert.ToBoolean(dgv.Rows[i].Cells[2].Value) == true)
                {
                    dgv.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    d[i] = Convert.ToDouble(dgv.Rows[i].Cells[1].EditedFormattedValue);
                    isForced[i] = true;
                }
                else
                {
                    dgv.Rows[i].Cells[1].Style.BackColor = Color.White;
                    dgv.Rows[i].Cells[1].Value = d[i].ToString();
                    isForced[i] = false;
                }
            }
        }
        public void DataGripViewRefresh(DataGridView dgv, bool[] bo, bool[] isForced)
        {
            for (int i = 0; i < bo.Length; i++)
            {
                if (Convert.ToBoolean(dgv.Rows[i].Cells[2].Value) == true)
                {
                    isForced[i] = true;
                    dgv.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    if (dgv.Rows[i].Cells[1].EditedFormattedValue.ToString() == "1")
                        bo[i] = true;
                    else if (dgv.Rows[i].Cells[1].EditedFormattedValue.ToString() == "0")
                        bo[i] = false;

                }
                else
                {
                    isForced[i] = false;
                    dgv.Rows[i].Cells[1].Style.BackColor = Color.White;
                    if (bo[i])
                        dgv.Rows[i].Cells[1].Value = "1";
                    else
                        dgv.Rows[i].Cells[1].Value = "0";
                }
            }
        }
        public void DataGridViewInit(DataGridView dgv, DataGridViewVariableDirection dgvVariableDirection, DataGridViewVariableType dgvVariableType, VirtualMachine virtualMachine)
        {
            dgv.Rows.Clear();
            if (dgvVariableDirection == DataGridViewVariableDirection.ControllerToApplication)
            {
                if (dgvVariableType == DataGridViewVariableType.Word)
                {
                    for (int i = 0; i < Constants.WordArraySize; i++)
                    {
                        dgv.Rows.Add("wAW[" + i + "]", virtualMachine.controllerToApplicationVariables.wordArrayBuff[i], virtualMachine.controllerToApplicationVariables.isWordArrayForced[i], "word", virtualMachine.controllerToApplicationVariables.wordArrayComments[i]);
                    }
                }
                else if (dgvVariableType == DataGridViewVariableType.Double)
                {
                    for (int i = 0; i < Constants.DoubleArraySize; i++)
                    {
                        dgv.Rows.Add("dAW[" + i + "]", virtualMachine.controllerToApplicationVariables.doubleArrayBuff[i], virtualMachine.controllerToApplicationVariables.isDoubleArrayForced[i], "double", virtualMachine.controllerToApplicationVariables.doubleArrayComments[i]);
                    }
                }
                else if (dgvVariableType == DataGridViewVariableType.Bool)
                {
                    for (int i = 0; i < Constants.BoolArraySize; i++)
                    {
                        dgv.Rows.Add("boAW[" + i + "]", BoolToInt(virtualMachine.controllerToApplicationVariables.boolArrayBuff[i]), virtualMachine.controllerToApplicationVariables.isBoolArrayForced[i], "bool", virtualMachine.controllerToApplicationVariables.boolArrayComments[i]);
                    }
                }
            }
            else if (dgvVariableDirection == DataGridViewVariableDirection.ApplicationToController)
            {
                if (dgvVariableType == DataGridViewVariableType.Word)
                {
                    for (int i = 0; i < Constants.WordArraySize; i++)
                    {
                        dgv.Rows.Add("wWA[" + i + "]", virtualMachine.applicationToControllerVariables.wordArrayBuff[i], virtualMachine.applicationToControllerVariables.isWordArrayForced[i], "word", virtualMachine.applicationToControllerVariables.wordArrayComments[i]);
                    }
                }
                else if (dgvVariableType == DataGridViewVariableType.Double)
                {
                    for (int i = 0; i < Constants.DoubleArraySize; i++)
                    {
                        dgv.Rows.Add("dWA[" + i + "]", virtualMachine.applicationToControllerVariables.doubleArrayBuff[i], virtualMachine.applicationToControllerVariables.isDoubleArrayForced[i], "double", virtualMachine.applicationToControllerVariables.doubleArrayComments[i]);
                    }
                }
                else if (dgvVariableType == DataGridViewVariableType.Bool)
                {
                    for (int i = 0; i < Constants.BoolArraySize; i++)
                    {
                        dgv.Rows.Add("boWA[" + i + "]", BoolToInt(virtualMachine.applicationToControllerVariables.boolArrayBuff[i]), virtualMachine.applicationToControllerVariables.isBoolArrayForced[i], "bool", virtualMachine.applicationToControllerVariables.boolArrayComments[i]);
                    }
                }
            }
        }
        private int BoolToInt(bool bo)
        {
            int boolToInt = 0;
            if (bo) boolToInt = 1;
            return boolToInt;
        }
        public void DataGridViewForced(VirtualMachine virtualMachine)
        {
            for (int i = 0; i < Constants.DoubleArraySize; i++)
            {
                if (!virtualMachine.controllerToApplicationVariables.isDoubleArrayForced[i]) virtualMachine.controllerToApplicationVariables.doubleArrayBuff[i] = virtualMachine.controllerToApplicationVariables.doubleArray[i];
                if (!virtualMachine.applicationToControllerVariables.isDoubleArrayForced[i]) virtualMachine.applicationToControllerVariables.doubleArray[i] = virtualMachine.applicationToControllerVariables.doubleArrayBuff[i];
            }
            for (int i = 0; i < Constants.WordArraySize; i++)
            {
                if (!virtualMachine.controllerToApplicationVariables.isWordArrayForced[i]) virtualMachine.controllerToApplicationVariables.wordArrayBuff[i] = virtualMachine.controllerToApplicationVariables.wordArray[i];
                if (!virtualMachine.applicationToControllerVariables.isWordArrayForced[i]) virtualMachine.applicationToControllerVariables.wordArray[i] = virtualMachine.applicationToControllerVariables.wordArrayBuff[i];
            }
            for (int i = 0; i < Constants.BoolArraySize; i++)
            {
                if (!virtualMachine.controllerToApplicationVariables.isBoolArrayForced[i]) virtualMachine.controllerToApplicationVariables.boolArrayBuff[i] = virtualMachine.controllerToApplicationVariables.boolArray[i];
                if (!virtualMachine.applicationToControllerVariables.isBoolArrayForced[i]) virtualMachine.applicationToControllerVariables.boolArray[i] = virtualMachine.applicationToControllerVariables.boolArrayBuff[i];
            }
        }
      
    }
}
