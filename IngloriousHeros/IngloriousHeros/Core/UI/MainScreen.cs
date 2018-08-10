using IngloriousHeros.Core.UI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Heros;
using IngloriousHeros.Core.Factories;
using IngloriousHeros.Models.Common;

namespace IngloriousHeros.Core.UI
{
    class MainScreen
    {
        private static MainScreen instanceHolder;

        //Caption properties
        private static Location captionOne = new Location(0, 0);
        private const string captionOneValue = "inglorious";
        private readonly IFont captionOneFont = new FontEmptyLetters();
        private static Location captionTwo = new Location(70, 9);
        private const string captionTwoValue = "heros";
        private readonly IFont captionTwoFont = new FontEmptyLetters();
        private static Location captionThree = new Location(0, 20);
        private const string captionThreeValue = "choose hero";
        private readonly IFont captionThreeFont = new FontEmptyLetters();

        //HerosModels properties
        private static Location archerModel = new Location(0, 30);
        private static Location warriorModel = new Location(40, 30);
        private static Location gnomeModel = new Location(80, 30);
        private static Location wizzardModel = new Location(0, 55);
        private static Location jediModel = new Location(40, 55);
        private static Location bruteModel = new Location(80, 55);

        private static int horizontalStep = (archerModel.Row + warriorModel.Row + gnomeModel.Row) / 3;
        private static int verticalStep = archerModel.Col - wizzardModel.Col;

        private MainScreen()
        {

        }

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
            drawType.CaptionLeftRight(captionOne.Row, captionOne.Col, captionOneValue, captionOneFont);
            drawType.CaptionLeftRight(captionTwo.Row, captionTwo.Col, captionTwoValue, captionTwoFont);
            drawType.CaptionBlinking(captionThree.Row, captionThree.Col, captionThreeValue, captionThreeFont);
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
                    startRow += horizontalStep;
                    drawType.HeroModel(startRow, startCol, true);
                }
                if (key.Key == ConsoleKey.LeftArrow
                    && startRow != ArcherModel.Row)
                {
                    drawType.HeroModel(startRow, startCol);
                    startRow -= horizontalStep;
                    drawType.HeroModel(startRow, startCol, true);
                }
                if (key.Key == ConsoleKey.UpArrow
                    && startCol != ArcherModel.Col)
                {
                    drawType.HeroModel(startRow, startCol);
                    startCol -= verticalStep;
                    drawType.HeroModel(startRow, startCol, true);
                }
                if (key.Key == ConsoleKey.DownArrow
                    && startCol != WizzardModel.Col)
                {
                    drawType.HeroModel(startRow, startCol);
                    startCol += verticalStep;
                    drawType.HeroModel(startRow, startCol, true);
                }
                key = Console.ReadKey(true);
            }
            IHero heroInstance = GameUnitFactory.CreateGameUnit<Archer>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>());
            if ((startRow == WarriorModel.Row) && (startCol == WarriorModel.Row))
            { heroInstance = GameUnitFactory.CreateGameUnit<Brute>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>()); }
            if ((startRow == GnomeModel.Row) && (startCol == GnomeModel.Row))
            { heroInstance = GameUnitFactory.CreateGameUnit<Gnome>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>()); }
            if ((startRow == BruteModel.Row) && (startCol == BruteModel.Row))
            { heroInstance = GameUnitFactory.CreateGameUnit<Jedi>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>()); }
            if ((startRow == JediModel.Row) && (startCol == JediModel.Row))
            { heroInstance = GameUnitFactory.CreateGameUnit<Warrior>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>()); }
            if ((startRow == WizzardModel.Row) && (startCol ==WizzardModel.Row))
            { heroInstance = GameUnitFactory.CreateGameUnit<Wizzard>("Legolas", 100, 10, 300, World.HeroHB, new List<IItem>()); }

            return heroInstance;
        }
    }
}
