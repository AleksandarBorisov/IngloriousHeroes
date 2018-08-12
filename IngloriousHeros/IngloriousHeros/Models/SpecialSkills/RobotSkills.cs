using System;
using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Models.SpecialSkills
{
    public class RobotSkills : ISpecialSkills
    {
        private string name;

        private double atackBonus;

        private int atackDelayReduction;

        private double armourBonus;

        private double healthBonus;

        public RobotSkills(string nameTransformation, double atackBonus, int atackDelayReduction, double armourBonus, double healthBonus)
        {
            this.Name = nameTransformation;
            this.AtackBonus = atackBonus;
            this.AtackDelayReduction = atackDelayReduction;
            this.ArmourBonus = armourBonus;
            this.HealthBonus = healthBonus;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
            }
        }

        public double AtackBonus
        {
            get { return this.atackBonus; }
            set
            {
                this.atackBonus = value;
            }
        }

        public int AtackDelayReduction
        {
            get { return this.atackDelayReduction; }
            set
            {
                this.atackDelayReduction = value;
            }
        }

        public double ArmourBonus
        {
            get { return this.armourBonus; }
            set
            {
                this.armourBonus = value;
            }
        }

        public double HealthBonus
        {
            get { return this.healthBonus; }
            set
            {
                this.healthBonus = value;
            }
        }
    }
}
