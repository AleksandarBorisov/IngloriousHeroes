﻿using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Warcraft : IRace
    {
        private const RaceName race = RaceName.Warcraft;

        public RaceName Race => race;

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();
    }
}
