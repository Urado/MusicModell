using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDiplomIter1.Music
{
    public class WavFile
    {
        public string path;
        //-----WaveHeader-----
        public char[] sGroupID; // RIFF
        public uint dwFileLength; // total file length minus 8, which is taken up by RIFF
        public char[] sRiffType;// always WAVE

        //-----WaveFormatChunk-----
        public char[] sFChunkID;         // Four bytes: "fmt "
        public uint dwFChunkSize;        // Length of header in bytes
        public ushort wFormatTag;       // 1 (MS PCM)
        public ushort wChannels;        // Number of channels
        public uint dwSamplesPerSec;    // Frequency of the audio in Hz... 44100
        public uint dwAvgBytesPerSec;   // for estimating RAM allocation
        public ushort wBlockAlign;      // sample frame size, in bytes
        public ushort wBitsPerSample;    // bits per sample

        //-----WaveDataChunk-----
        public char[] sDChunkID;     // "data"
        public uint dwDChunkSize;    // Length of header in bytes
        public byte dataStartPos;  // audio data start position
        public List<Int16> DataList= new List<short>();

        public WavFile()
        {
            path = Environment.CurrentDirectory;
            //-----WaveHeader-----
            dwFileLength = 0;
            sGroupID = "RIFF".ToCharArray();
            sRiffType = "WAVE".ToCharArray();

            //-----WaveFormatChunk-----
            sFChunkID = "fmt ".ToCharArray();
            dwFChunkSize = 16;
            wFormatTag = 1;
            wChannels = 2;
            dwSamplesPerSec = 44100;
            wBitsPerSample = 16;
            wBlockAlign = (ushort)(wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;

            //-----WaveDataChunk-----
            dataStartPos = 44;
            dwDChunkSize = 0;
            sDChunkID = "data".ToCharArray();
        }

        public static WavFile Read(string Path)
        {
            var wavFile = new WavFile();

            wavFile.path = Path;//@"C:\Rammstein - Kokain.wav";
            FileStream fsr = new FileStream(wavFile.path, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fsr);
            wavFile.sGroupID = r.ReadChars(4);
            wavFile.dwFileLength = r.ReadUInt32();
            wavFile.sRiffType = r.ReadChars(4);
            wavFile.sFChunkID = r.ReadChars(4);
            wavFile.dwFChunkSize = r.ReadUInt32();
            wavFile.wFormatTag = r.ReadUInt16();
            wavFile.wChannels = r.ReadUInt16();
            wavFile.dwSamplesPerSec = r.ReadUInt32();
            wavFile.dwAvgBytesPerSec = r.ReadUInt32();
            wavFile.wBlockAlign = r.ReadUInt16();
            wavFile.wBitsPerSample = r.ReadUInt16();
            wavFile.sDChunkID = r.ReadChars(4);
            wavFile.dwDChunkSize = r.ReadUInt32();
            wavFile.dataStartPos = (byte)r.BaseStream.Position;

            //

            r.BaseStream.Position += wavFile.dwDChunkSize;

            wavFile.sDChunkID = r.ReadChars(4);
            wavFile.dwDChunkSize = r.ReadUInt32();
            int n = (int)(wavFile.dwDChunkSize /  wavFile.wBitsPerSample*8);
            for (int i = 0; i < n; i++)
            {
                Int16 tmp = 0;
                tmp = r.ReadInt16();
                wavFile.DataList.Add(tmp);
            }

            //wavFile.sDChunkID = r.ReadChars(4);
            //wavFile.dwDChunkSize = r.ReadUInt32();

            r.Close();
            fsr.Close();

            return wavFile;
        }


        public static WavFile Read2(string Path)
        {
            var wavFile = new WavFile();

            wavFile.path = Path;//@"C:\Rammstein - Kokain.wav";
            FileStream fsr = new FileStream(wavFile.path, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fsr);
            wavFile.sGroupID = r.ReadChars(4);
            wavFile.dwFileLength = r.ReadUInt32();
            wavFile.sRiffType = r.ReadChars(4);
            wavFile.sFChunkID = r.ReadChars(4);
            wavFile.dwFChunkSize = r.ReadUInt32();
            wavFile.wFormatTag = r.ReadUInt16();
            wavFile.wChannels = r.ReadUInt16();
            wavFile.dwSamplesPerSec = r.ReadUInt32();
            wavFile.dwAvgBytesPerSec = r.ReadUInt32();
            wavFile.wBlockAlign = r.ReadUInt16();
            wavFile.wBitsPerSample = r.ReadUInt16();
            wavFile.sDChunkID = r.ReadChars(4);
            wavFile.dwDChunkSize = r.ReadUInt32();
            wavFile.dataStartPos = (byte)r.BaseStream.Position;

            //

            //r.BaseStream.Position += wavFile.dwDChunkSize;

            //wavFile.sDChunkID = r.ReadChars(4);
            //wavFile.dwDChunkSize = r.ReadUInt32();
            int n = (int)(wavFile.dwDChunkSize / wavFile.wBitsPerSample * 8);
            for (int i = 0; i < n; i++)
            {
                Int16 tmp = 0;
                tmp = r.ReadInt16();
                wavFile.DataList.Add(tmp);
            }

            //wavFile.sDChunkID = r.ReadChars(4);
            //wavFile.dwDChunkSize = r.ReadUInt32();

            r.Close();
            fsr.Close();

            return wavFile;
        }

        public static void Write(string Path,WavFile wavFile)
        {

            FileStream fsr = new FileStream(Path, FileMode.Create, FileAccess.Write);
            BinaryWriter r = new BinaryWriter(fsr);

            r.Write(wavFile.sGroupID);
            r.Write(wavFile.dwFileLength);
            r.Write(wavFile.sRiffType);
            r.Write(wavFile.sFChunkID);
            r.Write(wavFile.dwFChunkSize);
            r.Write(wavFile.wFormatTag);
            r.Write(wavFile.wChannels);
            r.Write(wavFile.dwSamplesPerSec);
            r.Write(wavFile.dwAvgBytesPerSec);
            r.Write(wavFile.wBlockAlign);
            r.Write(wavFile.wBitsPerSample);
            r.Write(wavFile.sDChunkID);
            r.Write(wavFile.dwDChunkSize*2);


            int n = (int)(wavFile.dwDChunkSize /  wavFile.wBitsPerSample*8);
            for (int i = 0; i < n; i++)
            {
                Int16 tmp = 0;
                tmp=wavFile.DataList[i];
                r.Write(tmp);
            }

            r.Close();
            fsr.Close();
        }


    }
}
