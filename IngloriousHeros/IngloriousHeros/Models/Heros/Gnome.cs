using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;
using System.Collections.Generic;

namespace IngloriousHeros.Models.Heros
{
    public class Gnome : Hero //IWarcraft//, IHero
    {
        //TODO: Add properties specific to class Gnome

        public Gnome(string name, double health, double damage, int attackDelay, List<IItem> items)
            : base(name, health, damage, attackDelay, items)
        {

        }

        public override void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
