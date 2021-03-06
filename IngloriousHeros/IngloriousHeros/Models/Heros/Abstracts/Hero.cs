﻿using IngloriousHeros.Models.Contracts;
using IngloriousHeros.Core.Game;
using IngloriousHeros.Core.UI;
using IngloriousHeros.Models.Common;
using System.Collections.Generic;
using System.Linq;
using IngloriousHeros.Providers;
using System;

namespace IngloriousHeros.Models.Heros.Abstracts
{
    public abstract class Hero : IHero
    {
        public event HealthChangeEventHandler HealthChange;

        private RaceName race;
        private string name;
        private sbyte health;
        private double armour;
        private double damage;
        private int attackDelay;
        private int wins;
        private IHero oponent;
        private Location hbLocation;
        private IList<IItem> inventory;

        public Hero(string name, sbyte health, double damage, int attackDelay, Location hbLocation, IList<IItem> items)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.AttackDelay = attackDelay;
            this.HbLocation = hbLocation;
            this.Inventory = items;
        }

        public RaceName Race
        {
            get => this.race;
            set => this.race = value;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public sbyte Health
        {
            get => this.health;

            set
            {
                //ValueCheck.Positive(value, "Health can't be negative!");
                this.health = value;
            }
        }

        public double Armour
        {
            get => this.armour;

            set
            {
                //ValueCheck.Positive(value, "Armour can't be negative!");
                this.armour = value;
            }
        }

        public double Damage
        {
            get => this.damage;

            set
            {
                //ValueCheck.Positive(value, "Damage can't be negative!");
                if (value < 0)
                {
                    throw new ArgumentException("Damage can't be negative!");
                }
                this.damage = value;
            }
        }

        public int AttackDelay
        {
            get => this.attackDelay;

            set
            {
                //ValueCheck.Positive(value, "AttackDelay can't be negative!");
                if (value < 0)
                {
                    throw new ArgumentException("AttackDelay can't be negative!");
                }
                this.attackDelay = value;
            }
        }

        public int Wins
        {
            get => this.wins;

            set
            {
                //ValueCheck.Positive(value, "Wins can't be negative!");
                this.wins = value;
            }
        }

        public IHero Oponent
        {
            get => this.oponent;
            set => this.oponent = value;
        }

        public Location HbLocation
        {
            get => this.hbLocation;
            set => this.hbLocation = value;
        }

        public IList<IItem> Inventory
        {
            get => this.inventory;
            set => this.inventory = value;
        }

        public abstract void Attack();

        public virtual void TakeDamage(int damage)
        {
            // Iterate through Inventory and use items to modify damage before applying to health
            int bonusArmour = 0;

            if (Inventory.Count() > 0 && Inventory.Any(a => a is IArmour))
            {
                bonusArmour = Inventory.First(a => a is IArmour).UseItem(this);
            }
            
            if (!Battle.Cts.Token.IsCancellationRequested)
            {
                this.Health -= (sbyte)(damage * (1 - bonusArmour / 100.0));

                Battle.MessageBuffer.Enqueue($"{this.Oponent.Name} deals {(int)(damage) * (1 - bonusArmour / 100.0)} damage to {this.Name}.");// damage to {oponent.Name}.");
                Battle.MessageBuffer.PrintBuffer();

                // The line below raises the HealthChange event. The "this" parameter is the
                // derived instance of Hero that called the base.TakeDamage() method
                this.HealthChange(this);
            }
        }
    }
}
