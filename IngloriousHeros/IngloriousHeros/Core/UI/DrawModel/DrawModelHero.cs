using Autofac;
using IngloriousHeros.Core.UI.DrawModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IngloriousHeros.Core.UI.DrawModel
{
    class DrawModelHero : IDrawModel
    {
        private IComponentContext autofacContext;

        public DrawModelHero(IComponentContext autofacContext)
        {
            this.autofacContext = autofacContext;
        }

        public void Execute(List<string> parameters)
        {
            int heroRow = int.Parse(parameters[0]);
            int heroCol = int.Parse(parameters[1]);
            bool selected = bool.Parse(parameters[2]);
            string modelType = parameters[3].ToLower();
            string[] heroAsStrings = ProcessModel(modelType, heroRow, heroCol);
            int currentCol = heroCol;
            int currentRow = heroRow;
            if (selected)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.CursorVisible = false;
            for (int i = 0; i < heroAsStrings.Length; i++)
            {
                Console.SetCursorPosition(currentRow, currentCol++);
                Console.Write(heroAsStrings[i]);
            }
            if (selected)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public string[] ProcessModel(string modelType, int heroRow, int heroCol)
        {
            IModel currentModel = autofacContext.ResolveNamed<IModel>(modelType);
            string[] result = currentModel.Model.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var maxLength = result.Max(x => x.Length);
            result = result.Select(s => s.PadRight(maxLength, ' ')).ToArray();
            return result;
        }
    }
}
