using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;

namespace IngloriousHeros.Models.Heros
{
    public class Wizzard : Warcraft, IHero
    {
        //TODO: Add properties specific to class Warrior

        public Wizzard(string name, double health, double damage, int attackDelay)
            : base(name, health, damage, attackDelay)
        {

        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
