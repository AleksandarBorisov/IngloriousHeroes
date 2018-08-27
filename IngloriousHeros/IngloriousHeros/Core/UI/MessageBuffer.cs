using System.Collections;
using System.Collections.Generic;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.Utilities;

namespace IngloriousHeros.Core.UI
{
    public class MessageBuffer : IEnumerable, IMessageBuffer
    {
        private Queue<string> elements = new Queue<string>();
        private IConsole gameConsole;

        public MessageBuffer(IConsole gameConsole)
        {
            this.gameConsole = gameConsole;
        }

        private Queue<string> Elements
        {
            get => this.elements;
        }

        public int Count => this.Elements.Count;

        public void Enqueue(string message)
        {
            lock (Battle.EnvLock)
            {
                if (this.elements.Count == 20)
                {
                    this.Elements.Dequeue();
                }

                this.Elements.Enqueue(message);
            }
        }

        public string Dequeue()
        {
            string element = null;

            try
            {
                element = this.Elements.Dequeue();
            }
            catch (System.Exception)
            {
                throw;
            }

            return element;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Elements).GetEnumerator();
        }

        public void PrintBuffer()
        {
            lock (Battle.EnvLock)
            {
                int row = 5;

                foreach (string message in this.Elements)
                {
                    gameConsole.SetCursorPosition(10, row);
                    gameConsole.Write(new string(' ', gameConsole.WindowWidth));
                    gameConsole.SetCursorPosition(10, row++);
                    gameConsole.Write(message);
                }
            }
        }

        public void Clear()
        {
            this.Elements.Clear();
        }
    }
}
