using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Heros.Abstracts;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Models.Races;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace IngloriousHeros.Models.Heros
{
    public class Brute : Hero //IRobot, IHero
    {
        //TODO: Add properties specific to class Brute
        public Brute(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
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
                {
                    // The formula below should be checked
                    //Battle.MessageBuffer.Enqueue($"{this.Name} deals {(int)(this.Damage + bonusDamage)} damage to {oponent.Name}.");
                    //Battle.MessageBuffer.PrintBuffer();
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
