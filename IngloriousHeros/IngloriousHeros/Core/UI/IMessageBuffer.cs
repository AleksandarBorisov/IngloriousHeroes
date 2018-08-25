using System.Collections;

namespace IngloriousHeros.Core.UI
{
    public interface IMessageBuffer
    {
        void Enqueue(string message);

        void Clear();

        void PrintBuffer();

        IEnumerator GetEnumerator();
    }
}