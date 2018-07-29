using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Races;

namespace IngloriousHeros.Models.Heros
{
    public class Gnome : Warcraft, IHero
    {
        //TODO: Implement gnome class
        public int Health => throw new System.NotImplementedException();

        public int Armour => throw new System.NotImplementedException();

        public int Damage => throw new System.NotImplementedException();

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
