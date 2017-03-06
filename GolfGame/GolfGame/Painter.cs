namespace GolfGame
{
    using System;

    using NGraphics;

    internal class Painter
    {
        private const int FrameSize = 10;

        public void DrawResult(OutputData data)
        {
            if (data.MaxX > 5000 || data.MaxY > 5000)
            {
                return;
            }

            var canvas = Platforms.Current.CreateImageCanvas(new Size(data.MaxX + FrameSize*2, data.MaxY + FrameSize*2));

            canvas.FillRectangle(new Rect(canvas.Size), Colors.White);

            foreach (var pair in data.MatchedPair)
            {
                var ellipse1 =
                    new Ellipse(new Rect(new Point(pair.Item1.X + FrameSize, pair.Item1.Y + FrameSize), new Size(1)), new Pen(Colors.Black), Brushes.Black);
                var ellipse2 =
                    new Ellipse(new Rect(new Point(pair.Item2.X + FrameSize, pair.Item2.Y + FrameSize), new Size(1)), new Pen(Colors.Green), Brushes.Green);

                var p = new Path();
                p.MoveTo(pair.Item1.X + FrameSize, pair.Item1.Y + FrameSize);
                p.LineTo(pair.Item2.X + FrameSize, pair.Item2.Y + FrameSize);

                p.Pen = new Pen(Colors.Red);
                p.Draw(canvas);

                ellipse1.Draw(canvas);
                ellipse2.Draw(canvas);
            }

            for (var i = 0; i < data.MaxX + FrameSize*2; i += FrameSize)
            {
                var p = new Path();
           
                p.MoveTo(i, 0);
                p.LineTo(i, data.MaxY + FrameSize * 2);

                p.Pen = new Pen(Colors.LightGray, 0.5);
                p.Draw(canvas);
            }

            for (var i = 0; i < data.MaxY + FrameSize*2; i += FrameSize)
            {
                var p = new Path();
                p.MoveTo(0, i);
                p.LineTo(data.MaxX + FrameSize * 2, i);

                p.Pen = new Pen(Colors.LightGray, 0.5);
                p.Draw(canvas);
            }

            var path = $"..\\..\\..\\OutputData\\{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{data.Size}.png";

            canvas.GetImage().SaveAsPng(path);
        }
    }
}
