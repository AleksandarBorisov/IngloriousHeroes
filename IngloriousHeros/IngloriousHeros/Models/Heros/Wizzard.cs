using IngloriousHeros.Core.Game;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Heros.Abstracts;
using IngloriousHeros.Models.Contracts;
using System.Collections.Generic;
using System.Threading;
using IngloriousHeros.Models.Races;
using System.Linq;
using IngloriousHeros.Models.SpecialSkills;
using System;
using System.Threading.Tasks;
using IngloriousHeros.Core.UI;

namespace IngloriousHeros.Models.Heros
{
    public class Wizzard : Hero, IFantasoid
    {
        /// <summary>
        /// - The Wizzard Class has three special spells that can only be used once
        ///   and in circumstances where the Wizzard is dreatly disadvantaged.
        /// - The special spells do not require any Mana
        /// - The rest of the spells from the list Spells require Mana to be used
        /// </summary>

        private int mana;
        private List<FantasoidSkill> spells;
        private bool hasUsedAttackDelaySpell = false;
        private bool hasUsedBlackMagic = false;
        private bool hasSummonedAMinion = false;
        private Minion minionUndead = null;

        public Wizzard(string name, double health, double damage, int attackDelay, Location hbLocation, List<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {
            base.Race = RaceName.Fantasoid;
            this.Spells = spells;
            this.SpecialSkills = new List<ISpecialSkills>();
        }

        public int Mana
        {
            get => this.mana;
            private set => this.mana = value;
        }

        public List<FantasoidSkill> Spells
        {
            get => this.spells;
            set => this.spells = value;
        }

<<<<<<< HEAD
        public Minion MinionUndead
        {
            get => this.minionUndead;
            set => this.minionUndead = value;
        }
=======
        public RaceName Race => this.race;

        public List<ISpecialSkills> SpecialSkills {get; set;}
>>>>>>> 180a5c2eda2e9054bf6b9ccf33b42e7a253089fa

        public override void Attack(IHero oponent)
        {
            Thread.Sleep(this.AttackDelay);

            this.Mana += 5;

            this.ConjureUpABlackMagic();

            if (this.hasUsedBlackMagic)
            {
                return;
            }

            if (hasSummonedAMinion == false)
            {
                hasSummonedAMinion = true;
                SummonAMinion();
            }

            FantasoidSkill currentSpell;

            try
            {
                currentSpell = GetSpell();
                string spellDescription = GetSpellDescription(currentSpell);

                Battle.MessageBuffer.Enqueue($"{this.Name} has used a spell --> {currentSpell.Name} <-- to {spellDescription}!");
            }
            catch (Exception)
            {
                Battle.MessageBuffer.Enqueue($"{this.Name} is low on Mana/Spells!");
            }

            lock (Battle.EnvLock)
            {
                if (this.Health < 20 && this.hasUsedAttackDelaySpell == false)
                {
                    this.hasUsedAttackDelaySpell = true;
                    string spell = $"{this.Name} has cast an AttackDelay spell on {oponent.Name}!     >>>>>>>>>> S P E L L L <<<<<<<<<<";
                    oponent.AttackDelay += 500;
                    Battle.MessageBuffer.Enqueue(spell);
                    Battle.MessageBuffer.PrintBuffer();
                }

                if (this.MinionUndead != null)
                {
                    this.MinionUndead.Attack(this.Oponent);
                    Battle.MessageBuffer.Enqueue($"The Minion deals {this.Damage} damage to {this.Oponent.Name}");
                }

                oponent.TakeDamage((int)this.Damage);
            }
        }

        private string GetSpellDescription(FantasoidSkill spell)
        {
            string result = "";

            switch (spell.Type)
            {
                case SpellType.DamageHealth:
                    result = $"deal {spell.Value} damage to {this.Oponent.Name}";
                    break;
                case SpellType.DamageWeapon:
                    result = $"damage {this.Oponent.Name}'s weapons by {spell.Value} attack units";
                    break;
                case SpellType.DamageArmour:
                    result = $"weaken {this.Oponent.Name}'s armour by {spell.Value} defence units";
                    break;
                case SpellType.BlockAttack:
                    result = $"block {this.Oponent.Name}'s current attack";
                    break;
                case SpellType.Regeneration:
                    result = $"to regenerate his health by {spell.Value} units";
                    break;
            }

            return result;
        }

        private void ConjureUpABlackMagic()
        {
            if (this.Health < 10 && this.Oponent.Health > 10 && this.hasUsedBlackMagic == false)
            {
                this.hasUsedBlackMagic = true;

                double tempHealth = this.Health;
                this.Health = this.Oponent.Health;
                this.Oponent.Health = tempHealth;

                HealthBar.Draw(this);
                HealthBar.Draw(this.Oponent);

                HealthBar.Update(this);
                HealthBar.Update(this.Oponent);

                Battle.MessageBuffer.Enqueue($"{this.Name} has used a black magic to steal {this.Oponent.Name}'s blood!");
            }
        }

        private void SummonAMinion()
        {
            this.MinionUndead = new Minion(5, 500);
        }

        private FantasoidSkill GetSpell()
        {
            var curretSpell = this.Spells
                .First(s => s.ManaRequirement > this.Mana);

            this.Spells.Remove(curretSpell);

            this.Mana -= curretSpell.ManaRequirement;

            return curretSpell;
        }
    }
}
