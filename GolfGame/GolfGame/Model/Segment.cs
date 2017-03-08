namespace GolfGame.Model
{
    using System;

    internal class Segment
    {
        public Tuple<Coords, Coords> EndPoints;
        public double DirectionalFactor;

        public Segment(Coords el1, Coords el2)
        {
            EndPoints = new Tuple<Coords, Coords>(el1, el2);
            DirectionalFactor = (double)(el2.Y - el1.Y)/(el2.X - el1.X);
        }
    }
}
