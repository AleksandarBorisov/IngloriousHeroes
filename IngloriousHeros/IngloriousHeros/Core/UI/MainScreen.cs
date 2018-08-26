using System;
using System.Collections.Generic;
using IngloriousHeros.Models.Heros;
using IngloriousHeros.Core.Factories;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.UI.DrawCaption.Factory;
using IngloriousHeros.Core.UI.DrawModel.Factory;
using System.Linq;
using System.Diagnostics;
using Autofac;

namespace IngloriousHeros.Core.UI
{
    public class MainScreen : IMainScreen
    {
        //Caption fields
        private IDrawCaptionFactory drawCaptionFactory;
        private IDrawModelFactory drawModelFactory;
        private Location userName = new Location(55, 25);
        private int currentModelIndex = 0;
        private int maxModelsPerRow = 3;
        private IComponentContext autofacContext;

        public MainScreen(IDrawCaptionFactory drawCaptionFactory,
            IDrawModelFactory drawModelFactory,
            IComponentContext autofacContext)
        {
            this.drawCaptionFactory = drawCaptionFactory;
            this.drawModelFactory = drawModelFactory;
            this.autofacContext = autofacContext;
        }

        public Location UserName => userName;

        public int CurrentModelIndex {get { return this.currentModelIndex; } set { this.currentModelIndex = value; } }

        public int MaxModelsPerRow => maxModelsPerRow;

        public IHero Start()
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.CursorVisible = false;
            Process themeSong = Process.Start(@"../../../../ThemeSong/bin/Debug/ThemeSong.exe");

            //This list will come from class World
            var listOfCaptions = new List<string>()
            {
                //"DrawCaptionLeftRight,0,0,inglorious,FontEmptyLetters,50",
                //"DrawCaptionLeftRight,70,9,heros,FontEmptyLetters,50",
                "DrawCaptionBlinking,0,20,choose hero,FontSolidLetters,200",
            };

            ProcessCaptionCommands(listOfCaptions);

            //This list will also come from class World
            var listOfModels = new List<string>()
            {
                "DrawModelHero,0,30,true,ArcherModel",
                "DrawModelHero,40,30,false,WarriorModel",
                "DrawModelHero,80,30,false,GnomeModel",
                "DrawModelHero,0,55,false,WizzardModel",
                "DrawModelHero,40,55,false,JediModel",
                "DrawModelHero,80,55,false,BruteModel",
            };

            foreach (var model in listOfModels)
            {
                ProcessSingleModelCommand(model);
            }

            ConsoleKeyInfo key = Console.ReadKey(true);

            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.RightArrow
                    && CurrentModelIndex % MaxModelsPerRow < MaxModelsPerRow - 1
                    && CurrentModelIndex < (listOfModels.Count - 1))
                {
                    ProcessSingleModelCommand(listOfModels[CurrentModelIndex].Replace("true", "false"));
                    CurrentModelIndex++;
                    ProcessSingleModelCommand(listOfModels[CurrentModelIndex].Replace("false", "true"));
                }

                if (key.Key == ConsoleKey.LeftArrow
                    && CurrentModelIndex % MaxModelsPerRow > 0)
                {
                    ProcessSingleModelCommand(listOfModels[CurrentModelIndex].Replace("true", "false"));
                    CurrentModelIndex--;
                    ProcessSingleModelCommand(listOfModels[CurrentModelIndex].Replace("false", "true"));
                }

                if (key.Key == ConsoleKey.UpArrow
                    && CurrentModelIndex / MaxModelsPerRow > 0)
                {
                    ProcessSingleModelCommand(listOfModels[CurrentModelIndex].Replace("true", "false"));
                    CurrentModelIndex -= MaxModelsPerRow;
                    ProcessSingleModelCommand(listOfModels[CurrentModelIndex].Replace("false", "true"));
                }

                if (key.Key == ConsoleKey.DownArrow
                    && (currentModelIndex + MaxModelsPerRow < listOfModels.Count))
                {
                    ProcessSingleModelCommand(listOfModels[CurrentModelIndex].Replace("true", "false"));
                    CurrentModelIndex += MaxModelsPerRow;
                    ProcessSingleModelCommand(listOfModels[CurrentModelIndex].Replace("false", "true"));
                }

                key = Console.ReadKey(true);
            }

            Console.Clear();
            //You already know where this list comes from
            var listOfAfterCredits = new List<string>()
            {
                "DrawCaptionLeftRight,33,5,choose,FontSolidLetters,0",
                "DrawCaptionLeftRight,21,15,username,FontSolidLetters,0",
            };

            ProcessCaptionCommands(listOfAfterCredits);

            Console.SetCursorPosition(UserName.Row, UserName.Col);
            Console.CursorVisible = true;
            World.CreateWorld();
            string userName = Console.ReadLine();

            string heroType = listOfModels[currentModelIndex].Split(',').Last().Replace("Model", "");

            var heroInstance = autofacContext
                .ResolveNamed<IHero>(heroType,
                    new TypedParameter(typeof(string), userName),
                    new TypedParameter(typeof(byte), 100),
                    new TypedParameter(typeof(double), 5),
                    new TypedParameter(typeof(int), 500),
                    new TypedParameter(typeof(Location), World.HeroHB),
                    new TypedParameter(typeof(IList<IItem>), new List<IItem>())
                );

            themeSong.Kill();
            World.InitializeEnvironment();
            return heroInstance;
        }

        private void ProcessCaptionCommands(List<string> listOfCaptions)
        {
            foreach (var caption in listOfCaptions)
            {
                var splittedCommand = caption.Trim().Split(',');
                var commandName = splittedCommand[0].ToLower();
                var commandParameters = splittedCommand.Skip(1).ToList();
                var command = this.drawCaptionFactory.GetCommand(commandName);
                command.Execute(commandParameters);
            }
        }

        private void ProcessSingleModelCommand(string modelCommand)
        {
            var splittedCommand = modelCommand.Trim().Split(',');
            var commandName = splittedCommand[0].ToLower();
            var commandParameters = splittedCommand.Skip(1).ToList();
            var command = this.drawModelFactory.GetCommand(commandName);
            command.Execute(commandParameters);
        }
    }
}
