using System.Collections.Generic;

namespace IngloriousHeros.Contracts
{
    public interface IHero : IExhaustible
    {
        string Name { get; }

        double Health { get; set; }//Modified property added setter

        double Armour { get; }

        double Damage { get; set; }//Modified property added setter

        int AttackDelay { get; set; }//Modified property added setter

        IEnumerable<IItem> Inventory { get; set; }//Modified property added setter
    }
}
