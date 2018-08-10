using IngloriousHeros.Core.UI;
using System;
using System.Threading;
using System.Threading.Tasks;
using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Core.Game
{
    public sealed class Battle
    {
        private static readonly CancellationTokenSource cts = new CancellationTokenSource();
        private static readonly object envLock = new object();
        private static readonly MessageBuffer messageBuffer = new MessageBuffer();
        private readonly IHero hero;
        private readonly IHero oponent;

        public Battle(IHero hero, IHero oponent)
        {
            this.hero = hero;
            this.oponent = oponent;
        }

        public static CancellationTokenSource Cts => cts;

        public static object EnvLock => envLock;

        public static MessageBuffer MessageBuffer => messageBuffer;

        public IHero Hero => this.hero;

        public IHero Oponent => this.oponent;

        public void Start()
        {
            this.DisplayBattleStats();
            Task.Factory.StartNew(() => this.BeginBattle(this.Hero, this.Oponent));
            Task.Factory.StartNew(() => this.BeginBattle(this.Oponent, this.Hero));
        }

        private void DisplayBattleStats()
        {
            HealthBar.Draw(hero);
            HealthBar.Draw(oponent);
            Console.SetCursorPosition(World.BufferLocation.Col, World.BufferLocation.Row);
            Console.WriteLine("Fight history:");
        }

        public void BeginBattle(IHero hero, IHero oponent)
        {
            while (!cts.Token.IsCancellationRequested)
            {
                if (oponent.Health > 0)
                {
                    hero.Attack(oponent);
                }
                else
                {
                    cts.Cancel();
                    PrintOutcome(hero, oponent);
                    cts.Dispose();
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
