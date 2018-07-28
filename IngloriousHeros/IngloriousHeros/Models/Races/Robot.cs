using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Robot : IRace
    {
        private const Race name = Race.Robot;

        public Race Name => throw new System.NotImplementedException();

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();
    }
}
