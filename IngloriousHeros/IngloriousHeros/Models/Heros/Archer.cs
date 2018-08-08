using IngloriousHeros.Contracts;
using IngloriousHeros.Core.Battle;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace IngloriousHeros.Models.Heros
{
    public class Archer : Hero//, IHuman
    {
        //TODO: Add properties specific to class Archer
        public Archer(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {

        }

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
                {//The problem here will be that this message says how much damage is dealt, but not how much damage is made
                    //I think The message should be moved to the Amrour area where the reduction of the damage is made, in order
                    // to display the actual damage being made
                    oponent.TakeDamage((int)this.Damage + bonusDamage);
                    //I moved the buffer in take damage because i suggested it's more suitable there
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
