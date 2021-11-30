using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_Means_Clustering
{
    class Data
    {
        Random _rnd;
        public Data()
        {
            RawData[0] = new double[] { 2.0, 4.0 };
            RawData[1] = new double[] { 5.0, 5.0 };
            RawData[2] = new double[] { 10.0, 20.0 };
            RawData[3] = new double[] { 18.0, 9.0 };
            RawData[4] = new double[] { 2.0, 9.0 };
            RawData[5] = new double[] { 16.0, 20.0 };
            RawData[6] = new double[] { 5.0, 10.0 };
            RawData[7] = new double[] { 15.0, 10.0 };
            RawData[8] = new double[] { 10.0, 19.0 };
            RawData[9] = new double[] { 20.0, 10.0 };
            _rnd = new Random();
        }
        public double[][] RawData { get; } = new double[10][];
        public int[] ClustersRandomizer(int numOfClusters)
        {
            int[] _clustering = new int[RawData.Length];
            int[] clust = new int[numOfClusters];
            for (int i = 0; i < _clustering.Length; i++)
            {
                _clustering[i] = _rnd.Next(0, numOfClusters);
                clust[_clustering[i]]++;
            }
            if (clust.Contains(0))
            {
                ClustersRandomizer(numOfClusters);
            }
            return _clustering;
        }
    }
}
