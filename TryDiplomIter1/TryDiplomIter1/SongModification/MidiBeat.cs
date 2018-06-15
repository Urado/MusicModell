using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryDiplomIter1.Music;

namespace TryDiplomIter1.SongModification
{
    class MidiBeat
    {
        public WavFile Data { get; private set; }

        MidiBeat(string File)
        {
            Data = WavFile.Read(File);
        }

    }
}
