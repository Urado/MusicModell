using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDiplomIter1.SongParameterDetector
{

    class Note
    {
        public String NoteString { get; private set; }
        public int OctavNumber { get; set; }
        private double time;
        public string TimeString { get; set; }
        public int NoteNumber { get => noteNumber; set { noteNumber = value; NoteString = NumberToString(value); } }

        public double Time { get => time; set { time = value; TimeString = TimeToTimeString(value); } }

        private int noteNumber;

        public static string TimeToTimeString(double time)
        {
            return String.Format("{0},{1:f2}", (int)(time / 60), time - ((int)(time / 60)) * 60);
        }

        public static string NumberToString(int n)
        {
            var ret = "";
            switch (n)
            {
                case 1:
                    ret = "A";
                    break;
                case 2:
                    ret = "A#";
                    break;
                case 3:
                    ret = "H";
                    break;
                case 4:
                    ret = "C";
                    break;
                case 5:
                    ret = "C#";
                    break;
                case 6:
                    ret = "D";
                    break;
                case 7:
                    ret = "D#";
                    break;
                case 8:
                    ret = "E";
                    break;
                case 9:
                    ret = "F";
                    break;
                case 10:
                    ret = "F#";
                    break;
                case 11:
                    ret = "G";
                    break;
                case 12:
                    ret = "G#";
                    break;
                default:
                    ret = "None";
                    break;
            }



            return ret;
        }
    }
}
