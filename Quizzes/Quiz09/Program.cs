using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz09
{
    class Program
    {
        static void Main(string[] args)
        {
            Structures.PrintStructs();
        }
    }
    class Structures
    {
        public static void PrintStructs()
        {
            Stack<string> stack = new Stack<string>();

            stack.Push("One");
            stack.Push("Two");
            stack.Push("Three");
            
            Console.WriteLine("Here is the stack");
            
            foreach (var word in stack)
            {
                Console.WriteLine(word);
            }

            Queue<string> que = new Queue<string>();

            que.Enqueue("One");
            que.Enqueue("Two");
            que.Enqueue("Three");

            Console.WriteLine("Here is the Queue");

            foreach (var word in que)
            {
                Console.WriteLine(word);
            }

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            dictionary.Add("One", 1);
            dictionary.Add("Two", 2);
            dictionary.Add("three", 3);

            foreach (var pair in dictionary)
            {
                Console.WriteLine(pair);
            }

        }
    }
}
