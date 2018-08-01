using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;

namespace IngloriousHeros.Models.Heros
{
    public class Jedi : Human, IHero
    {
        //TODO: Implement jedi class
        public Jedi(string name, double health, double damage, int attackDelay)
            : base(name, health, damage, attackDelay)
        {

        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
