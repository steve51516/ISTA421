using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is C# quiz 22");
            Circle a = new Circle(3);
            Console.WriteLine(a.ToString());

            Circle b = new Circle(4);
            Console.WriteLine(b.ToString());
            Circle c = a + b;
            Console.WriteLine(c.ToString());

            Console.WriteLine("new - operator");
            c = a - b;
            Console.WriteLine(c.ToString());

            Console.WriteLine("new * operator");
            c = a * b;
            Console.WriteLine(c.ToString());
        }
    }
    public class Circle
    {
        public double area { get; set; }
        public double circumference { get; set; }
        public double radius { get; set; }


        public Circle()
        {

        }
        public Circle(double input)
        {
            radius = input;
            area = Math.PI * (radius * radius);
            circumference = 2 * Math.PI * radius;
        }
        public static Circle operator+(Circle a, Circle b)
        {
            Circle circle = new Circle(a.radius + b.radius);
            return circle;
        }
        public static Circle operator -(Circle a, Circle b)
        {
            var circAdded = (a.radius + b.radius);
            var twentyPercent = 0.20 * circAdded;
            Circle circle = new Circle(circAdded - twentyPercent);
            return circle;
        }
        public static Circle operator *(Circle a, Circle b)
        {
            Circle circle = new Circle(a.radius * b.radius);
            return circle;
        }
        public override string ToString() => $"I am a Circle. My radious is {radius}, my area is {area}, and my circumference is {circumference}";
    }
}
