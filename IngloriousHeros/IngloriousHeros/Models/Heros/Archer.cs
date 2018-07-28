using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Models.Heros
{
    public class Archer : IHero
    {

        public Race Name => throw new System.NotImplementedException();

        public int Health => throw new System.NotImplementedException();

        public int Armour => throw new System.NotImplementedException();

        public int Damage => throw new System.NotImplementedException();

        Race IHero.HeroRace => throw new System.NotImplementedException();

        public Race HeroRace = Race.Human;

        //TODO: Implement archer class
        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
