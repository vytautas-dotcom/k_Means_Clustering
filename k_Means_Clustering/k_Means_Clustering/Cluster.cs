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
        public int[] _clustering;
        private double[][] _centroids;
        public Cluster(int numClusters, int[] clustering)
        {
            _numClusters = numClusters;
            _clustering = clustering;
            _centroids = new double[numClusters][];
        }
        public void Clusterer(double[][] data)
        {
            int rows = data.Length;

            bool changeInClustering = true;
            int maxCount = rows * 10; //to avoid oscillations
            int ct = 0;
            
            while (changeInClustering == true && ct < maxCount)
            {
                ++ct;
                UpdateCentroids(data);
                changeInClustering = UpdateClustering(data);
            }
            int[] result = new int[rows];
        }


        private void UpdateCentroids(double[][] data)
        {
            for (int i = 0; i < _numClusters; i++)
            {
                _centroids[i] = new double[] { 0.0, 0.0 };
            }

            int[] counts = new int[_centroids.Length];
            for (int i = 0; i < data.Length; i++)
            {
                //puts first coordinates for every centroid
                if (_centroids[_clustering[i]][0].Equals(0.0))
                {
                    for (int j = 0; j < data[i].Length; j++)
                    {
                        _centroids[_clustering[i]][j] = data[i][j];
                    }
                    counts[_clustering[i]]++;
                    continue;
                }
                //counts average coordinates for centroid of every randomized cluster
                counts[_clustering[i]]++;
                for (int j = 0; j < data[i].Length; j++)
                {
                    _centroids[_clustering[i]][j] = (_centroids[_clustering[i]][j] * (((double)counts[_clustering[i]] - 1) / counts[_clustering[i]]))
                                                            + data[i][j] / counts[_clustering[i]];
                }
            }
        }
        private bool UpdateClustering(double[][] data)
        {
            bool changed = false;
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
