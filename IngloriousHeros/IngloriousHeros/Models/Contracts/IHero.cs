using System.Collections.Generic;

namespace IngloriousHeros.Models.Contracts
{
    public interface IHero : IExhaustible
    {
        int Health { get; }
        int Armour { get; }
        int Damage { get; }

        IEnumerable<ISpecialItem> Inventory { get; }
    }
}
