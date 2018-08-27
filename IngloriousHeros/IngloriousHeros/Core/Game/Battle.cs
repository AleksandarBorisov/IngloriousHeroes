using IngloriousHeros.Core.UI;
using System;
using System.Threading;
using System.Threading.Tasks;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Heros.Abstracts;
using IngloriousHeros.Core.Utilities;

namespace IngloriousHeros.Core.Game
{
    public sealed class Battle
    {
        private static CancellationTokenSource cts;
        private static readonly object envLock = new object();

        // TODO: Resolve messageBuffer with Autofac
        private static readonly IMessageBuffer messageBuffer = new MessageBuffer(new GameConsole());
        private IHero hero;
        private readonly IConsole gameConsole;

        public Battle(IHero hero, IConsole gameConsole)
        {
            this.hero = hero;
            this.gameConsole = gameConsole;
        }

        public static CancellationTokenSource Cts => cts;

        public static object EnvLock => envLock;

        public static MessageBuffer MessageBuffer => (MessageBuffer)messageBuffer;

        public IHero Hero
        {
            get => this.hero;
            set => this.hero = value;
        }

        public void Start()
        {
            cts = new CancellationTokenSource();

            HealthBar heroHB = new HealthBar();
            HealthBar oponentHB = new HealthBar();

            heroHB.Subscribe(this.Hero as Hero);
            oponentHB.Subscribe(this.Hero.Oponent as Hero);

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
            this.gameConsole.Clear();

            HealthBar.Draw(hero);
            HealthBar.Draw(hero.Oponent);
            this.gameConsole.SetCursorPosition(World.BufferLocation.Col, World.BufferLocation.Row);
            this.gameConsole.WriteLine("Fight history:");
        }

        public void BeginBattle(IHero hero, IHero oponent)
        {
            while (!cts.Token.IsCancellationRequested)
            {
                if (hero.Oponent.Health > 0)
                {
                    hero.Attack();
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
                    this.gameConsole.ForegroundColor = ConsoleColor.Green;
                    this.gameConsole.SetCursorPosition(World.OutcomeLocation.Col, World.OutcomeLocation.Row);
                    this.gameConsole.WriteLine($"{hero.Name} wins this round!");
                    this.gameConsole.SetCursorPosition(World.OutcomeLocation.Col, World.OutcomeLocation.Row + 1);
                    this.gameConsole.WriteLine($"{hero.Name} health: {hero.Health}");
                    this.gameConsole.ForegroundColor = ConsoleColor.Red;
                    this.gameConsole.SetCursorPosition(World.OutcomeLocation.Col, World.OutcomeLocation.Row + 2);
                    this.gameConsole.WriteLine($"{oponent.Name} health: {(oponent.Health < 0 ? 0 : oponent.Health)}");
                    this.gameConsole.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(2000);
                    this.gameConsole.Clear();
                    hero.Wins++;
                }
                else
                {
                    HealthBar.Update(oponent);
                    this.gameConsole.SetCursorPosition(World.OutcomeLocation.Col, World.OutcomeLocation.Row);
                    this.gameConsole.ForegroundColor = ConsoleColor.Red;
                    this.gameConsole.WriteLine("Everybody is dead!");
                    this.gameConsole.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
