﻿using IngloriousHeros.Models.Common;
using System.Collections.Generic;
using IngloriousHeros.Models.SpecialSkills;

namespace IngloriousHeros.Models.Contracts
{
    public interface IRace
    {
        RaceName Race { get; }

        List<ISpecialSkills> SpecialSkills { get; }
    }
}