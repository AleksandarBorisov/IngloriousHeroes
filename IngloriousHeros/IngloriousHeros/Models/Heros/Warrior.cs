using System.Collections.Generic;
using IngloriousHeros.Contracts;
using IngloriousHeros.Core.Battle;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Races;
using IngloriousHeros.Providers;

namespace IngloriousHeros.Models.Heros
{
    public class Warrior : Hero //IRobot//, IHero
    {
        //TODO: Add properties specific to class Warrior

        public Warrior(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {

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
