namespace GolfGame
{
    internal class Program
    {
        private const string Path = @"..\..\..\InputData\test.txt";

        private static void Main()
        {
            var outputData = new OutputData();
            outputData.AddMatchedPair(new Coords(10, 20), new Coords(60, 40));
            outputData.AddMatchedPair(new Coords(50, 60), new Coords(100, 130));

            //var inputData = FileManager.ReadInput(Path);
            //FileManager.WriteOutput(outputData);
            var painter = new Painter();
            painter.DrawResult(outputData);
        }
    }
}
