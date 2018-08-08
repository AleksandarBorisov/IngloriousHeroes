using System;
using System.Collections;
using System.Collections.Generic;
using IngloriousHeros.Core.Battle;

namespace IngloriousHeros.Core.UI
{
    public class MessageBuffer : IEnumerable
    {
        private Queue<string> elements = new Queue<string>();

        public void Enqueue(string message)
        {
            lock (Battle.Battle.EnvLock)
            {
                if (this.elements.Count == 20)
                {
                    this.Elements.Dequeue();
                }

                this.Elements.Enqueue(message);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Elements).GetEnumerator();
        }

        public Queue<string> Elements
        {
            get => this.elements;
        }

        public void PrintBuffer()
        {
            lock (Battle.Battle.EnvLock)
            {
                int row = 5;

                foreach (string message in this.Elements)
                {
                    Console.SetCursorPosition(10, row);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(10, row++);
                    Console.Write(message);
                }
            }
        }
    }
}
