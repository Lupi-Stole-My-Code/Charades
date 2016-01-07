using System.Media;

namespace Client
{
    public sealed class Music
    {
        private static SoundPlayer SP;

        public static void WelcomeSound()
        {
            if (!Preferences.music)
            {
                return;
            }
            SP = new SoundPlayer(@"./sounds/tracks/Scott_Holmes_-_Cat_And_Mouse.wav");
            SP.PlayLooping();
        }
        public static void Stop()
        {
            if (SP != null)
            {
                SP.Stop();
            }
        }

        public static void Resume()
        {
            if(SP != null)
            {
                SP.PlayLooping();
            }
        }
    }
}
