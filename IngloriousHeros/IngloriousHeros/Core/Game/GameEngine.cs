using IngloriousHeros.Core.Contracts;
using IngloriousHeros.Models.Contracts;
using System.Collections.Generic;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.Utilities;
using IngloriousHeros.Core.Game.Interfaces;

namespace IngloriousHeros.Core
{
    public class GameEngine : IEngine
    {
        //private readonly IWorld world;
        private readonly IHero hero;
        private readonly IConsole gameConsole;
        private readonly IRandomizer randomizer;
        private readonly IGameThread thread;

        public GameEngine(IHero hero, IConsole gameConsole, IRandomizer randomizer, IGameThread thread)
        {
            //this.world = world;
            this.hero = hero;
            this.gameConsole = gameConsole;
            this.randomizer = randomizer;
            this.thread = thread;
        }

        public void Run()
        {
            World.InitializeEnvironment();
            World.CreateWorld();
            var soundPlayer = World.StartSoundPlayer();

            int artefacts = 0;

            while (this.hero.Health > 0 && artefacts < 10)
            {
                if (this.hero.Health != 100)
                {
                    if (this.hero.Health <= 95)
                    {
                        this.hero.Health += 5;
                        this.gameConsole.WriteLine($"{this.hero.Name} has recovered 5 units of health!");
                    }
                    else
                    {
                        int healthRecovered = 100 - (int)this.hero.Health;
                        this.hero.Health = 100;
                        this.gameConsole.WriteLine($"{this.hero.Name} has recovered {healthRecovered} units of health!");
                    }
                }

                if (randomizer.Next(1, 101) <= 20)
                {
                    // Hero has collected an artefact
                    this.gameConsole.WriteLine($"{this.hero.Name} has collected an artefact {++artefacts}/10!");
                    this.thread.Sleep(1000);
                    continue;
                }

                this.thread.Sleep(100);

                if (randomizer.Next(1, 101) <= 20)
                {
                    // Hero has collected an item
                    var item = GetItem(randomizer);
                    this.hero.Inventory.Add(item);
                    this.gameConsole.WriteLine($"{this.hero.Name} has collected a new {item.GetType().Name}!");
                    this.thread.Sleep(1000);
                    continue;
                }

                this.thread.Sleep(100);

                if (randomizer.Next(1, 101) <= 20)
                {
                    // Hero has encountered an enemy
                    IHero enemy = GetOponent(randomizer);

                    this.gameConsole.WriteLine($"{hero.Name} has encountered an enemy class {enemy.GetType().Name} from the {enemy.Race} race!\n\rLET THE BATTLE BEGIN!");
                    this.thread.Sleep(2000);

                    this.hero.Oponent = enemy;
                    enemy.Oponent = this.hero;

                    // Start battle
                    this.gameConsole.Clear();

                    Battle epicBattle = new Battle(hero, gameConsole);
                    epicBattle.Start();

                    Battle.MessageBuffer.Clear();

                    this.thread.Sleep(1000);

                    if (this.hero.Health > 0)
                    {
                        this.gameConsole.WriteLine($"{this.hero.Name} has won the battle!");
                        this.gameConsole.WriteLine("Game continues...");
                    }
                }
            }

            if (hero.Health < 1)
            {
                this.gameConsole.WriteLine($"{this.hero.Name} is dead...");
                this.gameConsole.WriteLine("GAME OVER!");
                soundPlayer.Kill();
            }
            else
            {
                this.gameConsole.WriteLine($"{this.hero.Name} has finished the Quest!");
            }

            this.gameConsole.ReadLine();
        }

        public IHero GetOponent(IRandomizer randomizer)
        {
            int enemyIndex = randomizer.Next(0, World.Heroes.Count);

            IHero enemy = World.Heroes[enemyIndex];

            World.Heroes.Remove(enemy);

            return enemy;
        }

        public IItem GetItem(IRandomizer randomizer)
        {
            int itemIndex = randomizer.Next(0, World.Items.Count);

            IItem item = World.Items[itemIndex];

            World.Items.Remove(item);

            return item;
        }
    }
}
