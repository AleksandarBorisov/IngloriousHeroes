using IngloriousHeros.Models.Heros.Abstracts;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System;
using IngloriousHeros.Models.Races;

namespace IngloriousHeros.Models.Heros
{
    public class Archer : Hero, IHuman
    {
        private static int criticalHitCount = 5;
        private static int hitCount = 0;
        
        //TODO: Add properties specific to class Archer
        public Archer(string name, byte health, double damage, int attackDelay, Location hbLocation, IList<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {
            base.Race = RaceName.Human;
        }

        public List<ISpecialSkills> SpecialSkills => throw new NotImplementedException();

        public override void Attack()
        {
            Thread.Sleep(this.AttackDelay);

            int bonusDamage = 0;

            if (this.Inventory.Count() > 0 && this.Inventory.Any(w => w is IWeapon))
            {
                bonusDamage = this.Inventory.First(w => w is IWeapon).UseItem(this);
            }

            lock (Battle.EnvLock)
            {
                if (!Battle.Cts.Token.IsCancellationRequested)
                {
                    hitCount++;

                    if (hitCount == criticalHitCount)
                    {
                        this.Oponent.TakeDamage((int)this.Damage + bonusDamage);
                        Battle.MessageBuffer.Enqueue($"{this.Name} made critical hit------------------------------.");// damage to {oponent.Name}.");
                        Battle.MessageBuffer.PrintBuffer();

                        hitCount = 1;
                    }
                    this.Oponent.TakeDamage((int)this.Damage + bonusDamage);
                }
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
