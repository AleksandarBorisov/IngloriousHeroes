using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Warcraft : IRace
    {
        private const Race name = Race.Warcraft;

        public Race Name => this.Name;

        public IEnumerable<IHero> HeroClasses => throw new System.NotImplementedException();
    }
}
