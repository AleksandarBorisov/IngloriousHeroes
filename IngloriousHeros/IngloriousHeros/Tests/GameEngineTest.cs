using IngloriousHeros.Contracts;
using IngloriousHeros.Core.Factories;
using IngloriousHeros.Models.Heros;
using System;
using System.Collections.Generic;
using IngloriousHeros.Models.Armours;
using IngloriousHeros.Core.Battle;
using IngloriousHeros.Core;

namespace IngloriousHeros.Tests
{
    public static class GameEngineTest
    {
        public static void Run()
        {
            World.InitializeEnvironment();
            World.CreateWorld();

            // Item and hero creation will eventualy go to World.CreateWorld()
            List<IItem> weaponsLegolas = new List<IItem>()
            {
                //new Laser(10),
                //new Spear(5),
                //new Helmet(5,100),
                new Helmet(50),
                //new Ring(20),
                //new Helmet(5,100),
                //new Laser(5)
            };
            List<IItem> weaponsOptimusPrime = new List<IItem>()
            {
                //new Staff(5),
                new Helmet(50),
                //new Laser(5),
                //new Spear(5),
                //new Sword(5),
            };

            IHero Legolas = GameUnitFactory.CreateGameUnit<Archer>("Legolas", 100, 1, 100, World.HeroHB, weaponsLegolas);
            IHero OptimusPrime = GameUnitFactory.CreateGameUnit<Brute>("Optimus Prime", 100, 1, 110, World.OponentHB, weaponsOptimusPrime);

            Battle epicBattle = new Battle(Legolas, OptimusPrime);
            epicBattle.Start();

            Console.ReadLine();
        }
    }
}
