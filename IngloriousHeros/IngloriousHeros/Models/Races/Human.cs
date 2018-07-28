using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Human : IRace
    {
        private Race name = Race.Human;

        public Race Name
        {
            get
            {
                return this.name;
            }
        }

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();
    }
}
