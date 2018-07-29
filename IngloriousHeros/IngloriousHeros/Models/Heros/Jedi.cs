using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;

namespace IngloriousHeros.Models.Heros
{
    public class Jedi : Human, IHero
    {
        //TODO: Implement jedi class
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
