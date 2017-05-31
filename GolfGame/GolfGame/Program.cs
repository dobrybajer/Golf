namespace GolfGame
{
    using DataManager;
    using Logic;

    internal class Program
    {
        private const string Path = @"..\..\..\InputData\test.txt";

        private static void Main()
        {
            //var inputData = FileManager.ReadInput(Path);
            //var algorithm = new Algorithm();

            //var outputData = algorithm.Solve(inputData);

            //FileManager.WriteOutput(outputData, true);
            //Painter.DrawResult(outputData);

            TestFileGenerator.GenerateFiles();
        }
    }
}
