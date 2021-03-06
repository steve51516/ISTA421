﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Exercise15PasswordCracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Exercise 15 - Password Cracker");
            Console.Write("Please enter a password: ");
            string userPassword = "";
            try
            {
                userPassword = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            // Use method #1 single thread cracking
            Util util = new Util();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            util.CreatePasswords(string.Empty);
            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            stopwatch.Reset();
            Console.WriteLine($"Cracked password in {time} amount of time.");

            // Use method 2 single and multi thread cracking
            stopwatch.Start();
            string crackedPassword = Util.BruteForceSingleThread(userPassword);
            stopwatch.Stop();
            time = stopwatch.Elapsed;
            stopwatch.Reset();
            Console.WriteLine("Single Threaded Cracking: ");
            Console.WriteLine($"Cracked password in {time} amount of time.");
            Console.WriteLine($"Password is: {crackedPassword}");

            stopwatch.Start();
            string secondPassword = Util.BruteForceMultiThread(userPassword);
            stopwatch.Stop();
            time = stopwatch.Elapsed;
            Console.WriteLine("Multi Threaded Cracking: ");
            Console.WriteLine($"Cracked password in {time} amount of time.");
            Console.WriteLine($"Password is: {secondPassword}");
        }
    }
    }
    class Util
    {
        public string generateCombosString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 32; i < 126; i++)
                sb.Append((char)i);
            return sb.ToString();
        }

        public char firstchar = (char)32;
        public char lastchar = (char)126;
        public int passwordLength = 2;
        public long tries = 0;
        public bool done = false;
        public string password = "pa";

        // Function for brute forcing
        public void CreatePasswords(string keys)
        {
            Console.WriteLine($"Trying: {keys} attempt: {tries}");
            if (keys == password)
            { // Check if the password is a match
                done = true;
            }

            if (keys.Length > passwordLength || done == true)
            {
                // This occurs if the user put in invalid characters or when it found a match
                return;
            }

            // Recursively create passwords
            for (char c = firstchar; c <= lastchar; c++)
            {
                tries++;
                CreatePasswords(keys + c);
            }
        }
        static char[] generateCombos()
        {
            char[] allCharacters = new char[103];

            for (int i = 32, j = 0; j < allCharacters.Length; i++, j++)
                allCharacters[j] = (char)i;

            return allCharacters;
        }
        static public string BruteForceMultiThread(string userPass)
        {
            char[] allCharacters = generateCombos();

            int[] nums = new int[9];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = i;

            StringBuilder stringBuilder = new StringBuilder();
            bool foundPass = true;
            int failedCounter = 0;
            List<int> failedLocations = new List<int>();

            Parallel.For(0, userPass.Length, x =>
            {
                int j = 0;
                int k = 0;
                while (foundPass)
                {
                    if (j >= allCharacters.Length)
                    {
                        foundPass = false;
                        failedCounter++;
                        failedLocations.Add(x);
                        stringBuilder.Append(" ");
                    }
                    else if (userPass[x] == allCharacters[j])
                    {
                        lock (stringBuilder)
                        {
                            stringBuilder.Append(allCharacters[j]);
                            foundPass = false;
                        }

                    }
                    else if (k < nums.Length && userPass[x] == nums[k])
                    {
                        lock (stringBuilder)
                        {
                            stringBuilder.Append(nums[k]);
                            foundPass = false;
                        }
                    }
                    j++;
                    if (k < nums.Length)
                        k++;
                }
                foundPass = true;
            });
            return stringBuilder.ToString();
        }
        static public string BruteForceSingleThread(string userPass)
        {
            char[] allCharacters = generateCombos();
            int[] nums = new int[9];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = i;

            StringBuilder stringBuilder = new StringBuilder();
            bool foundPass = true;
            int failedCounter = 0;
            List<int> failedLocations = new List<int>();

            for (int i = 0, j = 0, k = 0; i < userPass.Length; i++)
            {
                while (foundPass)
                {
                    if (j >= allCharacters.Length)
                    {
                        foundPass = false;
                        failedCounter++;
                        failedLocations.Add(i);
                        stringBuilder.Append(" ");
                    }
                    else if (userPass[i] == allCharacters[j])
                    {
                        stringBuilder.Append(allCharacters[j]);
                        foundPass = false;
                    }
                    else if (k < nums.Length && userPass[i] == nums[k])
                    {
                        stringBuilder.Append(nums[k]);
                        foundPass = false;
                    }
                    j++;
                    if (k < nums.Length)
                        k++;
                }
                j = 0;
                k = 0;
                foundPass = true;
            }
            if (failedCounter > 0)
            {
                Console.WriteLine($"ERROR: unable to find {failedCounter} characters.");
                Console.WriteLine("Below are the positions that could not be found...");
                foreach (var index in failedLocations)
                {
                    Console.WriteLine($"Index: {index}");
                }
                Console.WriteLine("An empty space has been placed in these positions.");
            }
            return stringBuilder.ToString();
        }
    }
