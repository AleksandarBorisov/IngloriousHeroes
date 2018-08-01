using System.Collections;
using System.Collections.Generic;

namespace IngloriousHeros.Core.UI
{
    public class MessageBuffer : IEnumerable
    {
        private Queue<string> elements = new Queue<string>();

        public void Enqueue(string message)
        {
            if (this.elements.Count == 20)
            {
                this.elements.Dequeue();
            }

            this.elements.Enqueue(message);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Elements).GetEnumerator();
        }

        public Queue<string> Elements
        {
            get => this.elements;
        }
    }
}
