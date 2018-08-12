using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.SpecialSkills;
using System.Collections.Generic;

namespace IngloriousHeros.Models.Races
{
    public interface IFantasoid
    {
        int Mana { get; }
        List<FantasoidSkill> Spells { get; }
    }
}
