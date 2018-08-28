namespace IngloriousHeros.Core.UI.DrawCaption.Providers
{
    public interface IProcessLetter
    {
        char[,] Execute(char letterFromMessage, string font);
    }
}