namespace GolfGame
{
    using System;
    using System.Collections.Generic;

    internal class OutputData
    {
        public int Size;
        public List<Tuple<Coords,Coords>> MatchedPair;

        public OutputData()
        {
            MatchedPair = new List<Tuple<Coords, Coords>>();
            Size = 0;
        }

        public void AddMatchedPair(Coords ball, Coords ditch)
        {
            MatchedPair.Add(new Tuple<Coords, Coords>(ball, ditch));
            Size++;
        }
    }
}
