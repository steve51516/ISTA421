using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EX09
{
    public class Passwd
    {
        private static Dictionary<string, string> passDB = new Dictionary<string, string>();

        public static void GetSelection()
        {
            bool exitCond = true;
            int selection = 10;
            while (exitCond)
            {
                Console.WriteLine("PASSWORD AUTHENTICATION SYSTEM\n");
                Console.WriteLine("Please select one option:\n");
                Console.WriteLine("1. Establish an account");
                Console.WriteLine("2. Authenticate a user");
                Console.WriteLine("3. Exit the system\n");
                Console.Write("Enter selection: ");
                try
                {
                    selection = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine($"You must enter a number. Try again.\n");
                    GetSelection();
                }
                if (selection >= 1 && selection <= 3)
                {
                    switch (selection)
                    {
                        case 1:
                            getNewUser();
                            break;
                        case 2:
                            Console.WriteLine("Enter username you would like to authenticate");
                            Console.Write("Username: ");

                            string authName = Console.ReadLine();
                            if (authName != null && authName != "")
                                authUser(authName);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Applicaton Exiting...\n");
                            exitCond = false;
                            break;
                        default:
                            Console.Clear();
                            GetSelection();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You must enter the number 1, 2, or 3.\n");
                }
            }
        }
        static void authUser(string userName)
        {
            if (!passDB.ContainsKey(userName))
                Console.WriteLine($"Username \"{userName}\" does not exist.");
            else if (passDB.ContainsKey(userName))
            {
                string secret;
                string testHash;
                int tryCount = 4;

                do
                {
                    secret = HidePassInput();

                    SHA256 sha256Hash = SHA256.Create();
                    testHash = GetHash(sha256Hash, secret);
                    Console.WriteLine(testHash);
                    if (passDB.TryGetValue(userName, out testHash))
                    {
                        Console.WriteLine(testHash);
                        Console.WriteLine($"Successfully authenticated as {userName}\n");
                        tryCount = 0;
                    }
                    else
                    {
                        tryCount--;
                        Console.WriteLine($"Failed to autheticate as {userName}. {tryCount} more tries left.\n");
                    }
                    
                } while (tryCount > 0);
            }
        }
        static void getNewUser()
        {
            string userName = "";
            while (userName == "")
            {
                Console.Write("Enter your username: ");
                userName = Console.ReadLine();
                if (userName == "")
                {
                    Console.Clear();
                    Console.WriteLine("Username cannot be empty.");
                }
            }
            string tempTest = null;
            while (passDB.ContainsKey(userName))
            {
                Console.WriteLine($"Username \"{userName}\" has already been taken.");
                Console.Write("Enter a different username. ");
                if (tempTest != null && tempTest != "")
                {
                    Console.Clear();
                    userName = tempTest;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Enter a different username. ");
                    tempTest = Console.ReadLine();
                }
            }

            string secret = "";
            string tempSecret;
            while (secret == "")
            {
                tempSecret = HidePassInput();

                if (tempSecret == "" || tempSecret == null)
                {
                    Console.Clear();
                    Console.WriteLine("Password cannot be empty.");
                }
                else if (tempSecret.Length <= 4)
                {
                    Console.Clear();
                    Console.WriteLine("Password must be 5 characters or longer.");
                }
                if (tempSecret.Length >= 8 && tempSecret != "")
                    secret = tempSecret;
            }

            SHA256 sha256Hash = SHA256.Create();
            string finalHash = GetHash(sha256Hash, secret);
            passDB.Add(userName, finalHash);

            foreach (var pair in passDB)
            {
                Console.WriteLine(pair);
            }

        }
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        static string HidePassInput() // Hides text entered from displaying on the console
        {
            string secret = null;
            Console.Write("\nEnter password: ");

            try
            {
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    secret += key.KeyChar;
                }
                Console.WriteLine("");
            }
            catch (Exception)
            {
                Console.WriteLine("Input must be valid.");
            }
            return secret;
        }
    }
}
