using IngloriousHeros.Contracts;
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
        {//TODO: Fix Armour
            int armourToAdd = this.BonusArmour;
            BonusArmour -= 10;//От тук надолу гърми на десетия удар. Вижда се че се опитва от инвенторите на Archer-a
            if (BonusArmour <= 0)//да извади Армора на Brute-a
            {
                (hero.Inventory as List<IItem>).Remove(this);
            }//Тук пише ^ Archer                         ^ Тук е Армора на Brute-a

            return armourToAdd;

        }
        //Засега не използваме TakeDamage, защото не сме сложили Charge-ове на самия Item
        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
