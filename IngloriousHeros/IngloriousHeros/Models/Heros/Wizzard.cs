using IngloriousHeros.Contracts;
using IngloriousHeros.Core.Battle;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Races;
using System.Collections.Generic;

namespace IngloriousHeros.Models.Heros
{
    public class Wizzard : Hero //IWarcraft//, IHero
    {
        //TODO: Add properties specific to class Wizzard
        private List<IItem> spells;

        public Wizzard(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items, List<IItem> spells)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {
            this.Spells = spells;
        }

        public List<IItem> Spells
        {
            get => this.spells;
            set => this.spells = value;
        }

        public override void Attack(IHero oponent, Battle battle)
        {
            throw new System.NotImplementedException();
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
