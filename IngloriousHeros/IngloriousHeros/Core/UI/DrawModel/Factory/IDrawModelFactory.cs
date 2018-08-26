namespace IngloriousHeros.Core.UI.DrawModel.Factory
{
    public interface IDrawModelFactory
    {
        IDrawModel GetCommand(string commandName);
    }
}