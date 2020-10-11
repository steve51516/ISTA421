using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz23_PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# Quiz 23");
            Console.Write("Enter the highest number to find the primes: ");
            string input = "";
            try
            {
                input = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Must be in proper format.");
            }

            long findTo = long.Parse(input);
            List<long> primesMultiThread = new List<long>();
            List<long> primesOneThread = new List<long>();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.For(0, findTo + 1, x =>
            {
                bool foundP = isPrime(x);
                if (foundP)
                {
                    primesMultiThread.Add(x);
                }
            });
            sw.Stop();
            sw.Start();
            TimeSpan tsMulti = sw.Elapsed;
            for (int i = 0; i < findTo; i++)
            {
                bool foundP = isPrime(i);
                if (foundP)
                {
                    primesOneThread.Add(i);
                }
            }
            TimeSpan tsSingle = sw.Elapsed;

            Console.WriteLine("PRINTING PRIMES FROM MULTI THREAD");
            foreach (int element in primesMultiThread)
                Console.Write($" {element} ");
            Console.WriteLine("\n==================================================================\n");
            Console.WriteLine("PRINTING PRIMES FROM SINGLE THREAD");
            foreach (int element in primesOneThread)
                Console.Write($" {element} ");
            Console.WriteLine($"\n\nfound {primesMultiThread.Count()} primes in time {tsMulti} using multi threading.");
            Console.WriteLine("\n==================================================================\n");
            Console.WriteLine($"\n\n found {primesOneThread.Count()} primes in time {tsSingle} using one thread.");
            Console.ReadKey();

        }
        private static bool isPrime(long n)
        {
            bool isP = true;
            for (int i = 2; i <= (int)Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    isP = false;
                    break;
                }
            }
            return isP;
        }

    }
}
