using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDiplomIter1.SongParameterDetector.SignalAnales
{
    class Generators
    {
        public static double[] InpulseSignal(int leng, int delay, double impulsePower)
        {
            var signal = new double[leng];
            for (int i = 0; i < leng; i++)
            {
                signal[i] = 0;
                if (i % delay == 0)
                    signal[i] = impulsePower;
            }
            return signal;
        }
        public static double[] Sin(int leng, int p,double a)
        {
            var signal = new double[leng];
            for (int i = 0; i < leng; i++)
            {
                signal[i] = a*Math.Sin(2*((i%p)/(double)p)*(Math.PI));
            }
            return signal;
        }
        public static double[] Bit(int leng, int p, double a)
        {
            var signal = new double[leng];
            for (int i = 0; i < leng; i++)
            {
                signal[i] = (a*(10000)/(i+10000d)) * Math.Sin(2 * ((i % p) / (double)p) * (Math.PI));//*1d/(double)i+1d;
            }
            return signal;
        }

        public static double[] MusicImmitation(int leng, int BaseP, double a,int s)
        {
            var signal = Bit(leng, BaseP, a);
            
            for (int i = 2; i < s&&i<=BaseP; i++)
            {
                signal = SignalSumm(signal, Bit(leng, BaseP/i, (a*20)/(i+20)));
            }
            return signal;
        }

        public static double[] SignalSumm(double[] x,double[] y)
        {
            int leng = Math.Min(x.Length, y.Length);
            var signal = new double[leng];
            for (int i = 0; i < leng; i++)
            {
                signal[i] = x[i] + y[i];
            }
            return signal;
        }
    }
}
