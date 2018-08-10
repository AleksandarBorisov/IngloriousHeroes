using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Heros.Abstracts;
using IngloriousHeros.Models.Contracts;
using System.Collections.Generic;
using System.Threading;

namespace IngloriousHeros.Models.Heros
{
    public class Wizzard : Hero //IWarcraft//, IHero
    {
        private List<IItem> spells;
        private bool hasUsedSpell = false;

        public Wizzard(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {
            this.Spells = spells;
        }

        public List<IItem> Spells
        {
            get => this.spells;
            set => this.spells = value;
        }

        public override void Attack(IHero oponent)
        {
            Thread.Sleep(this.AttackDelay);

            lock (Battle.EnvLock)
            {
                string spell = $"{this.Name} has cast an AttackDelay spell on {oponent.Name}!     >>>>>>>>>> S P E L L L <<<<<<<<<<";

                if (this.Health < 20 && this.hasUsedSpell == false)
                {
                    this.hasUsedSpell = true;
                    oponent.AttackDelay = 500;
                    Battle.MessageBuffer.Enqueue(spell);
                    Battle.MessageBuffer.PrintBuffer();
                }

                oponent.TakeDamage((int)this.Damage);

                // What if oponent dies after damage above?
                if (!Battle.Cts.Token.IsCancellationRequested)
                {
                    Battle.MessageBuffer.Enqueue($"{this.Name} deals {(int)((this.Damage))} damage to {oponent.Name}.");
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
