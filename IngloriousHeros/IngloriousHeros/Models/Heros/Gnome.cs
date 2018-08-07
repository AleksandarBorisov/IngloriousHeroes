using IngloriousHeros.Contracts;
using IngloriousHeros.Core.Battle;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Races;
using System.Collections.Generic;

namespace IngloriousHeros.Models.Heros
{
    public class Gnome : Hero//, IWarcraft, IHero
    {
        //TODO: Add properties specific to class Gnome

        public Gnome(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {

        }

        public override void Attack(IHero oponent, Battle battle)
        {
            throw new System.NotImplementedException();
        }

        public override void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
