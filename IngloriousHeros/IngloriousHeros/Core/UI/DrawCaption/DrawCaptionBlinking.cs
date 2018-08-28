using System;
using System.Collections.Generic;
using System.Threading;
using Autofac;
using IngloriousHeros.Core.UI.DrawCaption.Fonts;
using IngloriousHeros.Core.UI.DrawCaption.Providers;
using IngloriousHeros.Core.Utilities;

namespace IngloriousHeros.Core.UI.DrawCaption
{
    public class DrawCaptionBlinking : IDrawCaption
    {
        //private IComponentContext autofacContext;
        private IProcessLetter processLetter;
        private IConsole gameConsole;

        public DrawCaptionBlinking(IProcessLetter processLetter, IConsole gameConsole)
        {
            //this.autofacContext = autofacContext;
            this.processLetter = processLetter;
            this.gameConsole = gameConsole;
        }

        public void Execute(List<string> parameters)
        {
            int startingRow = int.Parse(parameters[0]);
            int startingColumn = int.Parse(parameters[1]);
            string message = parameters[2];
            string currentFont = parameters[3].ToLower();
            int blinkPause = int.Parse(parameters[4]);
            bool printWhiteSpace = false;
            bool keyPressed = false;
            while (!keyPressed || printWhiteSpace)
            {
                if (Console.KeyAvailable)
                {
                    keyPressed = true;
                    Console.ReadKey(true);
                }
                int currentColumn = startingColumn;
                int currentRow = startingRow;
                for (int i = 0; i < message.Length; i++)
                {
                    char[,] letterAsCharArray = processLetter.Execute(message[i], currentFont);
                    gameConsole.SetCursorPosition(currentRow, currentColumn++);
                    for (int row = 0; row < letterAsCharArray.GetLength(0); row++)
                    {
                        for (int col = 0; col < letterAsCharArray.GetLength(1); col++)
                        {
                            Console.Write(printWhiteSpace ? letterAsCharArray[row, col] : ' ');
                        }
                        gameConsole.SetCursorPosition(currentRow, currentColumn++);
                    }
                    currentRow += letterAsCharArray.GetLength(1);
                    currentColumn = startingColumn;
                }
                Thread.Sleep(blinkPause);
                printWhiteSpace = !printWhiteSpace;
            }
        }

        //public char[,] ProcessLetter(char letterFromMessage, string font)
        //{
        //    IFont currentFont = autofacContext.ResolveNamed<IFont>(font);
        //    string[] letterRows = currentFont[letterFromMessage != ' ' ? letterFromMessage - 'a' : 26]
        //        .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        //    char[,] letterAsCharArray = new char[letterRows.Length, letterRows[0].Length];

        //    for (int row = 0; row < letterRows.Length; row++)
        //    {
        //        for (int col = 0; col < letterRows[row].Length; col++)
        //        {
        //            letterAsCharArray[row, col] = letterRows[row][col];
        //        }
        //    }

        //    return letterAsCharArray;
        //}
    }
}
