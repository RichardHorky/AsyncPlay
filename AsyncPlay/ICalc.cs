using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncPlay
{
    public interface ICalc
    {
        void CalcResult(double a, double b, double c, Action<ICalc, double?, double?> result);
        double A { get; }
        double B { get; }
        double C { get; }
    }
}
