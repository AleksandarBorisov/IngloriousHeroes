﻿using IngloriousHeros.Models.Heros;

namespace IngloriousHeros.Contracts
{
    public interface IItem : IExhaustible
    {
        //IHero Owner { get; }

        int UseItem(IHero hero);
        //TODO: Implement IItem interface
    }
}
