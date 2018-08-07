using IngloriousHeros.Contracts;
using IngloriousHeros.Core.Factories;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Heros;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using IngloriousHeros.Models.Weapons;
using IngloriousHeros.Models.Armours;

namespace IngloriousHeros.Tests
{
    public static class GameEngineTest
    {
        static readonly CancellationTokenSource cts = new CancellationTokenSource();
        static MessageBuffer messageBuffer = new MessageBuffer();
        private static readonly object _lock = new object();

        public static void Run()
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;
            Console.CursorVisible = false;

            //IHero Legolas = GameUnitFactory.CreateGameUnit<Archer>("Legolas", 100, 1, 1000);
            //IHero OptimusPrime = GameUnitFactory.CreateGameUnit<Brute>("Optimus Prime", 100, 10, 1000);

            List<IItem> weaponsLegolas = new List<IItem>()
            {
                new Laser(5, 10),
                new Laser(5, 100),
                //new Helmet(5,100),
                new Laser(5, 50),
                new Laser(5, 0),
                //new Helmet(5,100),
                new Laser(5, 100),
            };
            List<IItem> weaponsOptimusPrime = new List<IItem>()
            {
                new Laser(5, 10),
                new Laser(5, 100),
                //new Helmet(5,100),
                new Laser(5, 50),
                new Laser(5, 0),
                //new Helmet(5,100),
                new Laser(5, 100),
            };
            //I've added this invontory items to the constructor of an Archer, modified the constructor respectively
            IHero Legolas = GameUnitFactory.CreateGameUnit<Archer>("Legolas", 100, 4, 300, weaponsLegolas);
            IHero OptimusPrime = GameUnitFactory.CreateGameUnit<Brute>("Optimus Prime", 100, 7, 1000, weaponsOptimusPrime);

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

            int bonusDamage = 0;

            if (hero.Inventory.Count() > 0)
            {
                bonusDamage = hero.Inventory.First().UseItem(hero);
            }

            oponent.TakeDamage((int)hero.Damage + bonusDamage);

            lock (_lock)
            {
                if (!cts.Token.IsCancellationRequested)
                {
                    messageBuffer.Enqueue($"{hero.Name} deals {hero.Damage + bonusDamage} damage to {oponent.Name}.");
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
