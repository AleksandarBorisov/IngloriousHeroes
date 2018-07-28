using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Models.Heros
{
    public abstract class Hero : IHClass
    {
        public HeroType Type { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
