using IngloriousHeros.Contracts;

namespace IngloriousHeros.Models.Armours
{
    public class Helmet : IArmour
    {
        //TODO: Implement helmet class
        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        public Helmet(int armor, int health)
        {

        }

        public void UseItem()
        {
            throw new System.NotImplementedException();
        }

        public void UseItem(IHero hero)
        {
            throw new System.NotImplementedException();
        }

        int IItem.UseItem(IHero hero)
        {
            throw new System.NotImplementedException();
        }
    }
}
