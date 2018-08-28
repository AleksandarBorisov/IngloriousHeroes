using System;
using System.Collections.Generic;
using Autofac;
using System.Threading;
using IngloriousHeros.Core.UI.DrawCaption.Fonts;
using IngloriousHeros.Core.Utilities;
using IngloriousHeros.Core.UI.DrawCaption.Providers;

namespace IngloriousHeros.Core.UI.DrawCaption
{
    public class DrawCaptionLeftRight : IDrawCaption
    {
        //private IComponentContext autofacContext;
        private IProcessLetter processLetter;
        private IConsole gameConsole;

        public DrawCaptionLeftRight(IProcessLetter processLetter, IConsole gameConsole)
        {
            //this.autofacContext = autofacContext;
            this.processLetter = processLetter;
            this.gameConsole = gameConsole;
        }

        public void Execute(List<string> parameters)
        {
            int currentRow = int.Parse(parameters[0]);
            int currentColumn = int.Parse(parameters[1]);
            string message = parameters[2];
            string currentFont = parameters[3].ToLower();
            int leftRightSpeed = int.Parse(parameters[4]);
            for (int i = 0; i < message.Length; i++)
            {
                char[,] letterAsCharArray = processLetter.Execute(message[i], currentFont);
                for (int col = 0; col < letterAsCharArray.GetLength(1); col++)
                {
                    this.gameConsole.SetCursorPosition(currentRow, currentColumn);
                    for (int row = 0; row < letterAsCharArray.GetLength(0); row++)
                    {
                        Console.Write(letterAsCharArray[row, col]);
                        this.gameConsole.SetCursorPosition(currentRow, ++currentColumn);
                    }
                    currentRow++;
                    currentColumn = int.Parse(parameters[1]);
                    Thread.Sleep(leftRightSpeed);
                }
                currentRow++;
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
