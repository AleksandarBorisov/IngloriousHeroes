using IngloriousHeros.Models.Heros.Abstracts;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System;

namespace IngloriousHeros.Models.Heros
{
    public class Archer : Hero//, IHuman
    {
        private static bool doubleArrow = false;

        private static int criticalHitCount = 5;

        private static int hitCount = 0;
        
        //TODO: Add properties specific to class Archer
        public Archer(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {

        }

        public override void Attack(IHero oponent)
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
                        oponent.TakeDamage((int)this.Damage + bonusDamage);
                        Battle.MessageBuffer.Enqueue($"{this.Name} made critical hit------------------------------.");// damage to {oponent.Name}.");
                        Battle.MessageBuffer.PrintBuffer();

                        hitCount = 1;
                    }
                    oponent.TakeDamage((int)this.Damage + bonusDamage);
                    HealthBar.Update(oponent);

                }
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }
    }
}
