using NAudio.Wave;
using NAudio.Vorbis;

namespace Client
{
    public sealed class Music
    {
        private static string song;

        private static IWavePlayer waveOutDevice;
        private static VorbisWaveReader reader;

        public static void init()
        {
            if (!Preferences.music)
            {
                return;
            }
            reader = new VorbisWaveReader(song);
            waveOutDevice = new WaveOut();
#pragma warning disable CS0618 // Type or member is obsolete
            waveOutDevice.Volume = 0.5F;
#pragma warning restore CS0618 // Type or member is obsolete
            waveOutDevice.Init(reader);
            waveOutDevice.Play();
        }

        public static void WelcomeSound()
        {
            song = @"./sounds/tracks/Scott_Holmes_-_Cat_And_Mouse.ogg";
            init();
        }
        public static void Stop()
        {
            CloseWaveOut();
        }

        public static void Pause()
        {
            waveOutDevice.Pause();
        }

        public static void Resume()
        {
            waveOutDevice.Play();
        }

        private static void CloseWaveOut()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
            }
            //if (mainOutputStream != null)
            //{
            //    audioFileReader.Dispose();
            //    audioFileReader = null;
            //}
            if (waveOutDevice != null)
            {
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }
        }
    }
}
