using IngloriousHeros.Core.UI.Models;
using System;
using System.Collections.Generic;
using IngloriousHeros.Models.Heros;
using IngloriousHeros.Core.Factories;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Core.Contracts;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;

namespace IngloriousHeros.Core.UI
{
    class MainScreen
    {
        private static MainScreen instanceHolder;

        //Caption fields
        private static Location captionOne = new Location(0, 0);
        private static string captionOneValue = "inglorious";
        private static IFont captionOneFont = new FontEmptyLetters();
        private static Location captionTwo = new Location(70, 9);
        private static string captionTwoValue = "heros";
        private static IFont captionTwoFont = new FontEmptyLetters();
        private static Location captionThree = new Location(0, 20);
        private static string captionThreeValue = "choose hero";
        private static IFont captionThreeFont = new FontSolidLetters();

        //HerosModels fields
        private static Location archerModel = new Location(0, 30);
        private static Location warriorModel = new Location(40, 30);
        private static Location gnomeModel = new Location(80, 30);
        private static Location wizzardModel = new Location(0, 55);
        private static Location jediModel = new Location(40, 55);
        private static Location bruteModel = new Location(80, 55);

        private static int horizontalStep = (ArcherModel.Row + WarriorModel.Row + GnomeModel.Row) / 3;
        private static int verticalStep = Math.Abs(ArcherModel.Col - WizzardModel.Col);

        private MainScreen()
        {

        }

        public static Location CaptionOne => captionOne;

        public static string CaptionOneValue => captionOneValue;

        public static IFont CaptionOneFont => captionOneFont;

        public static Location CaptionTwo => captionTwo;

        public static string CaptionTwoValue => captionTwoValue;

        public static IFont CaptionTwoFont => captionTwoFont;

        public static Location CaptionThree => captionThree;

        public static string CaptionThreeValue => captionThreeValue;

        public static IFont CaptionThreeFont => captionThreeFont;

        public static int HorizontalStep => horizontalStep;

        public static int VerticalStep => verticalStep;

        public static Location ArcherModel => archerModel;

        public static Location WarriorModel => warriorModel;

        public static Location GnomeModel => gnomeModel;

        public static Location BruteModel => bruteModel;

        public static Location JediModel => jediModel;

        public static Location WizzardModel => wizzardModel;


        public static MainScreen Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new MainScreen();
                }

                return instanceHolder;
            }
        }

        public IHero Start()
        {
            Draw drawType = Draw.Instance;
            drawType.CaptionLeftRight(CaptionOne.Row, CaptionOne.Col, CaptionOneValue, CaptionOneFont);
            drawType.CaptionLeftRight(CaptionTwo.Row, CaptionTwo.Col, CaptionTwoValue, CaptionTwoFont);
            drawType.CaptionBlinking(CaptionThree.Row, CaptionThree.Col, CaptionThreeValue, CaptionThreeFont);
            drawType.HeroModel(ArcherModel.Row, ArcherModel.Col, true);
            drawType.HeroModel(WarriorModel.Row, WarriorModel.Col);
            drawType.HeroModel(GnomeModel.Row, GnomeModel.Col);
            drawType.HeroModel(BruteModel.Row, BruteModel.Col);
            drawType.HeroModel(JediModel.Row, JediModel.Col);
            drawType.HeroModel(WizzardModel.Row, WizzardModel.Col);
            ConsoleKeyInfo key = Console.ReadKey(true);
            int startRow = ArcherModel.Row;
            int startCol = ArcherModel.Col;
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.RightArrow
                    && startRow != GnomeModel.Row)
                {
                    drawType.HeroModel(startRow, startCol);
                    startRow += HorizontalStep;
                    drawType.HeroModel(startRow, startCol, true);
                }
                if (key.Key == ConsoleKey.LeftArrow
                    && startRow != ArcherModel.Row)
                {
                    drawType.HeroModel(startRow, startCol);
                    startRow -= HorizontalStep;
                    drawType.HeroModel(startRow, startCol, true);
                }
                if (key.Key == ConsoleKey.UpArrow
                    && startCol != ArcherModel.Col)
                {
                    drawType.HeroModel(startRow, startCol);
                    startCol -= VerticalStep;
                    drawType.HeroModel(startRow, startCol, true);
                }
                if (key.Key == ConsoleKey.DownArrow
                    && startCol != WizzardModel.Col)
                {
                    drawType.HeroModel(startRow, startCol);
                    startCol += VerticalStep;
                    drawType.HeroModel(startRow, startCol, true);
                }
                key = Console.ReadKey(true);
            }
            IHero heroInstance = GameUnitFactory.CreateGameUnit<Archer>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>());
            if ((startRow == WarriorModel.Row) && (startCol == WarriorModel.Col))
            { heroInstance = GameUnitFactory.CreateGameUnit<Warrior>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>()); }
            if ((startRow == GnomeModel.Row) && (startCol == GnomeModel.Col))
            { heroInstance = GameUnitFactory.CreateGameUnit<Gnome>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>()); }
            if ((startRow == BruteModel.Row) && (startCol == BruteModel.Col))
            { heroInstance = GameUnitFactory.CreateGameUnit<Brute>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>()); }
            if ((startRow == JediModel.Row) && (startCol == JediModel.Col))
            { heroInstance = GameUnitFactory.CreateGameUnit<Jedi>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>()); }
            if ((startRow == WizzardModel.Row) && (startCol ==WizzardModel.Col))
            { heroInstance = GameUnitFactory.CreateGameUnit<Wizzard>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>()); }

            return heroInstance;
        }
    }
}
