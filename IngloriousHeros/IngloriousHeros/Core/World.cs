using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Common;
using System;
using System.Collections.Generic;

namespace IngloriousHeros.Core
{
    public static class World
    {
        private static IEnumerable<IHero> heroes;
        private static IEnumerable<IItem> weapons;
        private static IEnumerable<IItem> armours;
        private static IEnumerable<IItem> specialItems;
        private static Location heroHB = new Location(1, 10);
        private static Location oponentHB = new Location(1, 90);
        private static Location bufferLocation = new Location(4, 0);
        private static Location outcomeLocation = new Location(26, 0);

        static World()
        {
            heroes = new List<IHero>();
            weapons = new List<IItem>();
            armours = new List<IItem>();
            specialItems = new List<IItem>();
        }

        public static IEnumerable<IHero> Heroes => heroes;

        public static IEnumerable<IItem> Weapons => weapons;

        public static IEnumerable<IItem> Armours => armours;

        public static IEnumerable<IItem> SpecialItems => specialItems;

        public static Location HeroHB => heroHB;

        public static Location OponentHB => oponentHB;

        public static Location BufferLocation => bufferLocation;

        public static Location OutcomeLocation => outcomeLocation;

        public static void InitializeEnvironment()
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;
            Console.CursorVisible = false;
        }

        public static void CreateWorld()
        {
            CreateHeroes();
            CreateWeapons();
            CreateArmours();
            CreateSpecialItems();
        }

        private static void CreateHeroes()
        {
            // Create a list of heros
        }

        private static void CreateWeapons()
        {
            // Create a list of weapons
        }

        private static void CreateArmours()
        {
            // Create a list of armours
        }

        private static void CreateSpecialItems()
        {
            // Create a list of special items
        }
    }
}
