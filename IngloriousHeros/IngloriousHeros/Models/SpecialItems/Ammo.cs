using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Models.Items
{
    public class Ammo : IItem
    {
        //Тези неща може да намери героя преди или след битка
        //и са т.н. consumables, т.е. boost-ват някакъв stat еднократно и няма как да се изхабят
        //TODO: Implement ammo class
        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        public void UseItem()
        {
            // The Hero will have a List<IItems> and before each turn, he will Foreach through the
            // items list and call item.UseItem();. Each item will have a different implementation
            // depending if it is a potion, metal or ammo. Ex. ammo.UseItem() will add to the attack.
            throw new System.NotImplementedException();
        }
    }
}
