using System;
using System.Collections.Generic;
using System.Text;

namespace IngloriousHeros.Providers
{
    public static class ValueCheck
    {
        public static void Positive(double value, string message)
        {
            if (value < 0)
            {
                throw new ValidationProviderException(message);
            }
        }
    }
}
