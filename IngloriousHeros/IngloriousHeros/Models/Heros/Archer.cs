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
            int bonusArmour = 0;//0 % reduction of damage

            if (this.Inventory.Count() > 0 && this.Inventory.Any(w => w is IWeapon))
            {
                bonusDamage = this.Inventory.First(w => w is IWeapon).UseItem(this);
            }

            //This should be implemented in TakeDamage(this.Damage)-- > it will be called by the oponent
            if (oponent.Inventory.Count() > 0 && oponent.Inventory.Any(a => a is IArmour))
            {
                bonusArmour = oponent.Inventory.First(a => a is IArmour).UseItem(this);
            }

            lock (Battle.EnvLock)
            {
                if (!Battle.Cts.Token.IsCancellationRequested)
                {
                    oponent.TakeDamage((int)this.Damage);
                    // The formula below should be checked
                    Battle.MessageBuffer.Enqueue($"{this.Name} deals {(int)((this.Damage + bonusDamage) * (1 - bonusArmour / 100.0))} damage to {oponent.Name}.");
                    Battle.MessageBuffer.PrintBuffer();
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
