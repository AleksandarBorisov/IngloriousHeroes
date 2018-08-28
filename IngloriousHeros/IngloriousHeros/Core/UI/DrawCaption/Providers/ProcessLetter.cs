using Autofac;
using IngloriousHeros.Core.UI.DrawCaption.Fonts;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngloriousHeros.Core.UI.DrawCaption.Providers
{
    public class ProcessLetter : IProcessLetter
    {
        private IComponentContext autofacContext;

        public ProcessLetter(IComponentContext autofacContext)
        {
            this.autofacContext = autofacContext;
        }

        public char[,] Execute(char letterFromMessage, string font)
        {
            IFont currentFont = autofacContext.ResolveNamed<IFont>(font);
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
    }
}
