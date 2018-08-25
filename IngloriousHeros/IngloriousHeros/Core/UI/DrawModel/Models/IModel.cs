namespace IngloriousHeros.Core.UI.DrawModel.Factory
{
    interface IModel
    {
        string this[int indexRow, int indexCol] { get; }

        string[,] Models { get; set; }
    }
}