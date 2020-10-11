using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EX11_vectormeasuring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the Vector Distance Exercise");
            bool again = true;
            while (again)
            {
                Console.Write("\nEnter 2 to calculate 2 element vector," +
                    "3 to calculate 3 element vector, or 9 to quit.");
                Console.WriteLine("Enter: ");
                int input = 0;
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Input must be in the proper format.");
                }
                switch (input)
                {
                    case 2:
                        Console.WriteLine("\nTwo element vector: ");
                        Datum2 d2 = new Datum2();
                        d2.CalcPairs();
                        break;
                    case 3:
                        Console.WriteLine("\nThree element vector");
                        Datum3 d3 = new Datum3();
                        d3.CalcDist();
                        break;
                    case 9:
                        Console.WriteLine("Exiting...");
                        again = false;
                        break;
                    default:
                        Console.WriteLine("Input not recognized.");
                        break;
                }
            }
        }
        struct Datum2
        {
            public int x { get; set; }
            public int y { get; set; }
            internal void CalcPairs()
            {
                int[] ranNums = CalcRandom();
                Random random = new Random();
                List<int[]> points = new List<int[]>();
                Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
                
                for (int i = 0; i < ranNums.Length / 2; i++)
                {
                    int[] x =
                {
                    ranNums[random.Next(100)],
                    ranNums[random.Next(100)]
                };
                    int[] y =
                {
                    ranNums[random.Next(100)],
                    ranNums[random.Next(100)]
                };
                    points.Add(x);
                    points.Add(y);
                }
                int[][] pointPairs = points.ToArray();

                Dictionary<int[], double> pointDistances = CompareDistance(pointPairs);
                ListDistances(pointDistances);
                //for (int i = 0, j = 0; i < pointPairs.Length; i++, j++)
                //{
                //    if (j >= 2)
                //        j = 0;
                //    if (j == 0)
                //        Console.Write("x: ");
                //    else
                //        Console.Write("y: ");
                //    Console.WriteLine(pointPairs[i][j]);

                //}
            }
            internal Dictionary<int[], double> CompareDistance(int[][] pointPairs)
            {
                Dictionary<int[], double> pointDistances = new Dictionary<int[], double>();
                for (int i = 0; i < pointPairs.Length - 1; i++)
                {
                    pointDistances.Add(pointPairs[i], CalcDistance(pointPairs[i][0], pointPairs[i][1], pointPairs[i + 1][0], pointPairs[i + 1][1]));
                }
                return pointDistances;
            }
            internal void ListDistances(Dictionary<int[], double> pointDistances)
            {
                int[][] points = pointDistances.Keys.ToArray();
                List<double> distances = pointDistances.Values.ToList();
                for (int i = 0; i < pointDistances.Count - 1; i++)
                    Console.WriteLine($"Points: ({points[i][0]},{points[i][1]}) | ({points[i + 1][0]},{points[i + 1][1]}) distance: {distances[i]}");
            }
            internal int[] CalcRandom()
            {
                int[] points = new int[100];
                Random random = new Random();
                for (int i = 0; i < points.Length; i++)
                    points[i] = random.Next(1, 101);
                return points;
            }
            internal double CalcDistance(int x1, int y1, int x2, int y2) => ((x1 - 1) * (y1 - 1)) + ((x2 - 1) * (y2 - 1));
        }
        struct Datum3
        {
            internal void CalcDist()
            {
                throw new NotImplementedException();
            }
        }
    }
}
