using System;
using System.Threading;

namespace IngloriousHeros.Core.Utilities
{
    public class GameThread : IGameThread
    {
        public void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}
