using System.Collections.Generic;
using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;
using IngloriousHeros.Providers;

namespace IngloriousHeros.Models.Heros
{
    public class Warrior : Hero //IRobot//, IHero
    {
        //TODO: Add properties specific to class Warrior

        public Warrior(string name, double health, double damage, int attackDelay, List<IItem> items)
            : base(name, health, damage, attackDelay, items)
        {

        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
