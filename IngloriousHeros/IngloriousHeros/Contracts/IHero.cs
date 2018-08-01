using System.Collections.Generic;

namespace IngloriousHeros.Contracts
{
    public interface IHero : IExhaustible
    {
        string Name { get; }

        double Health { get; }

        double Armour { get; }

        double Damage { get; }

        int AttackDelay { get; }

        IEnumerable<ISpecialItem> Inventory { get; }
    }
}
