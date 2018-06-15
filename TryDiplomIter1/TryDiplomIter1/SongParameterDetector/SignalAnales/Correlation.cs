using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDiplomIter1.SongParameterDetector.SignalAnales
{
    class Correlation
    {
        public static double Integral(Func<double, double> func, double step, double begin, double end)
        {
            var ret = 0d;
            for (int i = 1; i * step + begin <= end; i++)
            {
                ret += (func((i - 1) * step) + func(i * step)) / 2 * step;
            }
            return ret;
        }
        public static double InSum (Func<double, double> func, double step, double begin, double end)
        {
            var ret = 0d;
            for (int i = 0; i * step + begin <= end; i++)
            {
                ret += func(i);
            }
            return ret;
        }


        public static double[] AutoCorrelation(Func<double, double> func, double step, double begin, double end)
        {
            var leng = (end - begin) / step;
            var signal = new double[(int)(leng)];
            for (int i = 1; i * step + begin < end; i++)
            {
                signal[i] = Integral(x => { return func(x) * func(x + i * step); }, step, begin, end);
            }
            return signal;
        }

        public static double[] CorrelationFunc(Func<double, double> func1, Func<double, double> func2, double step, double begin, double end)
        {
            var leng = (end - begin) / step;
            var signal = new double[(int)(leng)];
            for (int i = 1; i * step + begin < end; i++)
            {
                signal[i] = Integral(x => { return func1(x) * func2(x + i * step); }, step, begin, end);
            }
            return signal;
        }


        public static double[] AutoCorrelationParalell(Func<double, double> func, double step, double begin, double end)
        {
            var leng = (end - begin) / step;
            var signal = new double[(int)(leng)];

            var tasks = new List<Task>();
            //for (int i = 1; i * step + begin < end - step; i++)
            //{
            //    signal[i] = 0;
            //}

            for (int i = 0; i * step + begin < end-step; i++)
            {
                signal[i] = 0;
                if (i % 1 == 0)
                {
                    var ip = i;
                    var t = new Task(() => signal[ip] = InSum(x => { return func(x) * func(x + ip * step + begin); }, step, begin, end)); //Integral(x => { return func(x) * func(x + ip * step + begin); }, step, begin, end));
                    tasks.Add(t);
                    t.Start();
                }
            }

            Task.WaitAll(tasks.ToArray());

            return signal;
        }

        public static double[] Easy(Func<double, double> func, double step, double begin, double end)
        {
            return AutoCorrelationParalell(func, step, begin, end);
        }
    }
}
