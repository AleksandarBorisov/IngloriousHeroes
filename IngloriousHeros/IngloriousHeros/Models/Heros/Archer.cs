using System.Collections.Generic;
using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;


namespace IngloriousHeros.Models.Heros
{
    public class Archer : Human, IHero
    {
        //Реално Archer-a ще си вземе расата и специалните умения от типа раса, който му подадем
        //Защото в началото ние не знаем Archer-a от коя раса е
        //Ако Archer-a наследи директно расата, ще трябва да го дефинираме за всяка една раса
        //Изтрих абстрактния клас Hero, защото ние така или инче ще трябва да дефинираме stats за всеки герой
        //От IItem ще дойде влиянието на самата битка върху stats на героя

        public int Health => throw new System.NotImplementedException();

        public int Armour => throw new System.NotImplementedException();

        public int Damage => throw new System.NotImplementedException();

        public IEnumerable<ISpecialItem> Inventory => throw new System.NotImplementedException();

        //TODO: Implement archer class
        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
