using System;

namespace SoundPlayer
{
    public class Program
    {
        public static void Main()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"../../../../SoundPlayer/bensound-epic.wav");
            player.PlaySync();
        }
    }
}
