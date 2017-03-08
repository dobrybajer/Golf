namespace GolfGame.Logic
{
    using System.Collections.Generic;
    using System.Linq;

    using Model;

    internal class Algorithm
    {
        public OutputData Solve(InputData data)
        {
            var outputData = new OutputData();

            var elements = new List<Coords>();
            elements.AddRange(data.Balls);
            elements.AddRange(data.Ditches);

            FindMatchingPair(elements, outputData);

            return outputData;
        }

        private static void FindMatchingPair(ICollection<Coords> elements, OutputData outputData)
        {
            if (!elements.Any())
            {
                return;
            }

            var leftElement = elements.Aggregate((curMin, x) => curMin == null || x.X < curMin.X ? x : curMin);
            elements.Remove(leftElement);

            var segments = elements.Select(el => new Segment(leftElement, el)).OrderBy(s => s.DirectionalFactor).ToList();

            var leftElements = new List<Coords>();
            var rightElements = new List<Coords>();

            var counter = leftElement.Type;

            foreach (var s in segments)
            {
                elements.Remove(s.EndPoints.Item2);

                counter += (int)s.EndPoints.Item2.Type;

                if (counter == 0)
                {
                    outputData.AddMatchedPair(leftElement, s.EndPoints.Item2);
                    leftElements.AddRange(elements);

                    break;
                }

                rightElements.Add(s.EndPoints.Item2);
            }

            FindMatchingPair(leftElements, outputData);
            FindMatchingPair(rightElements, outputData);
        }
    }
}
