using IngloriousHeros.Core.Contracts;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Factories;
using System.Collections.Generic;
using IngloriousHeros.Models.Heros;
using System;
using IngloriousHeros.Core.Game;
using System.Threading;
using IngloriousHeros.Models.Armours;
using System.Diagnostics;
using System.Threading.Tasks;
using IngloriousHeros.Core.Utilities;

namespace IngloriousHeros.Core
{
    public class GameEngine : IEngine
    {
        private readonly IConsole gameConsole;

        public GameEngine(IConsole gameConsole)
        {
            this.gameConsole = gameConsole;
        }

        public void Run(IHero hero)
        {
            World.InitializeEnvironment();
            World.CreateWorld();

            Process soundPlayer = Process.Start(@"../../../../SoundPlayer/bin/Debug/SoundPlayer.exe");

            int artefacts = 0;
            //IHero hero = GameUnitFactory.CreateGameUnit<Wizzard>("Harry Potter", 100, 1, 500, World.HeroHB, new List<IItem>());
            //IHero hero = GameUnitFactory.CreateGameUnit<Warrior>("Hercules", 100, 15, 500, World.HeroHB, new List<IItem>());
            IHero enemy = null;

            while (hero.Health > 0 && artefacts < 10)
            {
                Random randomizer = new Random(Guid.NewGuid().GetHashCode());

                if (hero.Health != 100)
                {
                    if (hero.Health <= 95)
                    {
                        hero.Health += 5;
                        gameConsole.WriteLine($"{hero.Name} has recovered 5 units of health!");
                    }
                    else
                    {
                        int healthRecovered = 100 - (int)hero.Health;
                        hero.Health = 100;
                        gameConsole.WriteLine($"{hero.Name} has recovered {healthRecovered} units of health!");
                    }
                }

                if (randomizer.Next(1, 101) <= 20)
                {
                    // Hero has collected an artefact
                    gameConsole.WriteLine($"{hero.Name} has collected an artefact {++artefacts}/10!");
                    Thread.Sleep(1000);
                    continue;
                }

                Thread.Sleep(100);

                if (randomizer.Next(1, 101) <= 20)
                {
                    // Hero has collected an item
                    var item = GetItem(randomizer);
                    (hero.Inventory as List<IItem>).Add(item);
                    gameConsole.WriteLine($"{hero.Name} has collected a new {item.GetType().Name}!");
                    Thread.Sleep(1000);
                    continue;
                }

                Thread.Sleep(100);

                if (randomizer.Next(1, 101) <= 20)
                {
                    // Hero has encountered an enemy
                    enemy = GetOponent(randomizer);

                    gameConsole.WriteLine($"{hero.Name} has encountered an enemy class {enemy.GetType().Name} from the {enemy.Race} race!\n\rLET THE BATTLE BEGIN!");
                    Thread.Sleep(2000);

                    hero.Oponent = enemy;
                    enemy.Oponent = hero;

                    // Start battle
                    gameConsole.Clear();
                    Battle epicBattle = new Battle(hero);
                    epicBattle.Start();
                    Battle.MessageBuffer.Clear();
                    Thread.Sleep(1000);

                    if (hero.Health > 0)
                    {
                        gameConsole.WriteLine($"{hero.Name} has won the battle!");
                        gameConsole.WriteLine("Game continues...");
                    }
                }
            }

            if (hero.Health < 1)
            {
                gameConsole.WriteLine($"{hero.Name} is dead...");
                gameConsole.WriteLine("GAME OVER!");
                soundPlayer.Kill();
            }
            else
            {
                gameConsole.WriteLine($"{hero.Name} has finished the Quest!");
            }

            gameConsole.ReadLine();
        }

        public static IHero GetOponent(Random randomizer)
        {
            List<IHero> enemies = World.Heroes as List<IHero>;

            int enemyIndex = randomizer.Next(0, enemies.Count);

            IHero enemy = enemies[enemyIndex];

            enemies.Remove(enemy);

            return enemy;
        }

        public static IItem GetItem(Random randomizer)
        {
            List<IItem> items = World.Items as List<IItem>;

            int itemIndex = randomizer.Next(0, items.Count);

            IItem item = items[itemIndex];

            items.Remove(item);

            return item;
        }
    }
}
