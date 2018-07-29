using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Human : IRace
    {
        private const RaceName race = RaceName.Human;

        public RaceName Race => race;

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();
    }
}
