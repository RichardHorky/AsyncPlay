using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncPlay
{
    class QuadraticClass : ICalc
    {
        public void CalcResult(double a, double b, double c, Action<ICalc, double?, double?> result)
        {
            A = a;
            B = b;
            C = c;
            Thread thread = new Thread(() => findRoots(this, a, b, c, result));
            thread.Start();
        }

        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        static void findRoots(ICalc sender, double a, double b, double c, Action<ICalc, double?, double?> result)
        {

            double centerX = -1 * (b / (2 * a));

            Abcx abcx = new Abcx(a, b, c, centerX);//to make it shorter
            double centerY = quaEq(abcx);

            //checks if it doesnt have roots
            if ((a > 0 && centerY > 0) || a < 0 && centerY < 0)
            {
                result.Invoke(sender, null, null);
                return;
            } else if(centerY == 0)
            {
                result.Invoke(sender, centerX, null);
                return;
            }

            double rootX1 = Math.Round(getRoot(abcx, step: 1, dir: 1), 2);//"dir" and "steps" tells it witch direction search
            double rootX2 = Math.Round(getRoot(abcx, step: -1, dir: -1), 2);


            result.Invoke(sender, rootX1, rootX2);

        }

        //finds LEFT/RIGHT root 
        static double getRoot(Abcx abcx, double step, double dir, double oldPeek = 0)
        {
            //checks if we already have solution
            double distance = Math.Abs(quaEq(abcx));
            if (distance < 0.001)
                return abcx.x;

            //checks how far from the result we are after the step
            abcx.x += step; 
            double peek = quaEq(abcx);

            //if we cross the result step size lowers
            if ((peek > 0 && oldPeek < 0) || (peek < 0 && oldPeek > 0))
                step /= 2;

            //checks which way to step to and
             return getRoot(abcx,
                Math.Abs(step) * (peek * dir < 0 ? 1 : -1), //checks which direction is closer to result
                dir, peek);
        }

        //quadratic equation
        static double quaEq(Abcx abcx) => abcx.a * Math.Pow(abcx.x, 2) + abcx.b * abcx.x + abcx.c;

        //equation parameters
        struct Abcx
        {
            public double a, b, c, x;

            public Abcx(double a, double b, double c, double x)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                this.x = x;
            }
        }
    }
}
