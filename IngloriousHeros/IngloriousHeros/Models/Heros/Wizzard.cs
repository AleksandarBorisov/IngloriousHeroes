using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;
using System.Collections.Generic;

namespace IngloriousHeros.Models.Heros
{
    public class Wizzard : Hero //IWarcraft//, IHero
    {
        //TODO: Add properties specific to class Warrior

        public Wizzard(string name, double health, double damage, int attackDelay, List<IItem> items)
            : base(name, health, damage, attackDelay, items)
        {

        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
