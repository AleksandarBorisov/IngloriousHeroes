using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Human : IRace, IHero
    {
        private string name;
        private double health;
        private double armour;
        private double damage;
        private int attackDelay;
        private const RaceName race = RaceName.Human;

        public Human(string name, double health, double damage, int attackDelay)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.AttackDelay = attackDelay;
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

        public RaceName Race => race;

        public IEnumerable<ISpecialItem> Inventory => throw new System.NotImplementedException();

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();

        public virtual void TakeDamage(int damage)
        {
            // Iterate through Inventory and use items to modify damage before appolying to health
            this.Health -= damage;
        }
    }
}
