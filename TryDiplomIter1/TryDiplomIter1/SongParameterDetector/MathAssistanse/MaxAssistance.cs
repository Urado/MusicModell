using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDiplomIter1.SongParameterDetector.MathAssistanse
{
    class MaxAssistance
    {
        public static List<Tuple<double, double, double>> LocalMax(double[] func, int st)
        {
            var ret = new List<Tuple<double, double, double>>();
            double max;
            double del;

            for (int i = 1; i < func.Length - 1; i++)
            {
                del = 0;
                max = func[i];
                for (int j = Math.Max(-st, -i); j < st && i+j< func.Length; j++)
                {
                    if (func[i + j] > max)
                        max = func[i + j];
                    if (func[i + j] > del)
                        del = func[i] - func[i + j];
                }
                if (max == func[i]) //&& del>10000000000)
                    ret.Add(new Tuple<double, double, double>(i, func[i],del));
            }


            return ret;
        }

        public static List<Tuple<double, double>> LocalMax2(List<Tuple<double, double, double>> func, int st)
        {
            var ret = new List<Tuple<double, double>>();
            Tuple<double, double, double> max;

            for (int i = 1; i < func.Count - 1; i++)
            {
                max = func[i];
                for (int j = Math.Max(-st, -i); j < st && i + j < func.Count; j++)
                {
                    if (func[i + j].Item2 > max.Item2)
                        max = func[i + j];
                }
                if (max == func[i])
                    ret.Add(new Tuple<double, double>(func[i].Item1, func[i].Item2));
            }


            return ret;
        }

        public static double[] CompressFunc(double[] func,int ch, int sd)
        {
            var ret = new double[func.Length / ch];
            for(int i=1;i<ret.Length;i++)
            {
                ret[i] = func[i * ch + sd];
            }
            return ret;
        }

    }
}
