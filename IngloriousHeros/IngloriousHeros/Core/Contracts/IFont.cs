namespace IngloriousHeros.Core.Contracts
{
    public interface IFont
    {
        string[] Letters { get; }

        string this[int index] { get; }
    }
}
