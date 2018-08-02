using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Warcraft : IRace//, IHero
    {
        private string name;
        private double health;
        private double armour;
        private double damage;
        private int attackDelay;
        private const RaceName race = RaceName.Warcraft;

        public Warcraft(string name, double health, double damage, int attackDelay)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.AttackDelay = attackDelay;
        }

        //TODO: Validate all properties
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public double Health
        {
            get => this.health;
            set => this.health = value;
        }

        public double Armour
        {
            get => this.armour;
            set => this.armour = value;
        }

        public double Damage
        {
            get => this.damage;
            set => this.damage = value;
        }

        public int AttackDelay
        {
            get => this.attackDelay;
            set => this.attackDelay = value;
        }

        public RaceName Race => race;

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();

        public IEnumerable<ISpecialItem> Inventory => throw new System.NotImplementedException();

        public virtual void TakeDamage(int damage)
        {
            this.Health -= damage;
        }
    }
}
