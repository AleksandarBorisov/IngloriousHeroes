using System.Collections.Generic;

namespace IngloriousHeros.Contracts
{
    public interface IHero : IExhaustible
    {
        double Health { get; }
        double Armour { get; }
        double Damage { get; }

        IEnumerable<ISpecialItem> Inventory { get; }
    }
}
