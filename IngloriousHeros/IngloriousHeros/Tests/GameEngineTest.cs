using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Factories;
using IngloriousHeros.Models.Heros;
using System;
using System.Collections.Generic;
using IngloriousHeros.Models.Armours;
using IngloriousHeros.Core.Game;
using System.Linq;

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
                new Helmet(50),
                //new Laser(5),
                //new Spear(5),
                //new Sword(5),
            };

            var heroes = World.Heroes.ToList();

            IHero Legolas = GameUnitFactory.CreateGameUnit<Archer>("Legolas", 100, 10, 300, World.HeroHB, weaponsLegolas);
            IHero OptimusPrime = GameUnitFactory.CreateGameUnit<Brute>("Optimus Prime", 100, 10, 1000, World.OponentHB, weaponsOptimusPrime);
            //IHero Gandalf = GameUnitFactory.CreateGameUnit<Wizzard>("Gandalf", 100, 2, 500, World.OponentHB, new List<IItem>());

            Battle epicBattle = new Battle(Legolas, OptimusPrime);
            epicBattle.Start();

            Console.ReadLine();
        }
    }
}
