using System;
using System.Collections.Generic;
using System.Text;
using IngloriousHeros.Contracts;
using System.Threading;
using System.Linq;

namespace IngloriousHeros.Core.UI.Models
{
    class Draw
    {
        private const int leftRightSpeed = 50;
        private const int blinkPause = 200;

        private static Draw instanceHolder;

        private Draw()
        {
            Console.CursorVisible = false;
        }

        public static Draw Instance
        {
            get
            {
                return instanceHolder = new Draw();
            }
        }

        private char[,] ProcessLetter(char letterFromMessage, IFont currentFont)
        {
            string[] letterRows = currentFont[letterFromMessage != ' ' ? letterFromMessage - 'a' : 26]
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            char[,] letterAsCharArray = new char[letterRows.Length, letterRows[0].Length];
            for (int row = 0; row < letterRows.Length; row++)
            {
                for (int col = 0; col < letterRows[row].Length; col++)
                {
                    letterAsCharArray[row, col] = letterRows[row][col];
                }
            }
            return letterAsCharArray;
        }

        private string[] ProcesHeroModel(string heroModel)
        {
            string[] result = heroModel.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var maxLength = result.Max(x => x.Length);
            result = result.Select(s => s.PadRight(maxLength, ' ')).ToArray();
            return result;
        }

        public void CaptionLeftRight(int startingRow, int startinColumn, string message, IFont currentFont)
        {
            int currentColumn = startinColumn;
            int currentRow = startingRow;
            for (int i = 0; i < message.Length; i++)
            {
                char[,] letterAsCharArray = ProcessLetter(message[i], currentFont);
                for (int col = 0; col < letterAsCharArray.GetLength(0); col++)
                {
                    Console.SetCursorPosition(currentRow, currentColumn);
                    for (int row = 0; row < letterAsCharArray.GetLength(1); row++)
                    {
                        Console.Write(letterAsCharArray[row, col]);
                        Console.SetCursorPosition(currentRow, ++currentColumn);
                    }
                    currentRow++;
                    currentColumn = startinColumn;
                    Thread.Sleep(leftRightSpeed);
                }
                currentRow++;
            }
        }

        public void CaptionBlinking(int startingRow, int startingColumn, string message, IFont currentAlphabet)
        {
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
                    char[,] letterAsCharArray = ProcessLetter(message[i], currentAlphabet);
                    Console.SetCursorPosition(currentRow, currentColumn++);
                    for (int row = 0; row < letterAsCharArray.GetLength(0); row++)
                    {
                        for (int col = 0; col < letterAsCharArray.GetLength(1); col++)
                        {
                            Console.Write(printWhiteSpace ? letterAsCharArray[row, col] : ' ');
                        }
                        Console.SetCursorPosition(currentRow, currentColumn++);
                    }
                    currentRow += letterAsCharArray.GetLength(1);
                    currentColumn = startingColumn;
                }
                Thread.Sleep(blinkPause);
                printWhiteSpace = !printWhiteSpace;
            }
        }

        public void HeroModel(int heroRow, int heroCol, bool selected = false)
        {
            HerosModels heroToBeDrawn = HerosModels.Instance;
            string heroModel = heroToBeDrawn.Models[heroRow, heroCol];
            string[] heroAsStrings = ProcesHeroModel(heroModel);
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
    }
}
