using IngloriousHeros.Core.Contracts;

namespace IngloriousHeros.Core.UI.Models
{
    public interface IDraw
    {
        void CaptionBlinking(int startingRow, int startingColumn, string message, IFont currentFont);
        void CaptionLeftRight(int startingRow, int startinColumn, string message, IFont currentFont, int leftRightSpeed);
        void HeroModel(int heroRow, int heroCol, bool selected = false);
    }
}