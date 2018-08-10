using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace IngloriousHeros.Models.Armours
{

    public abstract class Armour : IArmour
    {
        public int BonusArmour { get; set; }

        public Armour(int bonusArmour)
        {
            this.BonusArmour = bonusArmour;
        }

        public int UseItem(IHero hero)
        {//We have to decide if the last hit breaks the item or the item ends when it expires and the hero acquires a new one if he has
            int armourToAdd = this.BonusArmour;
            if (BonusArmour <= 0)
            {
                (hero.Inventory as List<IItem>).Remove(this);
            }
            BonusArmour -= 10;

            return armourToAdd;

        }
        //Засега не използваме TakeDamage, защото не сме сложили Charge-ове на самия Item
        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
