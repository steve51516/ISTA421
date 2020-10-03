using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EX10ConvertNumbers
{
    class Util
    {
        internal static long dec2bin(long number)
        {
            string tempResult = "";
            while (number > 0)
            {
                tempResult += number % 2;
                number /= 2;
            }

            //tempResult = Regex.Replace(tempResult, ".{4}", "$0 ");
            string result = "";

            for (int i = tempResult.Length - 1; i >= 0; i--)
            {
                result += tempResult[i];
            }
            return int.Parse(result);
        }

        internal static long dec2oct(long number)
        {
            string tempResult = "";
            while (number > 0)
            {
                tempResult += number % 8;
                number /= 8;
            }
            //tempResult = Regex.Replace(tempResult, ".{3}", "$0 ");
            string result = "";

            for (int i = tempResult.Count() - 1; i >= 0; i--)
                result += tempResult[i];
            return int.Parse(result);
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
                number /= 16;
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

        internal static long bin2oct(long number) => dec2oct(bin2dec(number.ToString()));
        internal static string bin2hex(string number) => dec2hex(bin2dec(number));

        internal static long oct2bin(long number) => dec2bin(oct2dec(number));

        internal static long oct2dec(long number)
        {
            List<long> tempOct = new List<long>();

            while (number > 0)
            {
                tempOct.Add(number % 10);
                number /= 10;
            }
            long result = 0;
            for (int i = 0, j = 1; i < tempOct.Count(); i++)
            {
                result += tempOct[i] * j;
                j *= 8;
            }
            return result;
        }

        internal static string oct2hex(long number) => dec2hex(oct2dec(number));

        internal static long hex2bin(string n1)
        {
            n1 = n1.ToUpper();
            if (n1.Length > 1)
                n1 = Regex.Replace(n1, ".{1}", "$0 ");
            string binaryNum = "";
            for (int i = 0; i < n1.Length; i++)
            {
                switch (n1[i])
                {
                    case '1':
                        binaryNum += "0001";
                        break;
                    case '2':
                        binaryNum += "0010";
                        break;
                    case '3':
                        binaryNum += "0011";
                        break;
                    case '4':
                        binaryNum += "0100";
                        break;
                    case '5':
                        binaryNum += "0101";
                        break;
                    case '6':
                        binaryNum += "0110";
                        break;
                    case '7':
                        binaryNum += "0111";
                        break;
                    case '9':
                        binaryNum += "1001";
                        break;
                    case 'A':
                        binaryNum += "1010";
                        break;
                    case 'B':
                        binaryNum += "1011";
                        break;
                    case 'C':
                        binaryNum += "1011";
                        break;
                    case 'D':
                        binaryNum += "1101";
                        break;
                    case 'E':
                        binaryNum += "1110";
                        break;
                    case 'F':
                        binaryNum += "1111";
                        break;
                    default:
                        break;
                }
            }
            //return binaryNum = Regex.Replace(binaryNum, ".{4}", "$0 ");
            return int.Parse(binaryNum);
        }

        internal static long hex2oct(string n1) => bin2oct(hex2bin(n1));

        internal static long hex2dec(string n1) => oct2dec(hex2dec(n1));
    }
}
