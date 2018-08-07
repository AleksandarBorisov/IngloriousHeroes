using IngloriousHeros.Contracts;
using System.Collections.Generic;

namespace IngloriousHeros.Models.Heros
{
    public class Archer : Hero//, IHuman
    {
        //TODO: Add properties specific to class Archer
        //I've modified this constuctor to take as parameter List of items
        public Archer(string name, double health, double damage, int attackDelay, List<IItem> items)
            : base(name, health, damage, attackDelay, items)
        {

        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
