using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDiplomIter1.SongParameterDetector.SignalAnales
{
    class FastFourierTransform
    {
        public const double SinglePi = Math.PI;
        public const double DoublePi = 2 * Math.PI;

        public static Complex[] DecimationInTime(Complex[] frame, bool direct)
        {
            if (frame.Length == 1) return frame;
            var frameHalfSize = frame.Length >> 1; // frame.Length/2
            var frameFullSize = frame.Length;

            var frameOdd = new Complex[frameHalfSize];
            var frameEven = new Complex[frameHalfSize];
            for (var i = 0; i < frameHalfSize; i++)
            {
                var j = i << 1; // i = 2*j;
                frameOdd[i] = frame[j + 1];
                frameEven[i] = frame[j];
            }

            var spectrumOdd = DecimationInTime(frameOdd, direct);
            var spectrumEven = DecimationInTime(frameEven, direct);

            var arg = direct ? -DoublePi / frameFullSize : DoublePi / frameFullSize;
            var omegaPowBase = new Complex(Math.Cos(arg), Math.Sin(arg));
            var omega = Complex.One;
            var spectrum = new Complex[frameFullSize];

            for (var j = 0; j < frameHalfSize; j++)
            {
                spectrum[j] = spectrumEven[j] + omega * spectrumOdd[j];
                spectrum[j + frameHalfSize] = spectrumEven[j] - omega * spectrumOdd[j];
                omega *= omegaPowBase;
            }

            return spectrum;
        }

        public static Complex[] DecimationInFrequency(Complex[] frame, bool direct)
        {
            if (frame.Length == 1) return frame;
            var halfSampleSize = frame.Length >> 1; // frame.Length/2
            var fullSampleSize = frame.Length;

            var arg = direct ? -DoublePi / fullSampleSize : DoublePi / fullSampleSize;
            var omegaPowBase = new Complex(Math.Cos(arg), Math.Sin(arg));
            var omega = Complex.One;
            var spectrum = new Complex[fullSampleSize];

            for (var j = 0; j < halfSampleSize; j++)
            {
                spectrum[j] = frame[j] + frame[j + halfSampleSize];
                spectrum[j + halfSampleSize] = omega * (frame[j] - frame[j + halfSampleSize]);
                omega *= omegaPowBase;
            }

            var yTop = new Complex[halfSampleSize];
            var yBottom = new Complex[halfSampleSize];
            for (var i = 0; i < halfSampleSize; i++)
            {
                yTop[i] = spectrum[i];
                yBottom[i] = spectrum[i + halfSampleSize];
            }

            yTop = DecimationInFrequency(yTop, direct);
            yBottom = DecimationInFrequency(yBottom, direct);
            for (var i = 0; i < halfSampleSize; i++)
            {
                var j = i << 1; // i = 2*j;
                spectrum[j] = yTop[i];
                spectrum[j + 1] = yBottom[i];
            }

            return spectrum;
        }

        public static double[,] WindowFFT(double[] signal, int WindowSize)
        {
            double[,] ret = new double[signal.Length,WindowSize];
            for(int q=WindowSize/2;q<signal.Length;q+=1)
            {
                var convertSignal = new double[WindowSize];
                for(int i=0;i< WindowSize; i++)
                {
                    convertSignal[i] = 0;
                    if (i+q< signal.Length)
                        convertSignal[i] = signal[i+q- WindowSize / 2] * WindowFilters.Gausse(i, WindowSize);
                }
                var FFT = DecimationInTime(convertSignal.Select(x => { return new Complex(x, 0); }).ToArray(), false);
                for (var i = 0; i < FFT.Length; i++)
                {
                    FFT[i] /= WindowSize;
                }
                for (int i=0;i<WindowSize;i++)
                {
                    ret[q, i] = FFT[i].Magnitude;
                }
            }
            return ret;
        }

        public static double[,] WindowFFTParalell(double[] signal, int WindowSize,int step, int d,int st)
        {
            double[,] ret = new double[signal.Length/ step, WindowSize/d/2];

            var tasks = new List<Task>();

            //for (int q = WindowSize / 2; q < signal.Length/ step; q ++ )
            //{
            //    int pq = q* step;
            //    var t = new Task(() =>
            //      {
            //          var convertSignal = new double[WindowSize];
            //          for (int i = 0; i < WindowSize; i++)
            //          {
            //              convertSignal[i] = 0;
            //              if (i*d + pq < signal.Length)
            //                  convertSignal[i] = signal[i*d + pq - WindowSize / 2] * WindowFilters.Gausse(i, WindowSize);
            //          }
            //          var FFT = DecimationInTime(convertSignal.Select(x => { return new Complex(x, 0); }).ToArray(), false);
            //          for (var i = 0; i < FFT.Length; i++)
            //          {
            //              FFT[i] /= WindowSize;
            //          }
            //          for (int i = 0; i < WindowSize; i++)
            //          {
            //              ret[pq/ step, i] = FFT[i].Magnitude;
            //          }
            //      });

            //    tasks.Add(t);
            //    t.Start();
            //}


            for (int q = 0; q < signal.Length-step+1 ; q+= step)
            {
                int pq = q;
                var t = new Task(() =>
                {
                    var convertSignal = new double[WindowSize];

                    for (int i = 0; i < WindowSize/d; i++)
                    {
                        convertSignal[i] = 0;
                        if(pq  + (i - WindowSize / 2) * d>0 && pq  + (i - WindowSize / 2) * d<signal.Length)
                            convertSignal[i]=signal[pq + (i - WindowSize/2)* d] * WindowFilters.Gausse(i, WindowSize);
                    }
                    var FFT = FFTSpectr(convertSignal, 0, 1, st, WindowSize / d);

                    for (int i = 0; i < WindowSize / d/2; i++)
                    {
                        ret[pq / step, i] = FFT[i].Item2;
                    }
                    //var FFT = DecimationInTime(convertSignal.Select(x => { return new Complex(x, 0); }).ToArray(), false);
                    //for (int i = 0; i < WindowSize; i++)
                    //{
                    //    ret[pq / step, i] = FFT[i].Magnitude;
                    //}
                });

                tasks.Add(t);
                t.Start();
            }

            Task.WaitAll(tasks.ToArray());

            return ret;
        }

        public static Tuple<double,double>[] FFTSpectr(double[] signal,int sd,int d,int osframe, int lastInData)
        {
            int size = 1 << osframe;
            var ret = new Tuple<double, double>[size];
            var Frame = new Complex[size];
            for (int i = 0; i < size; i++)
            {
                Frame[i] = 0;
                if (i * d< lastInData && i * d + sd<signal.Length)
                    Frame[i] = new Complex(signal[i*d+sd]*WindowFilters.Gausse(i,lastInData), 0);
            }

            var spectr = DecimationInTime(Frame, false);

            for (var i = 0; i < spectr.Length; i++)
            {
                spectr[i] /= size;
            }
            for (int i = 0; i < size; i++)
            {
                ret[i] = new Tuple<double, double>(i,spectr[i].Magnitude);
            }
            return ret;
        }
    }
}
