using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryDiplomIter1.SongParameterDetector.SignalAnales;
using TryDiplomIter1.SongParameterDetector.MathAssistanse;

namespace TryDiplomIter1.SongParameterDetector
{
    class BeatPerMinutDetecter
    {
        public static List<double[]> ppp = null;
        public static SongParametrs Detector(SongData data)
        {
            var parametrs = new SongParametrs();
            parametrs.Song = data;

            double[] signal = new double[data.leng];

            //Объединение сигналов
            for(int i=0;i<data.leng;i++)
            {
                signal[i] = data.Left[i] + data.Right[i];
            }
            int st = 10;
            int frameSize = 1 << st;
            int sst=0;
            int s = 1<<sst;
            int step = 1;
            int HiFilter = 1 << 3;
            //Преобразование фурье
            parametrs.TransformSong = FastFourierTransform.WindowFFTParalell(signal, frameSize, step, s,st-sst);

            

            //Диффирационный фильтр
            List<double[]> FrequencyFunctions = new List<double[]>();


            for (int i = 0; i < frameSize/HiFilter; i++)
            {
                double[] func = new double[data.leng/step];
                for (int j = 0; j < data.leng/ step; j++)
                {
                    func[j] = parametrs.TransformSong[j,i];
                }
                func = Filters.Differentiator5(func);
                FrequencyFunctions.Add(func);
            }
            ppp = FrequencyFunctions;

            //Суммирование
            parametrs.BeatFunction = new double[data.leng/step];
            for (int i = 0; i < data.leng/ step; i++)
            {
                parametrs.BeatFunction[i] = 0;
                for (int j = 1; j < frameSize/HiFilter; j++)
                {
                    parametrs.BeatFunction[i] += Math.Abs(FrequencyFunctions[j][i]);
                }
            }

            var f = Filters.DellShum(parametrs.BeatFunction);
            var cor = Correlation.Easy(TableFunction.TableToFunction(f, 1, 0, parametrs.BeatFunction.Length), 1, 0, parametrs.BeatFunction.Length / 3);

            var Max = MaxAssistance.LocalMax2(MaxAssistance.LocalMax(MaxAssistance.CompressFunc(cor, 1, 0), 220), 10);

            var BeatMax = MaxAssistance.LocalMax2(MaxAssistance.LocalMax(parametrs.BeatFunction, 220), 10);


            double BPMd = Max[1].Item1 * 1 * step;

            int sd = (int)BeatMax[0].Item1 * step;

            parametrs.Temp = 60 * 44100 / BPMd;

            parametrs.TempD = (int)BPMd;

            parametrs.StartBeat = sd;

            return parametrs;
        }
    }
}
