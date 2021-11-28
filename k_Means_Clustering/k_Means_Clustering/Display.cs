using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_Means_Clustering
{
    class Display
    {
        public void Show()
        {
            Data data = new Data();
            var rawData = data.rawData;
            Console.WriteLine("Raw unclustered data:\n");
            Console.WriteLine(" ID Height (in.) Weight (kg.)");
            Console.WriteLine("---------------------------------");
            ShowData(rawData, 1, true, true);

            int numClusters = 3;
            Console.WriteLine("\nSetting numClusters to " + numClusters);
            Console.WriteLine("\nStarting clustering using k-means algorithm");
            Cluster cluster = new Cluster(numClusters);
            int[] clustering = cluster.Clusterer(rawData);
            Console.WriteLine();
            Console.WriteLine("Clustering complete\n");
            Console.WriteLine("Final clustering in internal form:\n");
            //ShowVector(clustering, true);
            //Console.WriteLine("Raw data by cluster:\n");
            //ShowClustered(rawData, clustering, numClusters, 1);
            Console.WriteLine("\nEnd k-means clustering demo\n");
            
        }

        private void ShowClustered(double[][] rawData, int[] clustering, int numClusters, int decimals)
        {
            for (int k = 0; k < numClusters; ++k)
            {
                Console.WriteLine("===================");
                for (int i = 0; i < rawData.Length; ++i)
                {
                    int clusterID = clustering[i];
                    if (clusterID != k) continue;
                    Console.Write(i.ToString().PadLeft(3) + " ");
                    for (int j = 0; j < rawData[i].Length; ++j)
                    {
                        double v = rawData[i][j];
                        Console.Write(v.ToString("F" + decimals) + " ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("===================");
            }
        }

        static void ShowVector(int[] vector, bool newLine)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                Console.WriteLine(vector[i] + " ");
                if (newLine == true) Console.WriteLine();
            }
        }

        static void ShowData(double[][] rawData, int decimals, bool indices, bool newLine)
        {
            for (int i = 0; i < rawData.Length; i++)
            {
                if (indices == true)
                {
                    Console.Write(i.ToString().PadLeft(3) + "         ");
                    for (int j = 0; j < rawData[i].Length; j++)
                    {
                        double v = rawData[i][j];
                        Console.Write(v.ToString("F" + decimals) + "        ");
                    }
                    Console.WriteLine("");
                }
                if (newLine == true)
                {
                    Console.WriteLine("");
                }
            }
        }

    }
}
