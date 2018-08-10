using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Heros.Abstracts;
using IngloriousHeros.Models.Contracts;
using System.Collections.Generic;

namespace IngloriousHeros.Models.Heros
{
    public class Jedi : Hero//, IHuman, IHero
    {
        //TODO: Implement jedi class
        public Jedi(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {

        }

        public override void Attack(IHero oponent)
        {
            throw new System.NotImplementedException();
        }
    }
}
