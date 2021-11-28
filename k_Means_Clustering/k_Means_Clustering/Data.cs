using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_Means_Clustering
{
    class Data
    {
        public double[][] rawData = new double[10][];
        public Data()
        {
            rawData[0] = new double[] { 2.0, 4.0 };
            rawData[1] = new double[] { 5.0, 5.0 };
            rawData[2] = new double[] { 10.0, 20.0 };
            rawData[3] = new double[] { 18.0, 9.0 };
            rawData[4] = new double[] { 2.0, 9.0 };
            rawData[5] = new double[] { 16.0, 20.0 };
            rawData[6] = new double[] { 5.0, 10.0 };
            rawData[7] = new double[] { 15.0, 10.0 };
            rawData[8] = new double[] { 10.0, 19.0 };
            rawData[9] = new double[] { 20.0, 10.0 };
        }
    }
}
