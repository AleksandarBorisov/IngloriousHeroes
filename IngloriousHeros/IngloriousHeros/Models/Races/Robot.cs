using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Robot : IRace
    {
        private const double initialHealth = 150;

        private const double initialArmour = 100;

        private const double initialDamage = 50;

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

        private const RaceName race = RaceName.Robot;

        public RaceName Race => race;

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();
    }
}
