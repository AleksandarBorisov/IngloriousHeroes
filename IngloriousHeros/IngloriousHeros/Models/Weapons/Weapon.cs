using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Heros;
using System.Collections.Generic;
using System.Linq;

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
            var weaponItem = hero.Inventory.First();
            int givenDamage = this.BonusDamage;
            BonusDamage--;//Засега не използваме TakeDamage, защото не сме сложили Charge-ове на самия Item
            if (BonusDamage == 0)
            {
                (hero.Inventory as List<IItem>).Remove(weaponItem);
            }

            return givenDamage;
        }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
