using System;

namespace DelLab01
{
    //1. declare a delegate type
    delegate void MyDel();
    delegate int Chester(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Del20200329a");
            //2. instantiate a delegate object
            //either of the two lines below, a or b
            var md = new MyDel(someMethod); //a
            //MyDel md = someMethod; //b
            md += someName;
            //3. call the delegate
            md();
            Chester chester = add;
            int n = chester(13, 14);
            Console.WriteLine(n);
        }

        static void someMethod()
        {
            Console.WriteLine("This is the body of the method named \"someMethod()\"");
        }
        static void someName()
        {
            int a = 5;
            int b = 6;
            int c = a * b;
            Console.WriteLine($"The value of {a} * {b} is {c}");
        }
        static int add(int a, int b)
        {
            return a + b;
        }
    }
}