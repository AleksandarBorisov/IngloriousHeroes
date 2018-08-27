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

        public Wizzard(string name, sbyte health, double damage, int attackDelay, Location hbLocation, IList<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {
            base.Race = RaceName.Fantasoid;
            this.Spells = spells;
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

        public Minion MinionUndead
        {
            get => this.minionUndead;
            set => this.minionUndead = value;
        }

        public override void Attack()
        {
            Thread.Sleep(this.AttackDelay);

            lock (Battle.EnvLock)
            {
                this.Mana += 5;

                if (this.Health < 10 && this.Oponent.Health > 10 && this.hasUsedBlackMagic == false)
                {
                    this.hasUsedBlackMagic = true;
                    this.ConjureUpABlackMagic();
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


                if (this.Health < 20 && this.hasUsedAttackDelaySpell == false)
                {
                    this.hasUsedAttackDelaySpell = true;
                    string spell = $"{this.Name} has cast an AttackDelay spell on {this.Oponent.Name}!     >>>>>>>>>> S P E L L L <<<<<<<<<<";
                    this.Oponent.AttackDelay += 500;
                    Battle.MessageBuffer.Enqueue(spell);
                    Battle.MessageBuffer.PrintBuffer();
                }

                if (this.MinionUndead != null)
                {
                    this.MinionUndead.Attack(this.Oponent);
                    Battle.MessageBuffer.Enqueue($"The Minion deals {this.Damage} damage to {this.Oponent.Name}");
                }

                this.Oponent.TakeDamage((int)this.Damage);
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
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
            lock (Battle.EnvLock)
            {
                double tempHealthHero = this.Health;
                double tempHealthOponent = this.Oponent.Health;

                this.Health = (sbyte)tempHealthOponent;
                this.Oponent.Health = (sbyte)tempHealthHero;

                HealthBar.Draw(this);
                HealthBar.Update(this);

                HealthBar.Draw(this.Oponent);
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
            lock (Battle.EnvLock)
            {
                var curretSpell = this.Spells
                    .First(s => s.ManaRequirement > this.Mana);

                this.Spells.Remove(curretSpell);

                this.Mana -= curretSpell.ManaRequirement;

                return curretSpell;
            }
        }
    }
}
