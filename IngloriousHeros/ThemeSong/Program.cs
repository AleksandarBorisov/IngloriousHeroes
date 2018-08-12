using System;

namespace ThemeSong
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"../../../../ThemeSong/bensound-happyrock.wav");
            player.PlaySync();
        }
    }
}
