using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Factories;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Heros;
using System;
using System.Collections.Generic;
using IngloriousHeros.Models.Armours;
using IngloriousHeros.Models.Weapons;
using IngloriousHeros.Models.SpecialSkills;
using System.Diagnostics;
using IngloriousHeros.Core.Game.Interfaces;

namespace IngloriousHeros.Core.Game
{
    public class World
    {
        private static IList<IHero> heroes = new List<IHero>();
        private static IList<IItem> items = new List<IItem>();
        private static IList<ISpecialSkills> robotSkills = new List<ISpecialSkills>();
        private static Location heroHB = new Location(1, 10);
        private static Location oponentHB = new Location(1, 90);
        private static Location bufferLocation = new Location(4, 0);
        private static Location outcomeLocation = new Location(26, 0);

        public World()
        {
        }

        public static IList<IHero> Heroes => heroes;

        public static IList<IItem> Items => items;

        public static IList<ISpecialSkills> RobotSkills => robotSkills;

        public static Location HeroHB => heroHB;

        public static Location OponentHB => oponentHB;

        public static Location BufferLocation => bufferLocation;

        public static Location OutcomeLocation => outcomeLocation;

        public static void InitializeEnvironment()
        {
            Console.Clear();
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;
            Console.BufferWidth = 120;
            Console.BufferHeight = 30;
            Console.CursorVisible = false;
        }

        public static void CreateWorld()
        {
            CreateRobotSkills();
            CreateHeroes();
            CreateItems();
        }

        private static void CreateHeroes()
        {
            heroes.Add(GameUnitFactory.CreateGameUnit<Wizzard>("Harry Potter", (sbyte)100, 3, 500, OponentHB, new List<IItem>()));
            heroes.Add(GameUnitFactory.CreateGameUnit<Gnome>("Tom", (sbyte)100, 3, 500, OponentHB, new List<IItem>()));
            heroes.Add(GameUnitFactory.CreateGameUnit<Jedi>("Neo from The Matrix", (sbyte)100, 6, 500, OponentHB, new List<IItem>()));
            heroes.Add(GameUnitFactory.CreateGameUnit<Warrior>("Iron Man", (sbyte)100, 3, 500, OponentHB, new List<IItem>()));
            heroes.Add(GameUnitFactory.CreateGameUnit<Archer>("Spiderman", (sbyte)100, 3, 500, OponentHB, new List<IItem>()));
            heroes.Add(GameUnitFactory.CreateGameUnit<Wizzard>("Gandalf", (sbyte)100, 3, 500, OponentHB, new List<IItem>()));
            heroes.Add(GameUnitFactory.CreateGameUnit<Gnome>("Gnomey", (sbyte)100, 3, 500, OponentHB, new List<IItem>()));
            heroes.Add(GameUnitFactory.CreateGameUnit<Jedi>("Luke Skywalker", (sbyte)100, 3, 500, OponentHB, new List<IItem>()));
            heroes.Add(GameUnitFactory.CreateGameUnit<Warrior>("Spartacus", (sbyte)100, 3, 500, OponentHB, new List<IItem>()));
        }

        private static void CreateItems()
        {
            items.Add(GameUnitFactory.CreateGameUnit<Helmet>(1));
            items.Add(GameUnitFactory.CreateGameUnit<Helmet>(2));
            items.Add(GameUnitFactory.CreateGameUnit<Helmet>(3));
            items.Add(GameUnitFactory.CreateGameUnit<Helmet>(4));
            items.Add(GameUnitFactory.CreateGameUnit<Helmet>(5));
            items.Add(GameUnitFactory.CreateGameUnit<Platemail>(1));
            items.Add(GameUnitFactory.CreateGameUnit<Platemail>(2));
            items.Add(GameUnitFactory.CreateGameUnit<Platemail>(3));
            items.Add(GameUnitFactory.CreateGameUnit<Platemail>(4));
            items.Add(GameUnitFactory.CreateGameUnit<Platemail>(5));
            items.Add(GameUnitFactory.CreateGameUnit<Ring>(1));
            items.Add(GameUnitFactory.CreateGameUnit<Ring>(2));
            items.Add(GameUnitFactory.CreateGameUnit<Ring>(3));
            items.Add(GameUnitFactory.CreateGameUnit<Ring>(4));
            items.Add(GameUnitFactory.CreateGameUnit<Ring>(5));
            items.Add(GameUnitFactory.CreateGameUnit<Shield>(1));
            items.Add(GameUnitFactory.CreateGameUnit<Shield>(2));
            items.Add(GameUnitFactory.CreateGameUnit<Shield>(3));
            items.Add(GameUnitFactory.CreateGameUnit<Shield>(4));
            items.Add(GameUnitFactory.CreateGameUnit<Shield>(5));
            items.Add(GameUnitFactory.CreateGameUnit<Laser>(1));
            items.Add(GameUnitFactory.CreateGameUnit<Laser>(2));
            items.Add(GameUnitFactory.CreateGameUnit<Laser>(3));
            items.Add(GameUnitFactory.CreateGameUnit<Laser>(4));
            items.Add(GameUnitFactory.CreateGameUnit<Laser>(5));
            items.Add(GameUnitFactory.CreateGameUnit<Spear>(1));
            items.Add(GameUnitFactory.CreateGameUnit<Spear>(2));
            items.Add(GameUnitFactory.CreateGameUnit<Spear>(3));
            items.Add(GameUnitFactory.CreateGameUnit<Spear>(4));
            items.Add(GameUnitFactory.CreateGameUnit<Spear>(5));
            items.Add(GameUnitFactory.CreateGameUnit<Staff>(1));
            items.Add(GameUnitFactory.CreateGameUnit<Staff>(2));
            items.Add(GameUnitFactory.CreateGameUnit<Staff>(3));
            items.Add(GameUnitFactory.CreateGameUnit<Staff>(4));
            items.Add(GameUnitFactory.CreateGameUnit<Staff>(5));
            items.Add(GameUnitFactory.CreateGameUnit<Sword>(1));
            items.Add(GameUnitFactory.CreateGameUnit<Sword>(2));
            items.Add(GameUnitFactory.CreateGameUnit<Sword>(3));
            items.Add(GameUnitFactory.CreateGameUnit<Sword>(4));
            items.Add(GameUnitFactory.CreateGameUnit<Sword>(5));
        }

        private static void CreateRobotSkills()
        {
            robotSkills.Add(GameUnitFactory.CreateGameUnit<RobotSkills>("RoboKiller", 2, 200, 50, 50));
            robotSkills.Add(GameUnitFactory.CreateGameUnit<RobotSkills>("RoboKing", 5, 200, 100, 100));
            robotSkills.Add(GameUnitFactory.CreateGameUnit<RobotSkills>("WorldDestroyer", 7, 200, 150, 150));
        }

        public static Process StartSoundPlayer()
        {
            return Process.Start(@"../../../../SoundPlayer/bin/Debug/SoundPlayer.exe");
        }
    }
}
