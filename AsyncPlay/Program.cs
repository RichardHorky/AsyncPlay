using System;

namespace AsyncPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            QuadraticClass quadraticClass = new QuadraticClass();

            Console.Write("Write a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Write b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Write c: ");
            double c = double.Parse(Console.ReadLine());

            quadraticClass.CalcResult(a, b, c, new Action<double?, double?>(target));
        }

        static void target(double? x1, double? x2)
        {
            Console.WriteLine($"x1: {x1}, x2: {x2}");
        }
    }
}
