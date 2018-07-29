﻿using System.Collections.Generic;
using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;
using IngloriousHeros.Providers;

namespace IngloriousHeros.Models.Heros
{
    public class Wizzard : Warcraft, IHero
    {
        //TODO: Implement wizzard class
        private double health;

        private double armour;

        private double damage;

        private double healthConst = 1.3;

        private double armourConst = 1.0;

        private double damageConst = 0.7;

        public double Health
        {
            get => health;
            set
            {
                ValueCheck.Positive(value, "Health can't be negative!");
                this.health = base.InitialHealth * healthConst;
            }
        }

        public double Armour
        {
            get => this.armour;
            set
            {
                ValueCheck.Positive(value, "Armour can't be negative!");
                this.armour = base.InitialArmour * armourConst;
            }
        }

        public double Damage
        {
            get => this.damage;
            set
            {
                ValueCheck.Positive(value, "Damage can't be negative!");
                this.damage = base.InitialDamage * damageConst;
            }
        }

        public IEnumerable<ISpecialItem> Inventory => throw new System.NotImplementedException();

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
