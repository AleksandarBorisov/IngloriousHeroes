using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Heros;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IngloriousHeros.Models.Weapons
{
    public class Laser : IWeapon
    {
        private int bonusDamage;

        private int bonusAtackDelay;

        public Laser(int bonusDamage, int bonusAtackDelay)
        {
            this.BonusDamage = bonusDamage;
            this.BonusAtackDelay = bonusAtackDelay;
        }

        public int BonusDamage { get { return this.bonusDamage; } set { this.bonusDamage = value; } }

        public int BonusAtackDelay { get { return this.bonusAtackDelay; } set { this.bonusAtackDelay = value; } }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }


        public int UseItem(IHero hero)
        {
            var weaponItem = hero.Inventory.First();
            int givenDamage = (weaponItem as Laser).BonusDamage;
            BonusDamage--;
            if (BonusDamage == 0)
            {
                (hero.Inventory as List<IItem>).Remove(weaponItem);
            }

            return givenDamage;
        }
    }
}
