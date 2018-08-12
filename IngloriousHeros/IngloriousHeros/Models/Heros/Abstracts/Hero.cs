using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Common;
using System.Collections.Generic;
using System.Linq;

namespace IngloriousHeros.Models.Heros.Abstracts
{
    public abstract class Hero : IHero
    {
        private RaceName race;
        private string name;
        private double health;
        private double armour;
        private double damage;
        private int attackDelay;
        private int wins;
        private IHero oponent;
        private Location hbLocation;
        private IEnumerable<IItem> inventory;

        public Hero(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.AttackDelay = attackDelay;
            this.HbLocation = hbLocation;
            this.Inventory = items;
        }

        public RaceName Race
        {
            get => this.race;
            set => this.race = value;
        }

        public string Name
        {
            get => this.name;

            // Add validation
            set => this.name = value;
        }

        public double Health
        {
            get => this.health;
            set
            {
                //ValueCheck.Positive(value, "Health can't be negative!");
                this.health = value;
            }
        }

        public double Armour
        {
            get => this.armour;
            set
            {
                //ValueCheck.Positive(value, "Armour can't be negative!");
                this.armour = value;
            }
        }

        public double Damage
        {
            get => this.damage;
            set
            {
                //ValueCheck.Positive(value, "Damage can't be negative!");
                this.damage = value;
            }
        }

        public int AttackDelay
        {
            get => this.attackDelay;

            // Add validation
            set => this.attackDelay = value;
        }

        public int Wins {
            get => this.wins;
            set
            {
                //ValueCheck.Positive(value, "Wins can't be negative!");
                this.wins = value;
            }
        }

        public IHero Oponent
        {
            get => this.oponent;
            set => this.oponent = value;
        }

        public Location HbLocation
        {
            get => this.hbLocation;
            set => this.hbLocation = value;
        }

        public IEnumerable<IItem> Inventory
        {
            get
            {
                return this.inventory;
            }
            set
            {
                this.inventory = value;
            }
        }

        public abstract void Attack();

        public virtual void TakeDamage(int damage)
        {
            // Iterate through Inventory and use items to modify damage before appolying to health
            int bonusArmour = 0;//0 % reduction of damage

            if (Inventory.Count() > 0 && Inventory.Any(a => a is IArmour))
            {
                bonusArmour = Inventory.First(a => a is IArmour).UseItem(this);
            }
            
            if (!Battle.Cts.Token.IsCancellationRequested)
            {
                this.Health -= damage * (1 - bonusArmour / 100.0);

                Battle.MessageBuffer.Enqueue($"{this.Oponent.Name} deals {(int)(damage) * (1 - bonusArmour / 100.0)} damage to {this.Name}.");// damage to {oponent.Name}.");
                Battle.MessageBuffer.PrintBuffer();
                HealthBar.Update(this);
            }
        }
    }
}
