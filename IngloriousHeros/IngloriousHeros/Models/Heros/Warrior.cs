﻿using System.Collections.Generic;
using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Races;
using System.Linq;
using IngloriousHeros.Models.Heros.Abstracts;
using System.Threading;
using IngloriousHeros.Models.SpecialSkills;
using IngloriousHeros.Core.Game.Interfaces;

namespace IngloriousHeros.Models.Heros
{
    public class Warrior : Hero, IRobot
    {
        private RobotSkills transformation;

        private bool hasTransformed = false;

        private int currentHits;

        private int hitsBeforeTransform = 5;

        //private IWorld world;

        public Warrior(string name, sbyte health, double damage, int attackDelay, Location hbLocation, IList<IItem> items)
            : base(name, health, damage, attackDelay, hbLocation, items)
        {
            //this.world = world;
            base.Race = RaceName.Robot;
            this.SpecialSkills = new List<ISpecialSkills>();
        }

        public List<ISpecialSkills> SpecialSkills { get; set; }

        public RobotSkills Transformation
        {
            get { return this.transformation; }
            set
            {
                this.transformation = value;
            }
        }

        public override void Attack()
        {
            Thread.Sleep((int)(this.AttackDelay));

            currentHits++;

            if (currentHits == hitsBeforeTransform)
            {
                hasTransformed = !hasTransformed;
                if (hasTransformed)
                {
                    Transform(this.Wins);
                }
                else if (Transformation != null)
                {
                    BackToNormal();
                }
            }

            int bonusDamage = 0;

            if (this.Inventory.Count() > 0 && this.Inventory.Any(w => w is IWeapon))
            {
                bonusDamage = this.Inventory.First(w => w is IWeapon).UseItem(this);
            }

            lock (Battle.EnvLock)
            {
                if (!Battle.Cts.Token.IsCancellationRequested)
                {
                    this.Oponent.TakeDamage((int)(this.Damage + bonusDamage));
                    if (this.Oponent.Health <= 0 && hasTransformed)
                    {
                        BackToNormal();
                    }
                }
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }

        public void Transform(int wins)
        {
            if (wins >= SpecialSkills.Count)
            {
                wins = SpecialSkills.Count - 1;
            }
            this.Transformation = this.SpecialSkills[wins] as RobotSkills;
            currentHits = 0;
            this.Damage += Transformation.AtackBonus;
            this.Health += (sbyte)Transformation.HealthBonus;
            this.Armour += Transformation.ArmourBonus;
            this.AttackDelay -= Transformation.AtackDelayReduction;
            Battle.MessageBuffer.Enqueue($"{this.Name} has transformed into {this.Transformation.Name}");
        }

        public void BackToNormal()
        {
            this.Damage -= Transformation.AtackBonus;
            this.Health -= (sbyte)Transformation.HealthBonus;
            if (this.Health < 0)
            {
                this.Health = 1;
            }
            this.Armour -= Transformation.ArmourBonus;
            this.AttackDelay += Transformation.AtackDelayReduction;
            Battle.MessageBuffer.Enqueue($"{this.Name} has returned to his Regular form");
            currentHits = 0;
            hasTransformed = false;
        }
    }
}
