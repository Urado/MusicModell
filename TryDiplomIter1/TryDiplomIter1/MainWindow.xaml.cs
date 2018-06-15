using InteractiveDataDisplay.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TryDiplomIter1.SongParameterDetector;
using TryDiplomIter1.SongParameterDetector.SignalAnales;
using TryDiplomIter1.SongParameterDetector.MathAssistanse;
using TryDiplomIter1.SongModification;

namespace TryDiplomIter1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            double[] x;
            var lag = new LineGraph();

            var noteTest = new List<Note> { new Note { OctavNumber = 4, NoteNumber = 2 }, new Note { OctavNumber = 4, NoteNumber = 2 },
                new Note { OctavNumber = 4, NoteNumber = 2 }, new Note { OctavNumber = 4, NoteNumber = 6 },
                new Note { OctavNumber = 4, NoteNumber = 2 }, new Note { OctavNumber = 4, NoteNumber = 2 },
            new Note { OctavNumber = 4, NoteNumber = 2 }, new Note { OctavNumber = 4, NoteNumber = 6 },
            new Note { OctavNumber = 4, NoteNumber = 2 }, new Note { OctavNumber = 4, NoteNumber = 2 },
            new Note { OctavNumber = 4, NoteNumber = 2 }, new Note { OctavNumber = 4, NoteNumber = 6 }};

            var vm=new VM();

            Interface.DataContext = vm;

            //NoteScroll.DataContext = noteTest;
            //ListNote.ItemsSource = vm.Notes;
            //var spectrum = TestClass.Test1();
            double[] s1;// = spectrum.Select(v => v.Magnitude).ToArray();
            //double[] s2 = new double[s1.Length / 2];

            //x = new double[s1.Length];
            //for (int i = 0; i < x.Length; i++)
            //    x[i] = i;
            //lag.Plot(x, s1);
            //lines.Children.Add(lag);


            //x = new double[s1.Length/2];
            //for (int i = 0; i < x.Length; i++)
            //{
            //    x[i] = i;//-x.Length/2;
            //    s2[i] = s1[i];
            //}
            //lag.Plot(x, s2);
            //lines.Children.Add(lag);

            //s1 = Generators.Sin(1024, 128, 6000);
            //lag = new LineGraph();
            //lines.Children.Add(lag);
            //x = new double[s1.Length];
            //for (int i = 0; i < x.Length; i++)
            //    x[i] = i - x.Length / 2;
            //lag.Plot(x, s1);

            //var par = TestClass.Test6();




            //var Im = Generators.InpulseSignal(1024 * 32, 256, 1000);

            //s1 = Correlation.AutoCorrelation(TableFunction.TableToFunction(Im, 1, 0, Im.Length), 1, 0, Im.Length);//Generators.Sin(1024, 128, 6000); par.BeatFunction; //
            //lag = new LineGraph();
            //lines.Children.Add(lag);
            //x = new double[s1.Length];
            //for (int i = 0; i < x.Length; i++)
            //    x[i] = i;
            //lag.Plot(x, s1.Select(y => { return y; }));



            //s1 = new double[2048 * 32];
            //for (int j = 30; j < 35; j += 1)
            //{
            //    for (int i = 0; i < 2048 * 32; i++)
            //    {
            //        s1[i] = BeatPerMinutDetecter.ppp[j][i];
            //    }
            //    lag = new LineGraph();
            //    lines.Children.Add(lag);
            //    x = new double[s1.Length];
            //    for (int i = 0; i < x.Length; i++)
            //        x[i] = i;
            //    lag.Plot(x, s1);
            //}


            //for (int a = 0; a < 2048*16; a += 64)
            //{
            //    s1 = new double[128];
            //    for (int j = 0; j < 128; j += 1)
            //    {
            //        s1[j] = par.TransformSong[a, j];
            //    }
            //    lag = new LineGraph();
            //    lines.Children.Add(lag);
            //    x = new double[s1.Length];
            //    for (int i = 0; i < x.Length; i++)
            //        x[i] = i;
            //    lag.Plot(x, s1);
            //}

            //int sd = 1;
            //s1 = par.Song.Left.Select(y => { return (double)y; }).ToArray();//Generators.Sin(1024, 128, 6000);

            //lag = new LineGraph();
            //lines.Children.Add(lag);
            //x = new double[s1.Length];
            //for (int i = 0; i < x.Length; i++)
            //{
            //    x[i] = i / sd;
            //    s1[i] = s1[i] * 2;
            //}
            //lag.Plot(x, s1);

            //lag = new LineGraph();
            //lines.Children.Add(lag);
            //x = new double[1000];
            //double[] yc = new double[1000];

            //int BPM = par.TempD;
            //int S = (int)par.StartBeat;

            //for(int i=0; i * BPM + S< par.Song.Left.Length; i++)
            //{
            //    x[i * 8] = i * BPM + S;
            //    x[i * 8 + 1] = i * BPM + S;
            //    x[i * 8 + 2] = i * BPM + S;
            //    x[i * 8 + 3] = i * BPM + S;


            //    yc[i * 8] = 0;
            //    yc[i * 8 + 1] = 70000;
            //    yc[i * 8 + 2] = -70000;
            //    yc[i * 8 + 3] = 0;


            //    x[i * 8 +4] = i * BPM + S + 10;
            //    x[i * 8 + 4 + 1] = i * BPM + S+10;
            //    x[i * 8 + 2 + 4] = i * BPM + S+10;
            //    x[i * 8 + 3 + 4] = i * BPM + S+10;


            //    yc[i * 8 + 4] = 0;
            //    yc[i * 8 + 1 + 4] = 70000;
            //    yc[i * 8 + 2 + 4] = -70000;
            //    yc[i * 8 + 3 + 4] = 0;
            //}
            //lag.Stroke = new SolidColorBrush(Color.FromArgb(255, 200, 0, 0));
            //lag.Plot(x, yc);


            //lag = new LineGraph();
            //s1 = par.BeatFunction;//Correlation.Easy(TableFunction.TableToFunction(par.BeatFunction, 1, 0, par.BeatFunction.Length), 1, 0, par.BeatFunction.Length); //MaxAssistance.CompressFunc(Correlation.Easy(TableFunction.TableToFunction(par.BeatFunction, 1, 0, par.BeatFunction.Length), 1, 0, par.BeatFunction.Length/6), 1, 0);//
            //lag.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, (byte)(100), 0));
            //lines.Children.Add(lag);
            //x = new double[s1.Length];
            //for (int i = 0; i < x.Length; i++)
            //    x[i] = i;
            //lag.Plot(x, s1.Select(y => { return y; }));

            //var dat = FastFourierTransform.FFTSpectr(par.Song.Left.Select(y => { return (double)y; }).ToArray(), 0,1,12);
            //lag = new LineGraph();
            //lines.Children.Add(lag);
            //lag.Plot(dat.Select(v => { return v.Item1 * 8; }).ToArray(), dat.Select(v => { return v.Item2; }).ToArray());

            //dat = FastFourierTransform.FFTSpectr(par.Song.Left.Select(y => { return (double)y; }).ToArray(), 0, 2, 12);
            //lag = new LineGraph();
            //lines.Children.Add(lag);
            //lag.Plot(dat.Select(v => { return v.Item1 * 4; }).ToArray(), dat.Select(v => { return v.Item2; }).ToArray());

            //dat = FastFourierTransform.FFTSpectr(par.Song.Left.Select(y => { return (double)y; }).ToArray(), 0, 4, 12);
            //lag = new LineGraph();
            //lines.Children.Add(lag);
            //lag.Plot(dat.Select(v => { return v.Item1 * 2; }).ToArray(), dat.Select(v => { return v.Item2; }).ToArray());

            //dat = FastFourierTransform.FFTSpectr(par.Song.Left.Select(y => { return (double)y; }).ToArray(), 0, 8, 10);
            //lag = new LineGraph();
            //lines.Children.Add(lag);
            //lag.Plot(dat.Select(v => { return v.Item1 * 4; }).ToArray(), dat.Select(v => { return v.Item2; }).ToArray());


            //s1 = TestClass.Test3WTF();//Generators.Sin(1024, 128, 6000);
            //lag = new LineGraph();
            //lines.Children.Add(lag);
            //x = new double[s1.Length];
            //for (int i = 0; i < x.Length; i++)
            //    x[i] = i;
            //lag.Plot(x, s1);


            //var t4 = TestClass.Test4();
            //lag = new LineGraph();
            //lines.Children.Add(lag);
            //lag.Plot(t4.Select(v=> { return v.Item1; }).ToArray(), t4.Select(v => { return v.Item2; }).ToArray());



            //var t4 = TestClass.Test5();
            //lag = new LineGraph();
            //lines.Children.Add(lag);
            //lag.Plot(t4.Select(v => { return v.Item1; }).ToArray(), t4.Select(v => { return v.Item2; }).ToArray());

            //int k = 88 * 3;
            //int r = 1 << 3;

            //int N = k * r;

            //double[] x1 = new double[N];
            //double[] y1 = new double[N];
            //double[] c1 = new double[N];
            //for (int i = 0; i < k; i++)
            //{
            //    for (int j = 0; j < r; j++)
            //    {
            //        x1[i * r + j] = i;
            //        y1[i * r + j] = j * (44100 / (1 << 5));
            //        c1[i * r + j] = par.TransformSong[i * 5 * 100, j] / 1000;
            //    }
            //}

            //circles.PlotSize(x1, y1, c1);

            //for (int i = 0; i < k; i++)
            //{
            //    for (int j = 1; j < r; j++)
            //    {
            //        x1[i * r + j] = i;
            //        y1[i * r + j] = j * (44100 / 1<<5);
            //        c1[i * r + j] = BeatPerMinutDetecter.ppp[j][i * 5 * 100] / 1;
            //    }
            //}

            //circles.PlotSize(x1, y1, c1);

            //var t7 =TestClass.Test7();
            //int k = t7.Count;
            //int r = 1 << 6;

            //int N = k * r + k;

            //double[] x1 = new double[N];
            //double[] y1 = new double[N];
            //double[] c1 = new double[N];
            //double[] d1 = new double[N];
            //for (int i = 0; i < k; i++)
            //{

            //    double max = 0;
            //    int maxCh = 1;
            //    for (int j = 0; j < 32; j++)
            //    {
            //        if (t7[i][j].Item2 > max)
            //        {
            //            max = t7[i][j].Item2;
            //            maxCh = (int)t7[i][j].Item1;
            //        }
            //    }


            //    for (int j = 0; j < t7[i].Length&&j<r; j++)
            //    {
            //        x1[i * r + j] = i;
            //        y1[i * r + j] = j;
            //        c1[i * r + j] = t7[i][j].Item2/3;
            //        d1[i * r + j] = 0;
            //        //if (j == maxCh - 1)
            //        //{
            //        //    d1[i * r + j] = 1;

            //        //    x1[k * r + i] = i;
            //        //    y1[k * r + i] = j;
            //        //    c1[k * r + i] = t7[i][j].Item2;
            //        //    d1[k * r + i] = 1;
            //        //}
            //    }
            //}

            //circles.PlotColorSize(x1, y1,d1, c1);

        }
    }
}
