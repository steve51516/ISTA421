using System;

namespace EX12MathGames
{
    static class Util
    {
        static Random random = new Random();
        public static (int probType, int numProb) Initialize()
        {
            Console.WriteLine("What type of math problems do you want to practive?");
            Console.WriteLine("1) Addition");
            Console.WriteLine("2) Subtraction");
            Console.WriteLine("3) Multiplication");
            Console.WriteLine("4) Division");
            Console.Write("Enter amount: ");
            
            int probType = 0;

            do
            {
                try
                {
                    Console.Write("Enter Answer: ");
                    probType = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERROR: Input must be a number.");
                }
                if (probType > 15 || probType < 0)
                    Console.WriteLine("ERROR: Must select 1, 2, 3, or 4.");
            } while (probType <= 0 && probType > 4);

            int numProb = 0;

            Console.WriteLine("How many questions do you want to answer?");

            do
            {
                try
                {
                    Console.Write("Enter Amount: ");
                    numProb = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: Input must be a number.");
                }
            } while (numProb <= 0);


            
            return (probType, numProb);
        }
        public static int Add(int n)
        {
            Console.Clear();
            int answer = 0;
            int numOfCorrect = 0;
            for (int i = 0; i < n; i++)
            {
                int rndNum1 = random.Next(13);
                int rndNum2 = random.Next(13);
                Console.Write($"{i + 1}) {rndNum1} + {rndNum2} = ");
                try
                {
                    answer = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Input must be an intiger.");
                }
                int correctAnswer = rndNum1 + rndNum2;
                if (correctAnswer == answer)
                {
                    Console.WriteLine("Correct.");
                    numOfCorrect++;
                }
                else
                    Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}");
            }
            return numOfCorrect;
        }
        public static int Subtract(int n)
        {
            Console.Clear();
            int answer = 0;
            int numOfCorrect = 0;
            for (int i = 0; i < n; i++)
            {
                int rndNum1 = random.Next(1, 13);
                int rndNum2 = random.Next(1, 13);
                if (rndNum1 > rndNum2)
                    Console.Write($"{i + 1}) {rndNum1} - {rndNum2} = ");
                else
                    Console.Write($"{i + 1}) {rndNum2} - {rndNum1} = ");
                try
                {
                    answer = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Input must be an intiger.");
                }
                int correctAnswer = 0;
                if (rndNum1 > rndNum2)
                    correctAnswer = rndNum1 - rndNum2;
                else
                    correctAnswer = rndNum2 - rndNum1;
                if (correctAnswer == answer)
                {
                    Console.WriteLine("Correct.");
                    numOfCorrect++;
                }
                else
                    Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}");
            }
            return numOfCorrect;
        }
        public static int Multiply(int n)
        {
            Console.Clear();
            int answer = 0;
            int numOfCorrect = 0;
            for (int i = 0; i < n; i++)
            {
                int rndNum1 = random.Next(13);
                int rndNum2 = random.Next(13);
                Console.Write($"{i + 1}) {rndNum1} * {rndNum2} = ");
                try
                {
                    answer = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Input must be an intiger.");
                }
                int correctAnswer = rndNum1 * rndNum2;
                if (correctAnswer == answer)
                {
                    Console.WriteLine("Correct.");
                    numOfCorrect++;
                }
                else
                    Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}");
            }

            return numOfCorrect;
        }
        public static double Divide(int n)
        {
            Console.Clear();
            double answer = 0;
            int numOfCorrect = 0;
            for (int i = 0; i < n; i++)
            {
                double rndNum1 = random.Next(13);
                double rndNum2 = random.Next(1, 13);
                Console.Write($"{i + 1}) {rndNum1} / {rndNum2} = ");
                try
                {
                    answer = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Input must be an intiger.");
                }
                double correctAnswer = rndNum1 / rndNum2;
                correctAnswer = Math.Round(correctAnswer, 2);
                if (correctAnswer == answer)
                {
                    Console.WriteLine("Correct.");
                    numOfCorrect++;
                }
                else
                    Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}");
            }

            return numOfCorrect;
        }
        public static string Report(double score, double numOfProb) => $"You got {score} out of {numOfProb} correct and your grade is {(score / numOfProb) * 100}";
    }
}
