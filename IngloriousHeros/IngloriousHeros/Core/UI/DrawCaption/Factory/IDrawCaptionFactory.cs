using IngloriousHeros.Core.UI.DrawCaption.Interfaces;

namespace IngloriousHeros.Core.UI.DrawCaption.Factory
{
    public interface IDrawCaptionFactory
    {
        IDrawCaption GetCommand(string commandName);
    }
}