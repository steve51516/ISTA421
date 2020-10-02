using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace EX10ConvertNumbers
{
    class Util
    {
        internal static string dec2bin(long number)
        {
            string tempResult = "";
            while (number > 0)
            {
                tempResult += number % 2;
                number = number / 2;
            }

            tempResult = Regex.Replace(tempResult, ".{4}", "$0 ");
            string result = "";

            for (int i = tempResult.Length - 1; i >= 0; i--)
            {
                result += tempResult[i];
            }

            return result;
        }

        internal static string dec2oct(long number)
        {
            string tempResult = "";
            while (number > 0)
            {
                tempResult += number % 8;
                number = number / 8;
            }

            tempResult = Regex.Replace(tempResult, ".{3}", "$0 ");
            string result = "";

            for (int i = tempResult.Count() - 1; i >= 0; i--)
                result += tempResult[i];

            return result;
        }

        internal static string dec2hex(long number)
        {
            string tempResult = "";
            while (number > 0)
            {
                long remainder = number % 16;
                switch (remainder)
                {
                    case 10:
                        tempResult += "A";
                        break;
                    case 11:
                        tempResult += "B";
                        break;
                    case 12:
                        tempResult += "C";
                        break;
                    case 13:
                        tempResult += "D";
                        break;
                    case 14:
                        tempResult += "E";
                        break;
                    case 15:
                        tempResult += "F";
                        break;
                    default:
                        tempResult += remainder;
                        break;
                }
                number = number / 16;
            }
            string result = "";
            tempResult = Regex.Replace(tempResult, ".{4}", "$0 ");
            for (int i = tempResult.Length - 1; i >= 0; i--)
            {
                result += tempResult[i];
            }
            return result;
        }

        internal static long bin2dec(string number)
        {
            long result = 0;
            byte[] byteArr = new byte[number.Length];
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i] == 48)
                    byteArr[i] = 0;
                else if (number[i] == 49)
                    byteArr[i] = 1;
            }
            for (int i = byteArr.Count() - 1, j = 1; i >= 0; i--)
            {
                if (byteArr[i] != 0)
                    result += j * byteArr[i];
                j *= 2;
            }
            return result;
        }

        internal static long bin2oct(int number)
        {
            throw new NotImplementedException();
        }

        internal static string bin2hex(int number)
        {
            throw new NotImplementedException();
        }

        internal static long oct2bin(int number)
        {
            throw new NotImplementedException();
        }

        internal static long oct2dec(int number)
        {
            throw new NotImplementedException();
        }

        internal static string oct2hex(int number)
        {
            throw new NotImplementedException();
        }

        internal static long hex2bin(string n1)
        {
            throw new NotImplementedException();
        }

        internal static long hex2oct(string n1)
        {
            throw new NotImplementedException();
        }

        internal static long hex2dec(string n1)
        {
            throw new NotImplementedException();
        }
    }
}
