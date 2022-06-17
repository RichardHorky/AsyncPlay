using System;
using System.Collections.Generic;
using System.Linq;

namespace AsyncPlay
{
    class Program
    {

        static void Main(string[] args)
        {
            List<(QuadraticClass, double, double, double)> QClassList = new List<(QuadraticClass, double, double, double)>(); 
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

                QClassList.Add((quadraticClass,a,b,c));

            }
            while (true);
            
            QClassList.ForEach(QC => QC.Item1.CalcResult(QC.Item2, QC.Item3, QC.Item4, target));

        }

        static void target(ICalc sender, double? x1, double? x2)
        {
            Console.WriteLine();
            Console.WriteLine($"Y = {sender.A}x^2 + {sender.B}x + {sender.C} => \t x1: {x1}, \t x2: {x2}");
        }
    }
}
