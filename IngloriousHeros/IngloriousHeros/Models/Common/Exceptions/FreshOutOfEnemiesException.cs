using System;

namespace IngloriousHeros.Models.Common.Exceptions
{
    public class FreshOutOfEnemiesException : ApplicationException
    {
        public FreshOutOfEnemiesException(string message)
            : base(message)
        {

        }
    }
}
