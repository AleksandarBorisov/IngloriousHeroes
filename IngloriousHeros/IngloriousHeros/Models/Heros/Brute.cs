using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;
using IngloriousHeros.Contracts;

namespace IngloriousHeros.Models.Heros
{
    public class Brute : Robot, IHero
    {
        //TODO: Implement brute class
        public int Health => throw new System.NotImplementedException();

        public int Armour => throw new System.NotImplementedException();

        public int Damage => throw new System.NotImplementedException();

        public IEnumerable<ISpecialItem> Inventory => throw new System.NotImplementedException();

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
