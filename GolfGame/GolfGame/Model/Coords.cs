namespace GolfGame.Model
{
    using System;

    internal class Coords
    {
        public int X { get; }
        public int Y { get; }
        public ElementTypeEnum Type { get; }

        public Coords(int x, int y, ElementTypeEnum type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public static Coords GetCoordFromString(string line, ElementTypeEnum type)
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

            return new Coords(x, -y, type);
        }
    }
}
