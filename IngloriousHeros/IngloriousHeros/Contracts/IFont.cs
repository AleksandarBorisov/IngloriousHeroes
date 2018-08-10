using System;
using System.Collections.Generic;
using System.Text;

namespace IngloriousHeros.Contracts
{
    public interface IFont
    {
        string[] Letters { get; }

        string this[int index] { get; }
    }
}
