﻿using System;

namespace EX10ConvertNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter Q to exit or N to continue: ");
                string input = "";
                try
                {
                    input = Console.ReadLine();
                    input = input.ToUpper();
                }
                catch (Exception)
                {
                    Console.WriteLine("You must enter Q or N.");
                }
                if (input == "Q")
                    Environment.Exit(0);

                Console.Write("Please enter the base to convert from 2|8|10|16: ");

                int from = 0;
                try
                {
                    from = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("You must enter an integer.");
                }

                Console.Write("Please enter the integer to convert: ");

                string n1 = "";
                bool success;
                int number = 0;
                try
                {
                    n1 = Console.ReadLine();
                    success = int.TryParse(n1, out number);

                    if (success)
                        Console.WriteLine($"Number: {number} base: {from}\n");
                    else
                        Console.WriteLine($"Number {n1} base: {from} \n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }


                long result = 0;
                string str_result = "";

                switch (from)
                {
                    case 10:
                        result = Util.dec2bin(number);
                        Console.WriteLine($"binary conversion is {result}");
                        result = Util.dec2oct(number);
                        Console.WriteLine($"octal conversion is {result}");
                        str_result = Util.dec2hex(number);
                        Console.WriteLine($"hex conversion is {str_result}");
                        break;
                    case 2:
                        result = Util.bin2dec(number);
                        Console.WriteLine($"decimal conversion result is {result}");
                        result = Util.bin2oct(number);
                        Console.WriteLine($"octal conversion is {result}");
                        str_result = Util.bin2hex(number);
                        Console.WriteLine($"hex conversion is {str_result}");
                        break;
                    case 8:
                        result = Util.oct2bin(number);
                        Console.WriteLine($"binary conversion is {result}");
                        result = Util.oct2dec(number);
                        Console.WriteLine($"decimal conversion is {result}");
                        str_result = Util.oct2hex(number);
                        Console.WriteLine($"hex conversion is {str_result}");
                        break;
                    case 16:
                        result = Util.hex2bin(n1);
                        Console.WriteLine($"binary conversion is {result}");
                        result = Util.hex2oct(n1);
                        Console.WriteLine($"octal conversion is {result}");
                        result = Util.hex2dec(n1);
                        Console.WriteLine($"decimal conversion is {result}");
                        break;
                    default:
                        Console.WriteLine("Error in base to convert from.");
                        break;
                }
            }
        }
    }
}
