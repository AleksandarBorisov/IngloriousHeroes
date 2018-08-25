//using System;
//using System.Collections.Generic;
//using System.Text;
//using Autofac;
//using System.Threading;
//using IngloriousHeros.Core.Contracts;
//using IngloriousHeros.Core.UI.DrawCaption.Interfaces;

//namespace IngloriousHeros.Core.UI.DrawCommands
//{
//    class DrawCaptionLeftRight : IDrawCaption
//    {
//        private IFont font;
//        private IComponentContext autofacContext;

//        public DrawCaptionLeftRight(IFont font)
//        {
//            this.font = font;
//        }

//        public void Execute(List<string> parameters)
//        {

//            int currentColumn = int.Parse(parameters[1]);
//            int currentRow = int.Parse(parameters[2]);
//            string message = parameters[3];
//            IFont currentFont = autofacContext.ResolveNamed<IFont>(parameters[4]);
//            int leftRightSpeed = int.Parse(parameters[5]);
//            for (int i = 0; i < message.Length; i++)
//            {
//                char[,] letterAsCharArray = ProcessLetter(message[i], currentFont);
//                for (int col = 0; col < letterAsCharArray.GetLength(1); col++)
//                {
//                    Console.SetCursorPosition(currentRow, currentColumn);
//                    for (int row = 0; row < letterAsCharArray.GetLength(0); row++)
//                    {
//                        Console.Write(letterAsCharArray[row, col]);
//                        Console.SetCursorPosition(currentRow, ++currentColumn);
//                        //Console.SetCursorPosition(startingRow + col + i * letterAsCharArray.GetLength(1), startinColumn + row);
//                        //Console.Write(letterAsCharArray[row, col]);
//                    }
//                    currentRow++;
//                    currentColumn = int.Parse(parameters[1]);
//                    Thread.Sleep(leftRightSpeed);
//                }
//                currentRow++;
//            }
//        }

//        public char[,] ProcessLetter(char letterFromMessage, IFont currentFont)
//        {
//            string[] letterRows = currentFont[letterFromMessage != ' ' ? letterFromMessage - 'a' : 26]
//                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

//            char[,] letterAsCharArray = new char[letterRows.Length, letterRows[0].Length];

//            for (int row = 0; row < letterRows.Length; row++)
//            {
//                for (int col = 0; col < letterRows[row].Length; col++)
//                {
//                    letterAsCharArray[row, col] = letterRows[row][col];
//                }
//            }

//            return letterAsCharArray;
//        }
//    }
//}
