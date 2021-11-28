using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_Means_Clustering
{
    class Cluster
    {
        private int _numClusters;
        private int[] _clustering;
        private double[][] _centroids;
        private Random _rnd;
        public Cluster(int numClusters)
        {
            _numClusters = numClusters;
            _centroids = new double[numClusters][];
            _rnd = new Random();
        }
        public int[] Clusterer(double[][] data)
        {
            int rows = data.Length;
            int columns = data[0].Length;
            _clustering = new int[rows];

            for (int k = 0; k < _numClusters; k++)
            {
                _centroids[k] = new double[columns];
            }
            ClustersRandomizer(_numClusters);

            Console.WriteLine("\nInit random clustering:");
            for (int i = 0; i < _clustering.Length; i++)
            {
                Console.Write(_clustering[i] + " ");
            }
            Console.WriteLine();

            bool changeInClustering = true;
            int maxCount = rows * 10; //to avoid oscillations
            int ct = 0;
            
            while (changeInClustering == true && ct < maxCount)
            {
                ++ct;
                UpdateCentroids(data, _clustering, _numClusters);
                changeInClustering = UpdateClustering(data);
            }
            int[] result = new int[rows];

            Console.WriteLine("\nClustering after:");
            for (int i = 0; i < _clustering.Length; i++)
            {
                Console.Write(_clustering[i] + " ");
            }
            Console.WriteLine();


            Array.Copy(_clustering, result, _clustering.Length);
            return result;

        }

        private void ClustersRandomizer(int numOfClusters)
        {
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
        }
        private void UpdateCentroids(double[][] data, int[] clustersArray, int num)
        {
            for (int i = 0; i < num; i++)
            {
                _centroids[i] = new double[] { 0.0, 0.0 };
            }

            int[] counts = new int[_centroids.Length];
            for (int i = 0; i < data.Length; i++)
            {
                if (_centroids[clustersArray[i]][0].Equals(0.0))
                {
                    _centroids[clustersArray[i]] = data[i];
                    counts[clustersArray[i]]++;
                    continue;
                }
                counts[clustersArray[i]]++;
                for (int j = 0; j < data[i].Length; j++)
                {
                    _centroids[clustersArray[i]][j] = (_centroids[clustersArray[i]][j] * (((double)counts[clustersArray[i]] - 1) / counts[clustersArray[i]]))
                                                            + data[i][j] / counts[clustersArray[i]];
                }
            }
        }
        private bool UpdateClustering(double[][] data)
        {
            bool changed = false;
            int[] newClustering = new int[data.Length];
            Array.Copy(_clustering, newClustering, data.Length);
            double[] distances = new double[_numClusters];
            double[] dxdy = new double[2];

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < distances.Length; j++)
                {
                    for (int k = 0; k < _centroids[j].Length; k++)
                    {
                        dxdy[k] = data[i][k] - _centroids[j][k];
                    }
                    distances[j] = Distance(dxdy[0], dxdy[1]);
                }
                if(_clustering[i] != ClosestCentroid(distances))
                {
                    _clustering[i] = ClosestCentroid(distances);
                    changed = true;
                }
            }

            return changed;
        }
        private static double Distance(double x, double y)
            =>
                Math.Sqrt((x*x) + (y*y));

        private static int ClosestCentroid(double[] distances)
            =>
                Array.IndexOf(distances, distances.Min());
    }
}
