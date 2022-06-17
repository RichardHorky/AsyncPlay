using System;

namespace AsyncPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                QuadraticClass quadraticClass = new QuadraticClass();

                Console.Write("Write a: ");
                if (!double.TryParse(Console.ReadLine(), out double a))
                    break;
                Console.Write("Write b: ");
                if (!double.TryParse(Console.ReadLine(), out double b))
                    break;
                Console.Write("Write c: ");
                if (!double.TryParse(Console.ReadLine(), out double c))
                    break;

                quadraticClass.CalcResult(a, b, c, target);
            }
            while (true);
        }

        static void target(ICalc sender, double? x1, double? x2)
        {
            Console.WriteLine();
            Console.WriteLine($"x1: {x1}, x2: {x2}");
        }
    }
}
