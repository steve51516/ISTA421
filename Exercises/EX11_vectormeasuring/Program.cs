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
                Random random = new Random();
                List<int[]> points = new List<int[]>();

                for (int i = 0; i < 100; i++)
                {
                    int[] xyPair =
                            {
                                random.Next(100),
                                random.Next(100)
                            };
                    points.Add(xyPair);
                }
                ListPoints(points);
                Console.WriteLine("\n=========================================================================================\n");
                CompareDistance(points);
            }
            internal void CompareDistance(List<int[]> pointsList)
            {
                int[][] points = pointsList.ToArray();
                double closest = CalcDistance(points[0][0], points[0][1], points[1][0], points[1][1]);
                double possibleClosest = 0;
                for (int i = points.Length - 1; i >= 0; i--)
                {
                    for (int j = 0; j < points.Length; j++)
                    {
                        possibleClosest = CalcDistance(points[i][0], points[i][1], points[j][0], points[j][1]);
                        if (possibleClosest < closest && possibleClosest != 0)
                        {
                            closest = possibleClosest;
                            Console.WriteLine($"Pairs: {points[i][0]},{points[i][1]} and {points[j][0]},{points[j][1]} Distance: {closest}");
                        }
                    }
                    
                }
            }
            internal void ListPoints(List<int[]> pointsList)
            {
                int[][] points = pointsList.ToArray();
                for (int i = 0; i < points.Length; i++)
                {
                    Console.WriteLine($"{points[i][0]}, {points[i][1]}");
                }
            }
            internal double CalcDistance(int x1, int y1, int x2, int y2) => Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y2 - y1) * (y2 - y1)));
        }
        struct Datum3
        {
            internal void CalcDist()
            {
                Random random = new Random();
                int[][] xyz = new int[1000][];
                for (int i = 0; i < xyz.Length; i++)
                {
                    xyz[i] = new int[3];
                }

                for (int i = 0, j = 0; i < xyz.Length; i++)
                {
                    while (j < 3)
                    {
                        xyz[i][j] = random.Next(1000);
                        j++;
                    }
                    j = 0;
                }
                double closest = Math.Sqrt((xyz[0][0] * xyz[0][0]) + (xyz[0][1] * xyz[0][1]) + (xyz[0][2] * xyz[0][2]));
                double possibleClosest = 0;
                for (int i = xyz.Length - 1; i >= 0; i--)
                {
                    
                    for (int j = 0; j < xyz.Length; j++)
                    {
                        possibleClosest = Math.Sqrt((xyz[i][0] * xyz[i][0]) + (xyz[i][1] * xyz[i][1]) + (xyz[i][2] * xyz[i][2]));
                        if (possibleClosest < closest && possibleClosest != 0)
                        {
                            closest = possibleClosest;
                            Console.WriteLine($"points: {xyz[i][0]},{xyz[i][1]},{xyz[i][2]} Distance: {closest}");
                        }
                    }
                }
            }
        }
    }
}
