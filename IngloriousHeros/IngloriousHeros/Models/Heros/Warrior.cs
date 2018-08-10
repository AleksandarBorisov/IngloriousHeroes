using System.Collections.Generic;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Races;
using IngloriousHeros.Providers;
using IngloriousHeros.Models.Heros.Abstracts;

namespace IngloriousHeros.Models.Heros
{
    public class Warrior : Hero //IRobot//, IHero
    {
        //TODO: Add properties specific to class Warrior

        public Warrior(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {

        }

        public override void Attack(IHero oponent)
        {
            throw new System.NotImplementedException();
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
