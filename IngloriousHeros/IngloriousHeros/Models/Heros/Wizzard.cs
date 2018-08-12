using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Heros.Abstracts;
using IngloriousHeros.Models.Contracts;
using System.Collections.Generic;
using System.Threading;
using IngloriousHeros.Models.Races;

namespace IngloriousHeros.Models.Heros
{
    public class Wizzard : Hero, IFantasoid
    {
        private RaceName race = RaceName.Fantasoid;
        private List<IItem> spells;
        private bool hasUsedSpell = false;

        public Wizzard(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {
            this.Spells = spells;
            this.SpecialSkills = new List<ISpecialSkills>();
        }

        public List<IItem> Spells
        {
            get => this.spells;
            set => this.spells = value;
        }

        public RaceName Race => this.race;

        public List<ISpecialSkills> SpecialSkills {get; set;}

        public override void Attack(IHero oponent)
        {
            Thread.Sleep(this.AttackDelay);

            lock (Battle.EnvLock)
            {
                string spell = $"{this.Name} has cast an AttackDelay spell on {oponent.Name}!     >>>>>>>>>> S P E L L L <<<<<<<<<<";

                if (this.Health < 20 && this.hasUsedSpell == false)
                {
                    this.hasUsedSpell = true;
                    oponent.AttackDelay += 500;
                    Battle.MessageBuffer.Enqueue(spell);
                    Battle.MessageBuffer.PrintBuffer();
                }

                oponent.TakeDamage((int)this.Damage);
            }
        }
    }
}
