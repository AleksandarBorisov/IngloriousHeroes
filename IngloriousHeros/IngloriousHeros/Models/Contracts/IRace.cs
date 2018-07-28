using IngloriousHeros.Models.Common;
using System.Collections.Generic;
using IngloriousHeros.Models.SpecialSkills;

namespace IngloriousHeros.Models.Contracts
{
    public interface IRace
    {
        Race Name { get; }

        List<ISpecialSkills> SpecialSkills { get; }

        //TODO: Implement IRace interface
    }
}
