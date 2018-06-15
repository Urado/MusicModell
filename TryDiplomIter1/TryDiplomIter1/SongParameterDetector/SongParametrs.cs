using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDiplomIter1.SongParameterDetector
{
    class SongParametrs
    {
        public SongData Song { get; set; }
        public double[,] TransformSong { get; set; }
        public double Temp { get; set; }
        public int TempD { get; set; }
        public double[] BeatFunction { get; set; }
        public double StartBeat { get; set; }
    }
}
