using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryDiplomIter1.Music;
using TryDiplomIter1.SongParameterDetector;
using TryDiplomIter1.SongParameterDetector.SignalAnales;

namespace TryDiplomIter1.SongModification
{
    class MusicModifaer
    {
        public static void MusicMod(WavFile musik, WavFile musik1, MelodyModell Mod)
        {
            for (int i = 0; i < musik.DataList.Count; i++)
            {
                musik.DataList[i] = (Int16)((musik.DataList[i] * 3) / 7);
            }

            var datM = musik1.DataList.Select(v => { return (double)v; }).ToArray();

            for (int i = 1; 2 * (i * Mod.BPMd) < musik.DataList.Count - Mod.BPMd; i++)
            {

                var maxCh = NoteDetector.DetectNote(Mod.BPMd, datM, i, Mod.BPMd);


                var Bit = Generators.MusicImmitation(1 << 14, (int)((1 << 14) / (220 / 2.69 * ((i % 3 + 2) * 0.1))) /*Math.Max(maxCh,1)*/, 5000, 10);

                for (int j = 0; j < Bit.Length && musik.DataList.Count > (i * Mod.BPMd + j + Mod.StartSd) * 2; j++)
                {
                    musik.DataList[2 * (i * Mod.BPMd + j)] = (Int16)((Bit[j] * 4 / 7d + musik.DataList[2 * (i * Mod.BPMd + j) /*+ Mod.StartSd*/]));
                    musik.DataList[2 * (i * Mod.BPMd + j) + 1] = (Int16)((Bit[j] * 4 / 7d + musik.DataList[2 * (i * Mod.BPMd + j) + 1 /*+ Mod.StartSd*/]));
                }
            }
        }


        public static List<Note> ModelCreator(WavFile musik, MelodyModell Mod)
        {

            var ret = new List<Note>();

            var datM = musik.DataList.Select
                (v => 
                {
                    return (double)v;
                }).ToArray();

            for (int i = 1; 2 * (i * Mod.BPMd) < musik.DataList.Count - Mod.BPMd; i++)
            {

                var maxCh = NoteDetector.DetectNote(Mod.BPMd, datM, i, Mod.BPMd);

                ret.Add(NoteDetector.ChToNote( maxCh, (i * Mod.BPMd)/44100d ));

            }
            return ret;
        }


        public static void MusicMod2(WavFile musik, WavFile musik1, WavFile musikW, WavFile musikS, MelodyModell Mod)
        {
            for (int i = 0; i < musik.DataList.Count; i++)
            {
                musik.DataList[i] = (Int16)((musik.DataList[i] * 2) / 7);
            }

            double[] BitW = new double[musikW.DataList.Count];

            for (int i = 0; i < musikW.DataList.Count; i++)
            {
                BitW[i] = (Int16)((musikW.DataList[i] * 5) / 7);
            }

            var datM = musik1.DataList.Select(v => { return (double)v; }).ToArray();

            for (int i = 1; 2 * (i * Mod.BPMd) < musik.DataList.Count - Mod.BPMd; i++)
            {

                var maxCh = NoteDetector.DetectNote(Mod.BPMd, datM, i, Mod.BPMd);


                var Bit = BitW;
                double k = 1;
                if (i % 3 == 0)
                    k = 2;

                for (int j = 0; j < Bit.Length/2 && musik.DataList.Count > (i * Mod.BPMd + j + Mod.StartSd) * 2; j++)
                {
                    musik.DataList[2 * (i * Mod.BPMd + j) + Mod.StartSd] = (Int16)((Bit[2*j] *k + musik.DataList[2 * (i * Mod.BPMd + j) + Mod.StartSd]));
                    musik.DataList[2 * (i * Mod.BPMd + j) + 1 + Mod.StartSd] = (Int16)((Bit[2*j+1]*k  + musik.DataList[2 * (i * Mod.BPMd + j) + 1 + Mod.StartSd]));
                }
            }
        }
    }
}
