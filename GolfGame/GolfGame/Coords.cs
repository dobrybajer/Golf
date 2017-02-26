namespace GolfGame
{
    using System;

    internal class Coords
    {
        public int X { get; }
        public int Y { get; }

        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coords GetCoordFromString(string line)
        {
            var coords = line.Split(',');
            int x, y;

            if (!int.TryParse(coords[0], out x))
            {
                throw new ArgumentException("X coordinate is not correct number. It must be a non-negative number less than 2^32.");
            }

            if (!int.TryParse(coords[1], out y))
            {
                throw new ArgumentException("Y coordinate is not correct number. It must be a non-negative number less than 2^32.");
            }

            return new Coords(x, y);
        }
    }
}
