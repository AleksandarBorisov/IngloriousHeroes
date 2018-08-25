namespace IngloriousHeros.Core.UI.DrawModel.Factory
{
    internal interface IDrawModelFacory
    {
        IDrawModel GetCommand(string commandName);
    }
}