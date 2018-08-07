﻿using System.Collections.Generic;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Contracts;

namespace IngloriousHeros.Models.Races
{
    public abstract class Robot : IRace, IHero
    {
        private string name;
        private double health;
        private double armour;
        private double damage;
        private int attackDelay;
        private IEnumerable<IItem> inventory;
        private const RaceName race = RaceName.Robot;
        //I've added private field inventory
        public Robot(string name, double health, double damage, int attackDelay, List<IItem> items)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.AttackDelay = attackDelay;
            this.Inventory = items;
        }

        //TODO: Validate all properties
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public double Health
        {
            get => this.health;
            set => this.health = value;
        }

        public double Armour
        {
            get => this.armour;
            set => this.armour = value;
        }

        public double Damage
        {
            get => this.damage;
            set => this.damage = value;
        }

        public int AttackDelay
        {
            get => this.attackDelay;
            set => this.attackDelay = value;
        }

        public RaceName Race => race;

        public List<ISpecialSkills> SpecialSkills => throw new System.NotImplementedException();

        public IEnumerable<IItem> Inventory
        {
            get
            {
                return this.inventory;
            }
            set
            {
                this.inventory = value;
            }
        }

        public virtual void TakeDamage(int damage)
        {
            this.Health -= damage;
        }
    }
}
