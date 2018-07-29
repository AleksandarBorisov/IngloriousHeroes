using System;
using System.Collections.Generic;
using System.Text;

namespace IngloriousHeros.Providers
{
    public class ValidationProviderException : ApplicationException
    {
        public ValidationProviderException(string message)
            : base(message)
        {

        }
    }
}
