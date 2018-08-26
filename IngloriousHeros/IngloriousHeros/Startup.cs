using IngloriousHeros.Core;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Config;
using Autofac;

namespace IngloriousHeros
{
    public class Startup
    {
        public static void Main()
        {
            // Build the SoundPlayer & ThemeSong projects (F6 only) 
            // before starting the game in order to have music

            var container = AutofacConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var mainScreen = scope.Resolve<IMainScreen>();
                IHero hero = mainScreen.Start();

                var newGame = scope.Resolve<GameEngine>(new TypedParameter(typeof(IHero), hero));
                newGame.Run();
            }
        }
    }
}
