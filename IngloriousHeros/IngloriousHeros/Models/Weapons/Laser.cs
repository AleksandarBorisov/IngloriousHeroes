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
        //I've Added properties and fields for Damage and AtackDelay and ethod UseItem, modified IWeapon and IItem interfaces
        //TODO: Implement laser class

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


        public void UseItem(IHero hero)
        {
            var weaponItem = hero.Inventory.FirstOrDefault(w => w is IWeapon);
            if (weaponItem != null)
            {//Тук трябва да решим кой от двата варианта да оставим
                //Трябва да измислим начин да прескочим първия срещнат елемент и да вземам останалите
                IEnumerable<IItem> newInventory = hero.Inventory.OrderBy(t => t.GetType().Name).Skip(1);
                //IEnumerable<IItem> newInventory = hero.Inventory.TakeWhile(x => x != weaponItem).Skip(1);
                //List<IItem> tempList = hero.Inventory as List<IItem>;
                //tempList.Remove(weaponItem);
                hero.Inventory = newInventory;
                hero.Damage += this.BonusDamage;
                hero.AttackDelay -= this.BonusAtackDelay;

            }
        }

    }
}
