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
using IngloriousHeros.Models.Common;

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

            Location heroHB = new Location(1, 10);
            Location oponentHB = new Location(1, 90);

            List<IItem> weaponsLegolas = new List<IItem>()
            {
                new Laser(10),
                new Spear(5),
                //new Helmet(5,100),
                new Staff(5),
                new Sword(5),
                //new Helmet(5,100),
                new Laser(5)
            };
            List<IItem> weaponsOptimusPrime = new List<IItem>()
            {
                new Staff(5),
                new Laser(5),
                //new Helmet(5,100),
                new Spear(5),
                //new Helmet(5,100),
                new Sword(5),
            };
            //I've added this invontory items to the constructor of an Archer, modified the constructor respectively
            IHero Legolas = GameUnitFactory.CreateGameUnit<Archer>("Legolas", 100, 4, 300, heroHB, weaponsLegolas);
            IHero OptimusPrime = GameUnitFactory.CreateGameUnit<Brute>("Optimus Prime", 100, 7, 1000, oponentHB, weaponsOptimusPrime);

            HealthBar.Draw(Legolas);
            HealthBar.Draw(OptimusPrime);
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Fight history:");

            Console.BackgroundColor = ConsoleColor.Black;
            Task.Factory.StartNew(() => BeginBattle(Legolas, OptimusPrime));
            Task.Factory.StartNew(() => BeginBattle(OptimusPrime, Legolas));

            Console.ReadLine();
        }

        public static void BeginBattle(IHero hero, IHero oponent)
        {
            // The lock code-block ensures that at any given time, 
            // common resources are being used by only one task

            while (!cts.Token.IsCancellationRequested)
            {
                if (oponent.Health > 0)
                {
                    Attack(hero, oponent);
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

        private static void Attack(IHero hero, IHero oponent)
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
                    HealthBar.Update(oponent);
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
