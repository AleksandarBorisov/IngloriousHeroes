using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Human : IRace
    {
        private const RaceName race = RaceName.Human;
        public List<ISpecialSkills> specialSkills;

        public Human(List<ISpecialSkills> specialSkills)
        {
            this.SpecialSkills = specialSkills;
        }

        public RaceName Race => race;

        public List<ISpecialSkills> SpecialSkills
        {
            get => this.specialSkills;
            set => this.specialSkills = value;
        }
    }
}
