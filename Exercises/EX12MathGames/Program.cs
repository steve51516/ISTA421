using System;

namespace EX12MathGames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Math Games!");
            int probType = 0;
            int numProb = 0;
            double score = 0;
            (probType, numProb) = Util.Initialize();
            Console.WriteLine($"You have selected {probType}");

            switch (probType)
            {
                case 1:
                    score = Util.Add(numProb);
                    break;
                case 2:
                    score = Util.Subtract(numProb);
                    break;
                case 3:
                    score = Util.Multiply(numProb);
                    break;
                case 4:
                    score = Util.Divide(numProb);
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
            Console.WriteLine(Util.Report(score, numProb));
        }
        
    }
}
