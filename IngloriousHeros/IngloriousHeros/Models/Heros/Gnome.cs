using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Heros.Abstracts;
using IngloriousHeros.Models.Races;
using System.Collections.Generic;
using System.Threading;
using IngloriousHeros.Models.SpecialSkills;

namespace IngloriousHeros.Models.Heros
{
    public class Gnome : Hero, IFantasoid
    {
        private int mana;

        public Gnome(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {
            base.Race = RaceName.Fantasoid;
            this.Mana = 0;
        }

        public int Mana
        {
            get => this.mana;
            private set => this.mana = value;
        }

        public List<FantasoidSkill> Spells => throw new System.NotImplementedException();

        public override void Attack()
        {
            Thread.Sleep(this.AttackDelay);

            this.Mana++;

            if (this.Mana > 30)
            {
                // Use skill at index 2
            }
            else if (this.Mana > 20)
            {
                // Use skill at index 1
            }
            else if (this.Mana > 10)
            {
                // Use skill at index 0
            }

            lock (Battle.EnvLock)
            {
                if (!Battle.Cts.Token.IsCancellationRequested)
                {
                    this.Oponent.TakeDamage((int)this.Damage);
                }
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
