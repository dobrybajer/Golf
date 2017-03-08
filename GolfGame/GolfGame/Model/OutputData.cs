namespace GolfGame.Model
{
    using System;
    using System.Collections.Generic;

    internal class OutputData
    {
        public int Size;
        public int MaxX;
        public int MaxY;
        public List<Tuple<Coords, Coords>> MatchedPair;

        public OutputData()
        {
            MatchedPair = new List<Tuple<Coords, Coords>>();
            Size = 0;
            MaxX = 0;
            MaxY = 0;
        }

        public void AddMatchedPair(Coords ball, Coords ditch)
        {
            MatchedPair.Add(new Tuple<Coords, Coords>(ball, ditch));
            Size++;

            if (ball.X > MaxX)
            {
                MaxX = ball.X;
            }
            if (ditch.X > MaxX)
            {
                MaxX = ditch.X;
            }
            if (ball.Y > MaxY)
            {
                MaxY = ball.Y;
            }
            if (ditch.Y > MaxY)
            {
                MaxY = ditch.Y;
            }
        }
    }
}
