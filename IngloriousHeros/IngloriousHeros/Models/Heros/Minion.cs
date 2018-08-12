using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Contracts;
using System.Threading;

namespace IngloriousHeros.Models.Heros
{
    public class Minion
    {
        // A Minion is an Undead creature that can attack the oponent of the Wizzard that summoned it
        // The Minion cannot be attacked (how do you attack that which has already been dead?)
        // and disappears after the current battle. The Minion attacks the oponent's health directly

        private int damage;
        private int attackDelay;

        public Minion(int damage, int attackDelay)
        {
            this.Damage = damage;
            this.AttackDelay = attackDelay;
        }

        public int Damage
        {
            get => this.damage;
            set => this.damage = value;
        }

        public int AttackDelay
        {
            get => this.attackDelay;
            set => this.attackDelay = value;
        }

        public void Attack(IHero enemy)
        {
            Thread.Sleep(this.AttackDelay);
            enemy.Health -= this.Damage;
            HealthBar.Update(enemy);
        }
    }
}
