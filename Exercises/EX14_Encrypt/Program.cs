using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace EX14_Encrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to my Roman Cypher Encryption Program");
                Console.WriteLine("Enter 1 to exit.");
                Console.Write("Enter the message to encrypt: ");
                string plaintext = "";
                try
                {
                    plaintext = Kata.RemoveBadChars(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                if (plaintext == "1")
                    break;
                Console.Write("Enter key as alpha character: ");
                char key = ' ';

                try
                {
                    key = char.Parse(Kata.RemoveBadChars(Console.ReadLine()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                string multiCharKey = "";
                Console.Write("Enter a string key: ");
                try
                {
                    multiCharKey = Kata.RemoveBadChars(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                string cleanPlainText = "";
                cleanPlainText = Kata.RemoveBadChars(plaintext);
                Console.WriteLine($"\nCleaned plain text is: {cleanPlainText}\n");

                string cypherString = Kata.cryptAlpha(cleanPlainText, "encrypt", key);
                string decryptedString = Kata.cryptAlpha(cypherString, "decrypt", key);
                string encryptStringWordKey = Kata.cryptStringKey(cleanPlainText, multiCharKey, "encrypt");
                string decryptStringWordKey = Kata.cryptStringKey(encryptStringWordKey, multiCharKey, "decrypt");

                Console.WriteLine($"Encrypted cypher message is: {cypherString}\n");
                Console.WriteLine($"Decrypted cypher message is: {decryptedString}\n");
                Console.WriteLine($"Encrypted cypher message with word key is: {encryptStringWordKey}\n");
                Console.WriteLine($"Decrypted cypher message with word key is: {decryptStringWordKey}\n");
            }
        }
    }
    class Kata
    {
        static public string cryptAlpha(string plainText, string crypt, char key = ' ')
        {
            char[] textArr = plainText.ToCharArray();
            string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowerChars = "abcdefghijklmnopqrustuvwxyz";
            int shiftUpper = 0;
            for (int i = 0; i < upperChars.Length; i++)
            {
                if (upperChars[i] == key)
                    shiftUpper = i + 1;
            }
            int shiftLower = 0;
            for (int i = 0; i < lowerChars.Length; i++)
            {
                if (lowerChars[i] == key)
                    shiftLower = i + 1;
            }
            if (crypt == "encrypt")
            {
                for (int i = 0; i < textArr.Length; i++)
                {
                    if (textArr[i] >= 65 && textArr[i] <= 90)
                    {
                        if (textArr[i] >= shiftUpper + 65)
                            textArr[i] -= (char)shiftUpper;
                        else
                            textArr[i] += (char)(shiftLower - 26);
                    }
                    else if (textArr[i] >= 97 && textArr[i] <= 122 || textArr[i] == 122)
                    {
                        if (textArr[i] + shiftLower <= 122)
                            textArr[i] += (char)shiftLower;
                        else
                            textArr[i] += (char)(shiftLower - 26);
                    }
                }
            }
            else if (crypt == "decrypt")
            {
                for (int i = 0; i < textArr.Length; i++)
                {
                    if (textArr[i] >= 65 && textArr[i] <= 90)
                    {
                        if (textArr[i] >= shiftUpper + 65)
                            textArr[i] += (char)shiftUpper;
                        else
                            textArr[i] -= (char)(shiftLower - 26);
                    }
                    else if (textArr[i] >= 97 && textArr[i] <= 122)
                    {
                        if (textArr[i] + shiftLower <= 122 || textArr[i] == 122)
                            textArr[i] -= (char)shiftLower;
                        else
                            textArr[i] += (char)(shiftLower - 26);
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var letter in textArr)
                sb.Append(letter);

            return sb.ToString();
        }
        static public string cryptStringKey(string plainText, string strKey, string crypt)
        {
            char[] textArr = plainText.ToCharArray();
            string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; string lowerChars = "abcdefghijklmnopqrustuvwxyz";

            int[] shiftPlaces = new int[strKey.Length];
            for (int i = 0; i < plainText.Length; i++)
            {
                for (int j = 0; j < plainText.Length; j++)
                {
                    if (strKey[i] == upperChars[j] || strKey[i] == lowerChars[j])
                    {
                        shiftPlaces[i] = j;
                    }
                    if (j == upperChars.Length)
                        j = plainText.Length;
                }
            }

            if (crypt == "encrypt")
            {
                for (int i = 0; i < textArr.Length; i++)
                {
                    if (textArr[i] >= 65 && textArr[i] <= 90)
                    {
                        if (textArr[i] >= shiftPlaces[i] + 65)
                            textArr[i] -= (char)shiftPlaces[i];
                        else
                            textArr[i] += (char)(shiftPlaces[i] - 26);
                    }
                    else if (textArr[i] >= 97 && textArr[i] <= 122 || textArr[i] == 122)
                    {
                        if (textArr[i] + shiftPlaces[i] <= 122)
                            textArr[i] -= (char)shiftPlaces[i];
                        else
                            textArr[i] += (char)(shiftPlaces[i] - 26);
                    }
                }
            }
            else if (crypt == "decrypt")
            {
                for (int i = 0; i < textArr.Length; i++)
                {
                    if (textArr[i] >= 65 && textArr[i] <= 90)
                    {
                        if (textArr[i] >= shiftPlaces[i] + 65)
                            textArr[i] += (char)shiftPlaces[i];
                        else
                            textArr[i] -= (char)(shiftPlaces[i] - 26);
                    }
                    else if (textArr[i] >= 97 && textArr[i] <= 122)
                    {
                        if (textArr[i] + shiftPlaces[i] <= 122 || textArr[i] == 122)
                            textArr[i] -= (char)shiftPlaces[i];
                        else
                            textArr[i] += (char)(shiftPlaces[i] - 26);
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var letter in textArr)
                sb.Append(letter);
            return sb.ToString();
        }
        public static string RemoveBadChars(string word) // Removes all non alphabetical characters
        {
            Regex reg = new Regex("[^a-zA-Z']");
            return reg.Replace(word, string.Empty);
        }
    }
}