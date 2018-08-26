﻿using IngloriousHeros.Models.Common;
using System.Collections.Generic;

namespace IngloriousHeros.Models.Contracts
{
    public interface IHero : IExhaustible
    {
        RaceName Race { get; }

        string Name { get; }

        byte Health { get; set; }

        double Armour { get; }

        double Damage { get; set; }

        int AttackDelay { get; set; }

        int Wins { get; set; }

        IHero Oponent { get; set; }

        Location HbLocation { get; set; }

        IList<IItem> Inventory { get; set; }

        void Attack();
    }
}
