﻿using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Models.Heros
{
    public class Warrior : IHero, IItem
    {
        //TODO: Implement warrior class
        public Race HeroRace => throw new System.NotImplementedException();

        public int Health => throw new System.NotImplementedException();

        public int Armour => throw new System.NotImplementedException();

        public int Damage => throw new System.NotImplementedException();

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
