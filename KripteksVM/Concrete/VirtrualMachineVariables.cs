using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KripteksVM.Concrete
{
    public class VirtrualMachineVariables
    {
        public double[] doubleArray = new double[Constants.DoubleArraySize];
        public UInt16[] wordArray = new UInt16[Constants.WordArraySize];
        public bool[] boolArray = new bool[Constants.BoolArraySize];

        public string[] doubleArrayComments = new string[Constants.DoubleArraySize];
        public string[] wordArrayComments = new string[Constants.WordArraySize];
        public string[] boolArrayComments = new string[Constants.BoolArraySize];
        public VirtrualMachineVariables()
        {
            for (int i = 0; i < Constants.DoubleArraySize; i++)
            {
                this.doubleArrayComments[i] = i.ToString();
                this.doubleArray[i] = 0.0;
            }
            for (int i = 0; i < Constants.WordArraySize; i++)
            {
                this.wordArrayComments[i] = i.ToString();
                this.wordArray[i] = 0;
            }
            for (int i = 0; i < Constants.BoolArraySize; i++)
            {
                this.boolArrayComments[i] = i.ToString();
                this.boolArray[i] = false;
            }
        }
    }
}
