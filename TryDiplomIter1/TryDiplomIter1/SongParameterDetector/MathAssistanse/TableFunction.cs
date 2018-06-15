using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDiplomIter1.SongParameterDetector.MathAssistanse
{
    class TableFunction
    {
        public static Func<double,double> TableToFunction(double[] table, double step, double begin, double end)
        {
            return x => 
            {
                if(x>=begin&&x<end)
                {
                    int i = (int)((x - begin) / step);
                    double alfa = (x - i * step) / step;
                    return table[i] * alfa + table[Math.Min(table.Length - 1, i)] * (1 - alfa);
                }
                return 0;
            };
        }
    }
}
