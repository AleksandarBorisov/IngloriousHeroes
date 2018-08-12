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

namespace IngloriousHeros.Core
{
    public class GameEngine : IEngine
    {
        public static void Run()
        {
            World.InitializeEnvironment();
            World.CreateWorld();

            Process soundPlayer = Process.Start(@"../../../../SoundPlayer/bin/Debug/SoundPlayer.exe");

            int artefacts = 0;
            IHero hero = GameUnitFactory.CreateGameUnit<Wizzard>("Harry Potter", 100, 1, 500, World.HeroHB, new List<IItem>());
            IHero enemy = null;

            while (hero.Health > 0 && artefacts < 10)
            {
                Random randomizer = new Random(Guid.NewGuid().GetHashCode());

                if (hero.Health != 100)
                {
                    if (hero.Health <= 95)
                    {
                        hero.Health += 5;
                        Console.WriteLine($"{hero.Name} has recovered 5 units of health!");
                    }
                    else
                    {
                        int healthRecovered = 100 - (int)hero.Health;
                        hero.Health = 100;
                        Console.WriteLine($"{hero.Name} has recovered {healthRecovered} units of health!");
                    }
                }

                if (randomizer.Next(1, 101) <= 20)
                {
                    // Hero has collected an artefact
                    Console.WriteLine($"{hero.Name} has collected an artefact {++artefacts}/10!");
                    Thread.Sleep(1000);
                    continue;
                }

                Thread.Sleep(100);

                if (randomizer.Next(1, 101) <= 20)
                {
                    // Hero has collected an item
                    var item = GetItem(randomizer);
                    (hero.Inventory as List<IItem>).Add(item);
                    Console.WriteLine($"{hero.Name} has collected a new {item.GetType().Name}!");
                    Thread.Sleep(1000);
                    continue;
                }

                Thread.Sleep(100);

                if (randomizer.Next(1, 101) <= 20)
                {
                    // Hero has encountered an enemy
                    enemy = GetOponent(randomizer);

                    Console.WriteLine($"{hero.Name} has encountered an enemy class {enemy.GetType().Name} from the {enemy.Race} race!\n\rLET THE BATTLE BEGIN!");
                    Thread.Sleep(2000);

                    hero.Oponent = enemy;
                    enemy.Oponent = hero;

                    // Start battle
                    Console.Clear();
                    Battle epicBattle = new Battle(hero);
                    epicBattle.Start();
                    Battle.MessageBuffer.Clear();
                    Thread.Sleep(1000);

                    if (hero.Health > 0)
                    {
                        Console.WriteLine($"{hero.Name} has won the battle!");
                        Console.WriteLine("Game continues...");
                    }
                }
            }

            if (hero.Health < 1)
            {
                Console.WriteLine($"{hero.Name} is dead...");
                Console.WriteLine("GAME OVER!");
                soundPlayer.Kill();
            }
            else
            {
                Console.WriteLine($"{hero.Name} has finished the Quest!");
            }

            Console.ReadLine();
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
