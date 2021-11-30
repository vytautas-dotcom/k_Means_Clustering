using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_Means_Clustering
{
    class Display
    {
        int numClusters = 3;
        public Display()
        {

        }
        public Display(int num)
        {
            numClusters = num;
        }
        public void Show()
        {
            

            Data data = new Data();
            var rawData = data.RawData;
            
            int[] clustering = data.ClustersRandomizer(numClusters);
            Console.WriteLine("Raw unclustered data:\n");
            Console.WriteLine(" ID Coordinate X Coordinate Y Cluster");
            Console.WriteLine("---------------------------------");
            ShowData(rawData, clustering, 1, true, true);

            
            Console.WriteLine("\nSetting numClusters to " + numClusters);
            Console.WriteLine("\nStarting clustering using k-means algorithm");
            Console.WriteLine("\nRondomized clustering:");
            ShowVector(clustering, false);
            Cluster cluster = new Cluster(numClusters, clustering);
            cluster.Clusterer(rawData);
            Console.WriteLine();
            Console.WriteLine("Recalculated clustering:");
            ShowVector(cluster._clustering, false);
            Console.WriteLine("\n\nFinal clustering in internal form:\n");
            ShowClustered(rawData, cluster._clustering, numClusters, 1);
            
        }

        static void ShowData(double[][] rawData, int[] clustering, int decimals, bool indices, bool newLine)
        {
            for (int i = 0; i < rawData.Length; i++)
            {
                if (indices == true)
                {
                    Console.Write(i.ToString().PadLeft(3) + "       ");
                    for (int j = 0; j < rawData[i].Length; j++)
                    {
                        double v = rawData[i][j];
                        Console.Write(v.ToString("F" + decimals) + "      ");
                    }
                    Console.WriteLine("   " + clustering[i]);
                }
                if (newLine == true)
                {
                    Console.WriteLine("");
                }
            }
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
                Console.Write(vector[i] + " ");
                if (newLine == true) Console.WriteLine();
            }
        }

    }
}
