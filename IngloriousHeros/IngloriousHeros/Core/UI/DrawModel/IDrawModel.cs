using System;
using System.Collections.Generic;
using System.Text;

namespace IngloriousHeros.Core.UI.DrawModel
{
    public interface IDrawModel
    {
        void Execute(List<string> parameters);

        string[] ProcessModel(string modelType, int heroRow, int heroCol);
    }
}
