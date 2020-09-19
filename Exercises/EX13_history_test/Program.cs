using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EX13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing test bank...");
            var testBank = initTestBank();
            Dictionary<int, string> gradeBook = buildAnswerKey(testBank);
            Console.WriteLine("Test bank initialized.");
            int amount = menu();
            Console.WriteLine("Building test...");
            string[][] testReady = formatTest(testBank, amount);

            Console.WriteLine("Starting test now...");
            double finalGrade = startTest(testReady, gradeBook, amount);
            Console.WriteLine("You have completed the test.");
            Console.WriteLine($"Your score was {finalGrade}");
        }
        static int menu()
        {
            Console.WriteLine("How many questions would you like to answer?");
            Console.WriteLine("You can choose up to 15 questions.");
            Console.Write("Enter amount: ");
            int amount = 0;

            do
            {
                try
                {
                    amount = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERROR: Input must be a number.");
                }
                if (amount > 15)
                    Console.WriteLine("ERROR: You must enter 15 or less.");
                if (amount < 0)
                    Console.WriteLine("ERROR: You must enter a number greater than 0.");
            } while (amount <= 0 && amount > 15);
            return amount;
        }
        static string[] initTestBank()
        {
            // Gets explicit path of current directory
            string testPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            testPath += @"\testdata.csv";
            string allTestData = File.ReadAllText(testPath);
            allTestData = allTestData.Replace(Environment.NewLine, ","); //replace line endings terminating with comma;
            string[] testBank = allTestData.Split(',').ToArray();
            return testBank;
        }
        static string[][] formatTest(string[] testBank, int amount)
        {
            string[][] finalTest = new string[amount][];
            Random random = new Random();
            int randomA = random.Next(1, 5);
            List<int> usedNums = new List<int>();
            for (int i = 0, j = 0, k = 0; i < amount; i++)
            {
                Console.WriteLine(i);
                finalTest[i] = new string[5];
                while (j <= 4)
                {
                    if (j == 0)
                    {
                        finalTest[i][j] = testBank[k].Insert(0, $"{i + 1}. ");
                    }
                    else
                    {
                        finalTest[i][randomA] = testBank[k].Insert(0, $"    {randomA}. ");
                        usedNums.Add(randomA);
                        if (usedNums.Count < 4)
                        {
                            do
                            {
                                randomA = random.Next(1, 5);
                            } while (usedNums.Contains(randomA));
                        }
                    }
                    j++;
                    k++;
                }
                j = 0;
                usedNums.Clear();
            }

            return finalTest;
        }
        static Dictionary<int, string> buildAnswerKey(string[] testBank)
        {
            Dictionary<int, string> answerKey = new Dictionary<int, string>();

            for (int i = 0, j = 1; i < 15; i++) // TODO: Get line count of file to replace 15
            {
                answerKey.Add(i, testBank[j]);
                if (j < 71)
                    j += 5;
            }
            return answerKey;
        }
        static double startTest(string[][] testReady, Dictionary<int, string> gradeBook, double amount)
        {
            Console.Clear();
            int correctAmount = 0;
            int selection = 0;
            for (int i = 0, j = 0; i < amount; i++)
            {
                string userAnswer;
                while (j <= 4)
                {
                    Console.WriteLine(testReady[i][j]);
                    j++;
                }
                Console.Write("Enter selection: ");
                do
                {
                    try
                    {
                        selection = int.Parse(Console.ReadLine());
                        if (selection < 0 && selection > 4)
                            Console.WriteLine("Your selection must be between 1 and 4.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You must enter a number selection.");
                    }
                } while (selection < 0 || selection > 4);
                userAnswer = testReady[i][selection].TrimStart((char)9, '1','2','3','4',' ','.',' ');
                string correctAnswer;
                gradeBook.TryGetValue(i, out correctAnswer);
                if (userAnswer == correctAnswer)
                    correctAmount++;
                j = 0;
                Console.WriteLine();
            }
            Console.WriteLine($"You got {correctAmount} out of {amount} correct.");
            double finalGrade = Math.Round(100 * (correctAmount / amount));
            return finalGrade;
        }
    }
}