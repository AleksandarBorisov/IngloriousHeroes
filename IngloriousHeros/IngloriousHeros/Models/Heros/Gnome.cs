using IngloriousHeros.Contracts;
using IngloriousHeros.Models.Races;

namespace IngloriousHeros.Models.Heros
{
    public class Gnome : Warcraft//, IHero
    {
        //TODO: Add properties specific to class Gnome

        public Gnome(string name, double health, double damage, int attackDelay)
            : base(name, health, damage, attackDelay)
        {

        }

        public override void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
