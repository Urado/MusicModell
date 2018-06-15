using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDiplomIter1.SongParameterDetector.SignalAnales
{
    class WindowFilters
    {
        private const double Q = 0.5;

        public static double Rectangle(double n, double frameSize)
        {
            if (n < frameSize && n > 0)
                return 1;
            else
                return 0;
        }

        public static double Gausse(double n, double frameSize)
        {
            if (n < frameSize && n > 0)
            {
                var a = (frameSize - 1) / 2;
                var t = (n - a) / (Q * a);
                t = t * t;
                return Math.Exp(-t / 2);
            }
            else
                return 0;
        }

        public static double Hamming(double n, double frameSize)
        {

            if (n < frameSize && n > 0)
                return 0.54 - 0.46 * Math.Cos((2 * Math.PI * n) / (frameSize - 1));
            else
                return 0;
        }

        public static double Hann(double n, double frameSize)
        {
            if (n < frameSize && n > 0)
                return 0.5 * (1 - Math.Cos((2 * Math.PI * n) / (frameSize - 1)));
            else
                return 0;
        }

        public static double BlackmannHarris(double n, double frameSize)
        {
            if (n < frameSize && n > 0)
                return 0.35875 - (0.48829 * Math.Cos((2 * Math.PI * n) / (frameSize - 1))) +
                   (0.14128 * Math.Cos((4 * Math.PI * n) / (frameSize - 1))) - (0.01168 * Math.Cos((4 * Math.PI * n) / (frameSize - 1)));
            else
                return 0;
        }
    }
}
