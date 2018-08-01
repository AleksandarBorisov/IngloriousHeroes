using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;

namespace IngloriousHeros.Models.Heros
{
    public class Brute : Robot, IHero
    {
        //TODO: Add properties specific to class Brute

        public Brute(string name, double health, double damage, int attackDelay)
            : base(name, health, damage, attackDelay)
        {
            
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
