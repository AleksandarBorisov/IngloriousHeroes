using System;

namespace IngloriousHeros.Models.Common
{
    public struct Location
    {
        private int row;
        private int col;

        public Location(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get => this.row;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Row cannot be negative.");
                }

                this.row = value;
            }
        }

        public int Col
        {
            get => this.col;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Column cannot be negative.");
                }

                this.col = value;
            }
        }
    }
}
