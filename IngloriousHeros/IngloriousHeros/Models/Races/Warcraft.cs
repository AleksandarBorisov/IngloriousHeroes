using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Warcraft : IRace
    {
        private const double initialHealth = 120;

        private const double initialArmour = 110;

        private const double initialDamage = 70;

        public double InitialHealth
        {
            get
            {
                return initialHealth;
            }
        }

        public double InitialArmour
        {
            get
            {
                return initialArmour;
            }
        }

        public double InitialDamage
        {
            get
            {
                return initialDamage;
            }
        }


        private const RaceName race = RaceName.Warcraft;

        public RaceName Race => race;

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();
    }
}
