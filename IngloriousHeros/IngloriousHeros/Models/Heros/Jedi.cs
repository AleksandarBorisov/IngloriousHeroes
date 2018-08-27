using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Heros.Abstracts;
using System.Collections.Generic;
using System.Threading;
using IngloriousHeros.Models.Races;

namespace IngloriousHeros.Models.Heros
{
    public class Jedi : Hero, IHuman
    {
        //TODO: Implement jedi class

        public Jedi(string name, sbyte health, double damage, int attackDelay, Location hbLocation, IList<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {
            base.Race = RaceName.Human;
            this.SpecialSkills = new List<ISpecialSkills>();
        }

        public List<ISpecialSkills> SpecialSkills { get; set; }

        public override void Attack()
        {
            Thread.Sleep(this.AttackDelay);

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
