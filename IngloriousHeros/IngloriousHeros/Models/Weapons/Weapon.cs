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
            int damageToAdd = this.BonusDamage;//Работим с инстанцията, от която сме извикали метода UseItem
            BonusDamage--;//Засега не използваме TakeDamage, защото не сме сложили Charge-ове на самия Item
            if (BonusDamage == 0)
            {
                (hero.Inventory as List<IItem>).Remove(this);
            }

            return damageToAdd;
        }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
