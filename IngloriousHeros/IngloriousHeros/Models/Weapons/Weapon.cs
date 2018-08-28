using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Heros;
using System.Collections.Generic;
using System.Linq;
using System;

namespace IngloriousHeros.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        public int BonusDamage { get; set; }

        public Weapon(int bonusDamage)
        {
            this.BonusDamage = bonusDamage;
        }

        public int UseItem(IHero hero)
        {
            int damageToAdd = this.BonusDamage;//Работим с инстанцията, от която сме извикали метода UseItem
            BonusDamage--;//Засега не използваме TakeDamage, защото не сме сложили Charge-ове на самия Item
            if (BonusDamage <= 0)
            {
                if (hero.Inventory.Count == 0)
                {
                    throw new ArgumentException("There is no item to be removed from inventory");
                }
                hero.Inventory.Remove(this);
            }

            return damageToAdd;
        }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
