using System;
using IngloriousHeros.Models.Common;
using IngloriousHeros.Models.Contracts;

namespace IngloriousHeros.Models.SpecialSkills
{
    public class FantasoidSkill : ISpecialSkills
    {
        // The specctial skills of Fantasoids are spells
        private string name;
        private int value;
        private int manaRequirement;
        private SpellType type;
        

        public FantasoidSkill(string name, int value, int manaRequirement, SpellType type)
        {
            this.Name = name;
            this.Value = value;
            this.ManaRequirement = manaRequirement;
            this.Type = type;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Value
        {
            get => this.value;
            set => this.value = value;
        }

        public SpellType Type
        {
            get => this.type;
            set => this.type = value;
        }

        public int ManaRequirement
        {
            get => this.manaRequirement;
            set => this.manaRequirement = value;
        }
    }
}
