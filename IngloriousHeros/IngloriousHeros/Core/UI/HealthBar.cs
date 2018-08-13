using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Heros.Abstracts;
using System;

namespace IngloriousHeros.Core.UI
{
    public class HealthBar
    {
        public static void Draw(IHero hero)
        {
            Console.SetCursorPosition(hero.HbLocation.Col, hero.HbLocation.Row);
            Console.Write($"{hero.Name} health: ");

            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i + hero.HbLocation.Col, hero.HbLocation.Row + 1);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(' ');
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void Update(IHero hero)
        {
            int damage = 100 - (int)hero.Health;
            int startIndex = damage / 5;

            Console.BackgroundColor = ConsoleColor.Red;

            for (int i = 1; i <= startIndex; i++)
            {
                Console.SetCursorPosition(hero.HbLocation.Col + 20 - i, hero.HbLocation.Row + 1);
                Console.WriteLine(' ');
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void Subscribe(Hero hero)
        {
            // Subscribe to the HealthChange event
            hero.HealthChange += Hero_HealthChange;
        }

        private void Hero_HealthChange(IHero sender)
        {
            // Code to be executed when the HealthChange event is raised
            // After revision, the whole implementation of Update() will be here
            // For now we still need a static Update() method
            Update(sender);
        }
    }
}
