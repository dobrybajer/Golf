namespace GolfGame.DataManager
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Model;

    internal static class TestFileGenerator
    {
        public static void GenerateFiles()
        {
            Console.WriteLine("Generating files for size 10");
            GenerateFiles(10, 10, 5);
            GenerateFiles(10, 50, 5);
            GenerateFiles(10, 100, 5);
            GenerateFiles(10, 200, 5);

            Console.WriteLine("Generating files for size 20");
            GenerateFiles(20, 10, 5);
            GenerateFiles(20, 50, 5);
            GenerateFiles(20, 100, 5);
            GenerateFiles(20, 200, 5);

            Console.WriteLine("Generating files for size 50");
            GenerateFiles(50, 50, 5);
            GenerateFiles(50, 100, 5);
            GenerateFiles(50, 200, 5);
            GenerateFiles(50, 500, 5);

            Console.WriteLine("Generating files for size 100");
            GenerateFiles(100, 50, 5);
            GenerateFiles(100, 100, 5);
            GenerateFiles(100, 200, 5);
            GenerateFiles(100, 500, 5);

            Console.WriteLine("Generating files for size 200");
            GenerateFiles(200, 100, 5);
            GenerateFiles(200, 200, 5);
            GenerateFiles(200, 500, 5);
            GenerateFiles(200, 1000, 5);

            Console.WriteLine("Generating files for size 500");
            GenerateFiles(500, 200, 5);
            GenerateFiles(500, 500, 5);
            GenerateFiles(500, 1000, 5);
            GenerateFiles(500, 2000, 5);
        }

        public static void GenerateFiles(int size, int maxCoordValue, int numberOfDifferentFiles)
        {
            for (var i = 1; i <= numberOfDifferentFiles; i++)
            {
                GenerateFile(size, maxCoordValue, i);
                Console.WriteLine($"Generated {i}/{numberOfDifferentFiles} files.");
            }
        }

        public static void GenerateFile(int size, int maxCoordValue, int iteration)
        {
            if (size < 0 || size > Math.Pow(10, 7))
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            var output = size.ToString();

            var pointList = new List<Coords>();

            var rand = new Random(Guid.NewGuid().GetHashCode());

            while (pointList.Count < 2*size)
            {
                var x = rand.Next(0, maxCoordValue);
                var y = rand.Next(0, maxCoordValue);
                var p3 = new Coords(x, y, ElementTypeEnum.Ball);

                var isPointCollinear = false;
                for (var i = 0; i < pointList.Count; i++)
                {
                    var p1 = pointList[i];

                    if (p3.X == p1.X && p3.Y == p1.Y)
                    {
                        continue;
                    }

                    for (var j = i + 1; j < pointList.Count; j++)
                    {
                        var p2 = pointList[j];
                        isPointCollinear = CheckIfPointsAreCollinear(p1, p2, p3);
                    }
                }
                if (!isPointCollinear)
                {
                    pointList.Add(p3);
                }
            }

            output = pointList.Aggregate(output, (current, point) => current + (Environment.NewLine + point.X + "," + point.Y));

            var path = $"..\\..\\..\\TestData\\Test_size{size}_maxCoord{maxCoordValue}_nr{iteration}.txt";
            File.WriteAllText(path, output);
        }

        private static bool CheckIfPointsAreCollinear(Coords p1, Coords p2, Coords p3)
        {
            return (p2.Y - p1.Y)*(p3.X - p2.X) == (p3.Y - p2.Y)*(p2.X - p1.X);
        }
    }
}
