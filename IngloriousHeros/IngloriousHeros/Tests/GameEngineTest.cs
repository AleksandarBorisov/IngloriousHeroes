﻿using IngloriousHeros.Contracts;
using IngloriousHeros.Core.Factories;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Heros;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IngloriousHeros.Tests
{
    public static class GameEngineTest
    {
        static readonly CancellationTokenSource cts = new CancellationTokenSource();
        static MessageBuffer messageBuffer = new MessageBuffer();
        private static readonly object _lock = new object();

        public static void Run()
        {
            Console.CursorVisible = false;

            IHero Legolas = GameUnitFactory.CreateGameUnit<Archer>("Legolas", 100, 4, 300);
            IHero OptimusPrime = GameUnitFactory.CreateGameUnit<Brute>("Optimus Prime", 100, 7, 1000);

            HealthBar.Draw(Legolas.Name, 1, 10);
            HealthBar.Draw(OptimusPrime.Name, 1, 90);
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Fight history:");

            Console.BackgroundColor = ConsoleColor.Black;
            Task.Factory.StartNew(() => BeginBattle(Legolas, OptimusPrime, 1, 110));
            Task.Factory.StartNew(() => BeginBattle(OptimusPrime, Legolas, 1, 30));

            Console.ReadLine();
        }

        public static void BeginBattle(IHero hero, IHero oponent, int row, int col)
        {
            // The lock code-block ensures that at any given time, 
            // common resources are being used by only one task

            while (!cts.Token.IsCancellationRequested)
            {
                if (oponent.Health > 0)
                {
                    Attack(hero, oponent, row, col);
                }
                else
                {
                    cts.Cancel();
                    cts.Dispose();

                    if (hero.Health < 1)
                    {
                        lock (_lock)
                        {
                            Console.SetCursorPosition(0, 26);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Everybody is dead!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    else
                    {
                        lock (_lock)
                        {
                            PrintOutcome(hero, oponent);
                        }
                    }
                }
            }
        }

        private static void Attack(IHero hero, IHero oponent, int row, int col)
        {
            Thread.Sleep(hero.AttackDelay);

            // Modify hero.Damage
            // ForEach hero.Invertory and apply an item of type Weapon (if any), then remove it from the list
            oponent.TakeDamage((int)hero.Damage);

            lock (_lock)
            {
                if (!cts.Token.IsCancellationRequested)
                {
                    messageBuffer.Enqueue($"{hero.Name} deals {hero.Damage} damage to {oponent.Name}.");
                    PrintBuffer();
                    HealthBar.Update((int)oponent.Health, row, col);
                }
            }
        }

        private static void PrintOutcome(IHero hero, IHero oponent)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 26);
            Console.WriteLine($"{hero.Name} wins this round!");
            Console.SetCursorPosition(0, 27);
            Console.WriteLine($"{hero.Name} health: {hero.Health}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 28);
            Console.WriteLine($"{oponent.Name} health: {(oponent.Health < 0 ? 0 : oponent.Health)}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void PrintBuffer()
        {
            int row = 5;

            foreach (string message in messageBuffer)
            {
                Console.SetCursorPosition(10, row);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(10, row++);
                Console.WriteLine(message);
            }
        }
    }
}
