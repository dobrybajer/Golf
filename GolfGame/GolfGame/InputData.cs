namespace GolfGame
{
    using System;
    using System.Collections.Generic;

    internal class InputData
    {
        public int Size;
        public List<Coords> Balls;
        public List<Coords> Ditches;

        public InputData()
        {
            Balls = new List<Coords>();
            Ditches = new List<Coords>();
        }

        public InputData(string size) : this()
        {
            if (!int.TryParse(size, out Size))
            {
                throw new ArgumentException("First line is not in correct format. It must be a non-negative number less than 62,500,000");
            }
        }
    }
}
