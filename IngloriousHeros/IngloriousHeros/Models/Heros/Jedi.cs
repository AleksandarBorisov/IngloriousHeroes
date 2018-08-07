using IngloriousHeros.Contracts;
using System.Collections.Generic;

namespace IngloriousHeros.Models.Heros
{
    public class Jedi : Hero//, IHuman//, IHero
    {
        //TODO: Implement jedi class
        public Jedi(string name, double health, double damage, int attackDelay, List<IItem> items)
            : base(name, health, damage, attackDelay, items)
        {

        }
    }
}
