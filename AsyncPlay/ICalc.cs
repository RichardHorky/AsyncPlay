using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncPlay
{
    public interface ICalc
    {
        void CalcResult(double a, double b, double c, Action<double?, double?> result);
    }
}
