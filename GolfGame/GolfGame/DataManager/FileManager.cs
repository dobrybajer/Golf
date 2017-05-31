namespace GolfGame.DataManager
{
    using System;
    using System.IO;
    using System.Linq;

    using Model;

    internal static class FileManager
    {
        public static InputData ReadInput(string path)
        {
            InputData input;

            var lines = File.ReadLines(path).ToArray();

            try
            {
                input = new InputData(lines[0]);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            if (lines.Length != 2*input.Size + 1)
            {
                throw new ArgumentException("Number of lines is incorrect.");
            }

            for (var i = 1; i <= input.Size; i++)
            {
                var line = lines[i];
                var coords = Coords.GetCoordFromString(line, ElementTypeEnum.Ball);

                input.Balls.Add(coords);
            }

            for (var i = input.Size + 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var coords = Coords.GetCoordFromString(line, ElementTypeEnum.Ditch);

                input.Ditches.Add(coords);
            }

            return input;
        }

        public static void WriteOutput(OutputData data, string fileInfoWithExt, bool writeToConsole = false)
        {
            var result = data.MatchedPair.Aggregate("", (current, pair) => current + $"{pair.Item1.X},{-pair.Item1.Y}-{pair.Item2.X},{-pair.Item2.Y}" + Environment.NewLine);

            if (writeToConsole)
            {
                Console.WriteLine(result);
            }

            var path = $"..\\..\\..\\OutputData\\{DateTime.Now.ToString("yyyyMMdd-HHmmss")}_{fileInfoWithExt}";
            
            File.WriteAllText(path, result);
        }

        public static void WriteOutputComputationTime(string output, int filesCount)
        {
            var path = $"..\\..\\..\\OutputData\\{DateTime.Now.ToString("yyyyMMdd-HHmmss")}_computationTime_files{filesCount}.txt";

            File.WriteAllText(path, output);
        }
    }
}
