using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;
using System.Collections.Generic;

namespace IngloriousHeros.Models.Heros
{
    public class Brute : Hero //IRobot, IHero
    {
        //TODO: Add properties specific to class Brute
        //I've modified this constuctor to take as parameter List of items
        public Brute(string name, double health, double damage, int attackDelay, List<IItem> items)
            : base(name, health, damage, attackDelay, items)
        {
            
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
