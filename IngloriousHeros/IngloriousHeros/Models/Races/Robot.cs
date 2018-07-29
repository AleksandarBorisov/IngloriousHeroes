using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Robot : IRace
    {
        private const RaceName race = RaceName.Robot;

        public RaceName Race => race;

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();
    }
}
