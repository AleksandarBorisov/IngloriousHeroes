using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Factories;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Heros;
using System;
using System.Collections.Generic;
using IngloriousHeros.Models.Armours;
using IngloriousHeros.Models.Weapons;

namespace IngloriousHeros.Core.Game
{
    public static class World
    {
        private static IEnumerable<IHero> heroes;
        private static IEnumerable<IItem> items;
        private static Location heroHB = new Location(1, 10);
        private static Location oponentHB = new Location(1, 90);
        private static Location bufferLocation = new Location(4, 0);
        private static Location outcomeLocation = new Location(26, 0);

        //static World()
        //{
        //    heroes = new List<IHero>();
        //    weapons = new List<IItem>();
        //    armours = new List<IItem>();
        //    specialItems = new List<IItem>();
        //}

        public static IEnumerable<IHero> Heroes => heroes;

        public static IEnumerable<IItem> Items => items;

        public static Location HeroHB => heroHB;

        public static Location OponentHB => oponentHB;

        public static Location BufferLocation => bufferLocation;

        public static Location OutcomeLocation => outcomeLocation;

        public static void InitializeEnvironment()
        {
            Console.WindowWidth = 120;
            Console.BufferWidth = Console.WindowWidth;
            Console.WindowHeight = 30;
            Console.BufferHeight = Console.WindowHeight;
            Console.CursorVisible = false;
        }

        public static void CreateWorld()
        {
            CreateHeroes();
            CreateItems();
        }

        private static void CreateHeroes()
        {
            heroes = new List<IHero>
            {
                GameUnitFactory.CreateGameUnit<Archer>("Legolas", 100, 3, 500, OponentHB, new List<IItem>()),
                GameUnitFactory.CreateGameUnit<Wizzard>("Harry Potter", 100, 3, 500, OponentHB, new List<IItem>()),
                GameUnitFactory.CreateGameUnit<Gnome>("Tom", 100, 3, 500, OponentHB, new List<IItem>()),
                GameUnitFactory.CreateGameUnit<Jedi>("Neo from The Matrix", 100, 3, 500, OponentHB, new List<IItem>()),
                GameUnitFactory.CreateGameUnit<Warrior>("Iron Man", 100, 3, 500, OponentHB, new List<IItem>()),
                GameUnitFactory.CreateGameUnit<Archer>("Spiderman", 100, 3, 500, OponentHB, new List<IItem>()),
                GameUnitFactory.CreateGameUnit<Wizzard>("Gandalf", 100, 3, 500, OponentHB, new List<IItem>()),
                GameUnitFactory.CreateGameUnit<Gnome>("Gnomey", 100, 3, 500, OponentHB, new List<IItem>()),
                GameUnitFactory.CreateGameUnit<Jedi>("Luke Skywalker", 100, 3, 500, OponentHB, new List<IItem>()),
                GameUnitFactory.CreateGameUnit<Warrior>("Spartacus", 100, 3, 500, OponentHB, new List<IItem>())
            };
        }

        private static void CreateItems()
        {
            items = new List<IItem>()
            {
                GameUnitFactory.CreateGameUnit<Helmet>(1),
                GameUnitFactory.CreateGameUnit<Helmet>(2),
                GameUnitFactory.CreateGameUnit<Helmet>(3),
                GameUnitFactory.CreateGameUnit<Helmet>(4),
                GameUnitFactory.CreateGameUnit<Helmet>(5),
                GameUnitFactory.CreateGameUnit<Platemail>(1),
                GameUnitFactory.CreateGameUnit<Platemail>(2),
                GameUnitFactory.CreateGameUnit<Platemail>(3),
                GameUnitFactory.CreateGameUnit<Platemail>(4),
                GameUnitFactory.CreateGameUnit<Platemail>(5),
                GameUnitFactory.CreateGameUnit<Ring>(1),
                GameUnitFactory.CreateGameUnit<Ring>(2),
                GameUnitFactory.CreateGameUnit<Ring>(3),
                GameUnitFactory.CreateGameUnit<Ring>(4),
                GameUnitFactory.CreateGameUnit<Ring>(5),
                GameUnitFactory.CreateGameUnit<Shield>(1),
                GameUnitFactory.CreateGameUnit<Shield>(2),
                GameUnitFactory.CreateGameUnit<Shield>(3),
                GameUnitFactory.CreateGameUnit<Shield>(4),
                GameUnitFactory.CreateGameUnit<Shield>(5),
                GameUnitFactory.CreateGameUnit<Laser>(1),
                GameUnitFactory.CreateGameUnit<Laser>(2),
                GameUnitFactory.CreateGameUnit<Laser>(3),
                GameUnitFactory.CreateGameUnit<Laser>(4),
                GameUnitFactory.CreateGameUnit<Laser>(5),
                GameUnitFactory.CreateGameUnit<Spear>(1),
                GameUnitFactory.CreateGameUnit<Spear>(2),
                GameUnitFactory.CreateGameUnit<Spear>(3),
                GameUnitFactory.CreateGameUnit<Spear>(4),
                GameUnitFactory.CreateGameUnit<Spear>(5),
                GameUnitFactory.CreateGameUnit<Staff>(1),
                GameUnitFactory.CreateGameUnit<Staff>(2),
                GameUnitFactory.CreateGameUnit<Staff>(3),
                GameUnitFactory.CreateGameUnit<Staff>(4),
                GameUnitFactory.CreateGameUnit<Staff>(5),
                GameUnitFactory.CreateGameUnit<Sword>(1),
                GameUnitFactory.CreateGameUnit<Sword>(2),
                GameUnitFactory.CreateGameUnit<Sword>(3),
                GameUnitFactory.CreateGameUnit<Sword>(4),
                GameUnitFactory.CreateGameUnit<Sword>(5),
            };
        }
    }
}
