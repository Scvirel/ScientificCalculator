using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InjenerCalculator
{
    class Calculate
    {
        public static double Parse(string equatation,string si)
        {
            try
            {
                EParser ep = new EParser();
                ep.SI = si;
                double res = ep.CalculateExpression(equatation);
                return res;
            }
            catch (Exception)
            {
                return Double.NaN;
            }
            
        }
    }
}
