using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TryDiplomIter1.SongParameterDetector.SignalAnales
{
    class NoteDetector
    {
        public static double BaseA = 27.5;

        public static double K = Math.Pow(2, 1 / 12d);

        public static double DetectNote(int BPMd, double[] datM, int i,int Leng)
        {
            var sp = Filters.Antialiasing( FastFourierTransform.FFTSpectr(datM, 2 * (i * BPMd), 2, 14,Leng).ToList()).ToList();
            double max = 0;
            double maxCh = 1;
            foreach(var kv in sp)
            {
                if (kv.Key > 6 && kv.Key < 128)
                {

                    if (kv.Value > max)
                    {
                        max = kv.Value;
                        maxCh = kv.Key;
                    }
                }
            }
            return maxCh * (44100d / (1 << 14));
        }

        public static Note ChToNote(double Ch)
        {
            double K1 = Math.Pow(2, 1 / 12d);

            int Os = (int)(Math.Log(Ch / BaseA,2));

            double Base = Math.Pow(2, Os) * BaseA;

            int n = (int)(Math.Log(Ch / Base, K1) + 0.5);

            if (n >= 12)
            {
                n -= 12;
                Os++;
            }

            if (n < 6)
                Os++;

            return new Note { NoteNumber=n+1, OctavNumber=Os};
        }

        public static Note ChToNote(double Ch,double Time)
        {
            var c = ChToNote(Ch);

            c.Time = Time;

            return c;
        }
    }
}
