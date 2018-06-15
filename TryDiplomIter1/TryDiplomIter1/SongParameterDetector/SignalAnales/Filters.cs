using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDiplomIter1.SongParameterDetector.SignalAnales
{
    class Filters
    {

        public static double[] DellShum(double[] signal)
        {
            double[] filter = new double[signal.Length];
            double summ = signal.Sum()/signal.Length;
            for (int i = 0; i < signal.Length; i++)
            {
                filter[i] = signal[i] - summ;
                if (filter[i] < 0)
                    filter[i] = 0;
            }
            return filter;
        }

        public static double[] Differentiator(double[] signal)
        {
            double[] filter = new double[signal.Length];
            filter[0] = 0;
            for(int i=1;i<signal.Length;i++)
            {
                filter[i] = (signal[i] - signal[i - 1])/2;
                if (filter[i] < 0)
                    filter[i] = 0;
            }
            return filter;
        }



        public static double[] Differentiator5(double[] signal)
        {
            double[] filter = new double[signal.Length];
            filter[0] = 0;
            for (int i = 4; i < signal.Length; i++)
            {
                filter[i] = (25 * signal[i] - 48 * signal[i - 1] + 36 * signal[i - 2] - 16 * signal[i - 3] + 3 * signal[i - 4]) / 12;
                if (filter[i] < 0)
                    filter[i] = 0;
            }
            return filter;
        }


        public static Dictionary<double, double> Antialiasing(List<Tuple<double, double>> spectrum)
        {
            var result = new Dictionary<double, double>();
            var data = spectrum.ToList();
            for (var j = 0; j < spectrum.Count - 4; j++)
            {
                var i = j;
                var x0 = data[i].Item1;
                var x1 = data[i + 1].Item1;
                var y0 = data[i].Item2;
                var y1 = data[i + 1].Item2;

                var a = (y1 - y0) / (x1 - x0);
                var b = y0 - a * x0;

                i += 2;
                var u0 = data[i].Item1;
                var u1 = data[i + 1].Item1;
                var v0 = data[i].Item2;
                var v1 = data[i + 1].Item2;

                var c = (v1 - v0) / (u1 - u0);
                var d = v0 - c * u0;

                var x = (d - b) / (a - c);
                var y = (a * d - b * c) / (a - c);

                if (y > y0 && y > y1 && y > v0 && y > v1 &&
                    x > x0 && x > x1 && x < u0 && x < u1)
                {
                    result.Add(x1, y1);
                    result.Add(x, y);
                }
                else
                {
                    result.Add(x1, y1);
                }
            }

            return result;
        }
    }
}
