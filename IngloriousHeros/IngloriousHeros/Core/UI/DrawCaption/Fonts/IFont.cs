namespace IngloriousHeros.Core.UI.DrawCaption.Fonts
{
    public interface IFont
    {
        string[] Letters { get; }

        string this[int index] { get; }
    }
}
