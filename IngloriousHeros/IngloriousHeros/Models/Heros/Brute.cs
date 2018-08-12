using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Heros.Abstracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using IngloriousHeros.Models.Races;

namespace IngloriousHeros.Models.Heros
{
    public class Brute : Hero, IRobot
    {
        private RaceName race = RaceName.Robot;

        //TODO: Add properties specific to class Brute
        public Brute(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {
            
        }

        public RaceName Race => this.race;

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();

        public override void Attack(IHero oponent)
        {
            Thread.Sleep(this.AttackDelay);

            int bonusDamage = 0;//0 point bonus to damage

            if (this.Inventory.Count() > 0 && this.Inventory.Any(w => w is IWeapon))
            {
                bonusDamage = this.Inventory.First(w => w is IWeapon).UseItem(this);
            }

            lock (Battle.EnvLock)
            {
                if (!Battle.Cts.Token.IsCancellationRequested)
                {
                    oponent.TakeDamage((int)this.Damage + bonusDamage);
                }
            }
        }
    }
}
