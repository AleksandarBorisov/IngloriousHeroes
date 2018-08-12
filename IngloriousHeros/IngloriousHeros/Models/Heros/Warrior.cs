using System.Collections.Generic;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Races;
using IngloriousHeros.Providers;
using IngloriousHeros.Models.Heros.Abstracts;
using System.Threading;

namespace IngloriousHeros.Models.Heros
{
    public class Warrior : Hero, IRobot
    {
        //TODO: Add properties specific to class Warrior
        private RaceName race = RaceName.Robot;

        public Warrior(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
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
