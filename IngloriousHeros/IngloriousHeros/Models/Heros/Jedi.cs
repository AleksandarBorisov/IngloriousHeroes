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
        private RaceName race = RaceName.Human;

        public Jedi(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {

        }

        public RaceName Race => this.race;

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();

        public override void Attack(IHero oponent)
        {
            Thread.Sleep(this.AttackDelay);

            lock (Battle.EnvLock)
            {
                if (!Battle.Cts.Token.IsCancellationRequested)
                {
                    oponent.TakeDamage((int)this.Damage);
                }
            }
        }
    }
}
