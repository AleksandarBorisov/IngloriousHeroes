using IngloriousHeros.Models.Common;
using System.Collections.Generic;

namespace IngloriousHeros.Models.Contracts
{
    public interface IRace
    {
        Race Name { get; }
        IEnumerable<IHero> HeroClasses { get; }
        //TODO: Implement IRace interface
    }
}
