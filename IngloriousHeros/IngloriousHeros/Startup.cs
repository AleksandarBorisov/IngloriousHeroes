using IngloriousHeros.Core;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.UI;

namespace IngloriousHeros
{
    public class Startup
    {
        public static void Main()
        {

            // Build the SoundPlayer project (F6 only) before starting the game in order to have music

            IHero hero = MainScreen.Instance.Start();
            GameEngine.Run(hero);
        }
    }
}
