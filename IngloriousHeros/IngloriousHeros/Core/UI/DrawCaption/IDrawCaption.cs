using System.Collections.Generic;

namespace IngloriousHeros.Core.UI.DrawCaption
{
    public interface IDrawCaption
    {
        void Execute(List<string> parameters);

        char[,] ProcessLetter(char letterFromMessage, string font);
    }
}