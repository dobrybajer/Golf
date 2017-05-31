namespace GolfGame
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    
    using DataManager;
    using Logic;
    using Model;

    internal class Program
    {
        private const string Path = @"..\..\..\InputData\";

        private static void Main()
        {
            //TestFileGenerator.GenerateFiles();

            var algorithm = new Algorithm();
            var computationTime = "";

            var testFiles = Directory.GetFiles(Path, "*.txt", SearchOption.AllDirectories);
            foreach (var file in testFiles)
            {
                var fileInfoWithExt = file.Split('\\').Last();

                var inputData = FileManager.ReadInput(file);
                OutputData outputData = null;

                var time = MeasureActionTime(() =>
                {
                    outputData = algorithm.Solve(inputData);
                });

                computationTime += file + ": " + time + " (" + time.TotalMilliseconds + "ms)" + Environment.NewLine;

                FileManager.WriteOutput(outputData, fileInfoWithExt, false);
                Painter.DrawResult(outputData, fileInfoWithExt);
            }

            FileManager.WriteOutputComputationTime(computationTime, testFiles.Length);
        }

        public static TimeSpan MeasureActionTime(Action action)
        {
            var stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}
