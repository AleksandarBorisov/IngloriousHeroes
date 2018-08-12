using IngloriousHeros.Core.UI;
using System;
using System.Threading;
using System.Threading.Tasks;
using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Core.Game
{
    public sealed class Battle
    {
        private static CancellationTokenSource cts;
        private static readonly object envLock = new object();
        private static readonly MessageBuffer messageBuffer = new MessageBuffer();
        private readonly IHero hero;

        public Battle(IHero hero)
        {
            this.hero = hero;
        }

        public static CancellationTokenSource Cts => cts;

        public static object EnvLock => envLock;

        public static MessageBuffer MessageBuffer => messageBuffer;

        public IHero Hero => this.hero;

        public void Start()
        {
            cts = new CancellationTokenSource();
            this.DisplayBattleStats();

            Task[] battles = new Task[]
            {
                Task.Factory.StartNew(() => this.BeginBattle(this.Hero, this.Hero.Oponent)),
                Task.Factory.StartNew(() => this.BeginBattle(this.Hero.Oponent, this.Hero))
            };

            Task.WaitAll(battles);
        }

        private void DisplayBattleStats()
        {
            Console.Clear();

            HealthBar.Draw(hero);
            HealthBar.Draw(hero.Oponent);
            Console.SetCursorPosition(World.BufferLocation.Col, World.BufferLocation.Row);
            Console.WriteLine("Fight history:");
        }

        public void BeginBattle(IHero hero, IHero oponent)
        {
            while (!cts.Token.IsCancellationRequested)
            {
                if (hero.Oponent.Health > 0)
                {
                    hero.Attack(oponent);
                }
                else
                {
                    cts.Cancel();
                    PrintOutcome(hero, oponent);
                }
            }
        }

        // Revise logic in PrintOutcome()
        public void PrintOutcome(IHero hero, IHero oponent)
        {
            lock (envLock)
            {
                if (hero.Health > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(World.OutcomeLocation.Col, World.OutcomeLocation.Row);
                    Console.WriteLine($"{hero.Name} wins this round!");
                    Console.SetCursorPosition(World.OutcomeLocation.Col, World.OutcomeLocation.Row + 1);
                    Console.WriteLine($"{hero.Name} health: {hero.Health}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(World.OutcomeLocation.Col, World.OutcomeLocation.Row + 2);
                    Console.WriteLine($"{oponent.Name} health: {(oponent.Health < 0 ? 0 : oponent.Health)}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    HealthBar.Update(oponent);
                    Console.SetCursorPosition(World.OutcomeLocation.Col, World.OutcomeLocation.Row);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Everybody is dead!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
