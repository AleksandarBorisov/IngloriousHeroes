using System;

namespace IngloriousHeros.Core.Utilities
{
    public class Randomizer : IRandomizer
    {
        private Random randomzer;

        public Randomizer()
        {
            this.randomzer = new Random(Guid.NewGuid().GetHashCode());
        }

        public int Next(int minValue, int maxValue)
        {
            return this.randomzer.Next(minValue, maxValue);
        }
    }
}
