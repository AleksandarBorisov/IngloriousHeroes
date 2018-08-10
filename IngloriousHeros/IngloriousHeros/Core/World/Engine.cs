using IngloriousHeros.Core.Contracts;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Factories;
using System.Collections.Generic;
using IngloriousHeros.Models.Heros;
using System;

namespace IngloriousHeros.Core
{
    public class Engine : IEngine
    {
        public static void Run()
        {
            //TODO: Implement everything
            IHero hero = MainScreen.Instance.Start();
            Console.WriteLine();
            //Game.Start(hero);
        }
    }
}
