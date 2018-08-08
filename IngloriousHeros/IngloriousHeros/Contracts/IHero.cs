using IngloriousHeros.Core.Battle;
using IngloriousHeros.Models.Common;
using System.Collections.Generic;

namespace IngloriousHeros.Contracts
{
    public interface IHero : IExhaustible
    {
        string Name { get; }

        double Health { get; set; }

        double Armour { get; }

        double Damage { get; set; }

        int AttackDelay { get; set; }

        Location HbLocation { get; set; }

        IEnumerable<IItem> Inventory { get; set; }

        void Attack(IHero oponent);
    }
}
