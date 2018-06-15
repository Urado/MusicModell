using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TryDiplomIter1.SongParameterDetector.SignalAnales;
using TryDiplomIter1.SongParameterDetector.MathAssistanse;
using TryDiplomIter1.Music;

namespace TryDiplomIter1.SongParameterDetector
{
    class TestClass
    {
        public static Complex[] Test1()
        {
            var frameSize = 512;
            var frame = Generators.Sin(frameSize, 64, 1);
            var frame2 = Generators.Sin(frameSize, 4, 0.5d);
            var frame3 = Generators.InpulseSignal(frameSize, 128, 4);

            for (var i = 0; i < frame.Length; i++)
            {
                frame[i] += frame2[i];//+ frame3[i];
                //frame[i] *= WindowFilters.Rectangle(i, frameSize);
            }
            var spectrum = FastFourierTransform.DecimationInFrequency(frame.Select(x => { return new Complex(x, 0); }).ToArray(), false);
            for (var i = 0; i < frame.Length; i++)
            {
                spectrum[i] /= frameSize;
            }
            return spectrum;
        }

        public static double[] Test2()
        {
            var frame3 = Generators.InpulseSignal(1024, 128, 10);
            var frame2 = Generators.Sin(1024, 4, 1);
            var frame = Generators.Sin(1024, 64, 1);
            //for (var i = 0; i < frame.Length; i++)
            //{
            //    frame[i] += frame2[i];// + frame3[i];
            //}
            var func = Correlation.AutoCorrelation(TableFunction.TableToFunction(frame, 1, 0, 1024), 1, 0, 1024);
            return func;
        }

        public static SongParametrs Test3()
        {
            int MelodySize = 2048 * 32;
            int beatSize = 256 * 16;
            var melody = new int[MelodySize];
            for (int i = 0; i < MelodySize; i += beatSize)
            {
                var sin = Generators.MusicImmitation(beatSize, MelodySize / 128, 2048, 100);
                for (int j = 0; j < beatSize; j++)
                {
                    if (i != 0)
                        melody[i + j] = (int)sin[j];
                    else
                        melody[i + j] = 0;
                }
            }
            var dat = new SongData()
            {
                Left = melody,
                Right = melody,
                leng = MelodySize
            };
            var param = BeatPerMinutDetecter.Detector(dat);
            return param;
        }

        public static double[] Test3WTF()
        {
            int beatSize = 256;
            var sin = Generators.Bit(beatSize, 8, 128);

            var convertSignal = new double[beatSize];
            for (int i = 0; i < beatSize; i++)
            {
                convertSignal[i] = 0;
                if (i + 0 < sin.Length)
                    convertSignal[i] = sin[i + 0] * WindowFilters.Gausse(i, beatSize);
            }

            var FFT = FastFourierTransform.DecimationInTime(sin.Select(x => { return new Complex(x, 0); }).ToArray(), false);
            for (var i = 0; i < FFT.Length; i++)
            {
                FFT[i] /= beatSize;
            }
            return FFT.Select(x => { return x.Magnitude; }).ToArray();
        }

        public static Tuple<double, double>[] Test4()
        {
            int size = 1024 * 16;
            int pros = 4;
            int Base = 880 / 5;
            int Base2 = (int)(Base * (3.0 / 2.0));
            var ret = new Tuple<double, double>[size / 4];
            var ToF = new Complex[size];
            var Sign = Generators.Bit(size / pros, size / Base, 100);
            var Sign1 = Generators.Bit(size / pros, size / Base / 2, 100 / 2);
            var Sign2 = Generators.Bit(size / pros, size / Base / 3, 100 / 3);
            var Sign3 = Generators.Bit(size / pros, size / Base / 4, 100 / 4);
            var Sign4 = Generators.Bit(size / pros, size / Base / 5, 100 / 5);
            var Sign5 = Generators.Bit(size / pros, size / Base / 6, 100 / 6);
            var Sign6 = Generators.Bit(size / pros, size / Base / 7, 100 / 7);
            var Sign7 = Generators.Bit(size / pros, size / Base / 8, 100 / 8);
            var Sign8 = Generators.Bit(size / pros, size / Base / 9, 100 / 9);
            var Sign9 = Generators.Bit(size / pros, size / Base / 10, 100 / 10);
            var Sign10 = Generators.Bit(size / pros, size / Base / 11, 100 / 11);
            var Sign11 = Generators.Bit(size / pros, size / Base / 12, 100 / 12);
            var Sign12 = Generators.Bit(size / pros, size / Base / 13, 100 / 13);

            var Signa = Generators.Bit(size / pros, size / Base2, 100);
            var Signa1 = Generators.Bit(size / pros, size / Base2 / 2, 100 / 2);
            var Signa2 = Generators.Bit(size / pros, size / Base2 / 3, 100 / 3);
            var Signa3 = Generators.Bit(size / pros, size / Base2 / 4, 100 / 4);
            var Signa4 = Generators.Bit(size / pros, size / Base2 / 5, 100 / 5);
            var Signa5 = Generators.Bit(size / pros, size / Base2 / 6, 100 / 6);
            var Signa6 = Generators.Bit(size / pros, size / Base2 / 7, 100 / 7);
            var Signa7 = Generators.Bit(size / pros, size / Base2 / 8, 100 / 8);
            var Signa8 = Generators.Bit(size / pros, size / Base2 / 9, 100 / 9);
            var Signa9 = Generators.Bit(size / pros, size / Base2 / 10, 100 / 10);
            var Signa10 = Generators.Bit(size / pros, size / Base2 / 11, 100 / 11);
            var Signa11 = Generators.Bit(size / pros, size / Base2 / 12, 100 / 12);
            var Signa12 = Generators.Bit(size / pros, size / Base2 / 13, 100 / 13);

            int i = 0;
            for (i = 0; i < size / pros; i++)
            {
                ToF[i] = new Complex(Sign[i] + Sign1[i] + Sign2[i] + Sign3[i] + Sign4[i] + Sign5[i] + Sign6[i] + Sign7[i] + Sign8[i] + Sign9[i] + Sign10[i] + Sign11[i] + Sign12[i] +
                    Signa[i] + Signa1[i] + Signa2[i] + Signa3[i] + Signa4[i] + Signa5[i] + Signa6[i] + Signa7[i] + Signa8[i] + Signa9[i] + Signa10[i] + Signa11[i] + Signa12[i], 0);
            }
            for (; i < size; i++)
            {
                ToF[i] = new Complex(0, 0);
            }

            ToF = FastFourierTransform.DecimationInTime(ToF, false);

            for (i = 0; i < size / 4; i++)
            {
                ret[i] = new Tuple<double, double>(i * 5, ToF[i].Magnitude);
            }

            return ret;
        }

        public static Tuple<double, double>[] Test5()
        {

            int MelodySize = 44100 * 3;
            int Start = 44100 * 30;
            var musik = WavFile.Read(@"D:\Test.wav");


            var ret = new Tuple<double, double>[MelodySize];
            for (int i = 0; i < MelodySize * 2; i += 2)//musik.DataList.Count;i++)
            {
                ret[i / 2] = new Tuple<double, double>(i, musik.DataList[i + Start]);

            }
            return ret;
        }

        public static SongParametrs Test6()
        {
            int MelodySize = 44100 * 6;
            int Start = 44100 * 20;

            var musik = WavFile.Read(@"D:\Test4.wav");
            var melodyl = new int[MelodySize];
            var melodyr = new int[MelodySize];

            for (int i = 0; i < (MelodySize - 1) * 2; i += 2)//musik.DataList.Count;i++)
            {
                melodyl[i / 2] = musik.DataList[i + Start];
                melodyr[i / 2 + 1] = musik.DataList[i + Start];
            }

            var dat = new SongData()
            {
                Left = melodyl,
                Right = melodyr,
                leng = MelodySize
            };
            var param = BeatPerMinutDetecter.Detector(dat);
            return param;
        }

        public static List<Tuple<double, double>[]> Test7()
        {
            int MelodySize = 44100 * 3;
            int Start = 44100 * (60*4+15);//44100 * 30;//

            var ret = new List<Tuple<double, double>[]>();

            var musik = WavFile.Read(@"D:\Test5.wav");

            var musik1 = WavFile.Read(@"D:\Test5.wav");


            var melodyl = new int[MelodySize];
            var melodyr = new int[MelodySize];

            for (int i = 0; i < (MelodySize - 1) * 2; i += 2)//musik.DataList.Count;i++)
            {
                melodyl[i / 2] = musik.DataList[i + Start];
                melodyr[i / 2 + 1] = musik.DataList[i + Start];
            }

            var dat = new SongData()
            {
                Left = melodyl,
                Right = melodyr,
                leng = MelodySize
            };

            var param = BeatPerMinutDetecter.Detector(dat);

            var Mod = new MelodyModell
            {
                BPMd = (int)param.TempD

            };


            Mod.StartSd = (Start + (int)param.StartBeat) % Mod.BPMd;

            MusicMod(ret, musik, musik1, Mod);

            WavFile.Write(@"D:\TestWP3.wav", musik);
            return ret;

        }

        private static void MusicMod(List<Tuple<double, double>[]> ret, WavFile musik, WavFile musik1, MelodyModell Mod)
        {
            for (int i = 0; i < musik.DataList.Count; i++)
            {
                musik.DataList[i] = (Int16)((musik.DataList[i] * 3) / 7);
            }

            var datM = musik1.DataList.Select(v => { return (double)v; }).ToArray();

            for (int i = 1; 2 * (i * Mod.BPMd) < musik.DataList.Count - Mod.BPMd; i++)
            {
                var sp = FastFourierTransform.FFTSpectr(datM, 2 * (i * Mod.BPMd), 2, 14, Mod.BPMd);

                int maxCh = 1;

                maxCh = (int)NoteDetector.DetectNote(Mod.BPMd, datM, i, Mod.BPMd);



                ret.Add(sp);

                var Bit = Generators.MusicImmitation(1 << 14, /*(int)((1 << 14) / (220 / 2.69 * ((i % 3 + 2) * 0.1)))*/ Math.Max(maxCh, 1), 5000, 10);

                for (int j = 0; j < Bit.Length && musik.DataList.Count > (i * Mod.BPMd + j + Mod.StartSd) * 2; j++)
                {
                    musik.DataList[2 * (i * Mod.BPMd + j)] = (Int16)((Bit[j] * 4 / 7d + musik.DataList[2 * (i * Mod.BPMd + j) /*+ Mod.StartSd*/]));
                    musik.DataList[2 * (i * Mod.BPMd + j) + 1] = (Int16)((Bit[j] * 4 / 7d + musik.DataList[2 * (i * Mod.BPMd + j) + 1 /*+ Mod.StartSd*/]));
                }
            }
        }
    }
}
