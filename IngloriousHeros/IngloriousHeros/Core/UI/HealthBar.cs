using System;

namespace IngloriousHeros.Core.UI
{
    public class HealthBar
    {
        public static void Draw(string name, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.Write($"{name} health: ");

            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i + col, row + 1);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(' ');
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void Update(int health, int row, int col)
        {
            int damage = 100 - health;
            int startIndex = damage / 5;

            Console.BackgroundColor = ConsoleColor.Red;

            for (int i = 1; i <= startIndex; i++)
            {
                Console.SetCursorPosition(col - i, row + 1);
                Console.WriteLine(' ');
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
