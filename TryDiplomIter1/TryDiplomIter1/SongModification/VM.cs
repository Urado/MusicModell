using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TryDiplomIter1.Music;
using TryDiplomIter1.SongParameterDetector;
using TryDiplomIter1.SongParameterDetector.SignalAnales;

namespace TryDiplomIter1.SongModification
{
    class VM : BaseViewModel
    {
        public ObservableCollection<Note> Notes
        {
            get;
            set;
        }
        public MusicModelOption MusicOption { get => musicOption; set { musicOption = value; OnPropertyChanged(nameof(MusicOption)); } }

        private MusicModelOption musicOption;

        public VM()
        {
            TestStart();
        }

        public void TestStart()
        {
            int MelodySize = 44100 * 3;
            int Start = 44100 * 90;//44100 * 30;//

            var ret = new List<Tuple<double, double>[]>();

            var musik = WavFile.Read(@"D:\Test2.wav");

            var musik1 = WavFile.Read(@"D:\Test2.wav");

            var bitW = WavFile.Read2(@"D:\TestBit.wav");

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
                BPMd = param.TempD//(int)(( 60/140d) * 44100)//
                , StartSd = param.TempD /// /2+ 500
            };

            musicOption = new MusicModelOption { ModLevel = 0.5, Tempo = 143 };

            Notes = new ObservableCollection<Note>(MusicModifaer.ModelCreator(musik,Mod));

            MusicModifaer.MusicMod2(musik, musik1, bitW, null, Mod);

            WavFile.Write(@"D:\TestB.wav", musik);
        }
    }

    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
