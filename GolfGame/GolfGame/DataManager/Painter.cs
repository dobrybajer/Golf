namespace GolfGame.DataManager
{
    using System;

    using NGraphics;

    using Model;
    
    internal static class Painter
    {
        private const int FrameSize = 10;
        private const int Scale = 1;
        private const double ElementSize = 1;

        public static void DrawResult(OutputData data)
        {
            if (data.MaxX > 5000 || data.MaxY > 5000)
            {
                return;
            }

            var canvas = Platforms.Current.CreateImageCanvas(new Size((data.MaxX + FrameSize*2)*Scale, (data.MaxY + FrameSize*2)*Scale), 20);

            canvas.FillRectangle(new Rect(canvas.Size), Colors.White);


            for (var i = 0; i < (data.MaxX + FrameSize * 2) * Scale; i += FrameSize)
            {
                var p = new Path();

                p.MoveTo(i + ElementSize / 2, 0 + ElementSize / 2);
                p.LineTo(i + ElementSize / 2, (data.MaxY + FrameSize * 2) * Scale + ElementSize / 2);

                p.Pen = new Pen(Colors.LightGray, ElementSize / 2);
                p.Draw(canvas);
            }

            for (var i = 0; i < (data.MaxY + FrameSize * 2) * Scale; i += FrameSize)
            {
                var p = new Path();
                p.MoveTo(0 + ElementSize / 2, i + ElementSize / 2);
                p.LineTo((data.MaxX + FrameSize * 2) * Scale + ElementSize / 2, i + ElementSize / 2);

                p.Pen = new Pen(Colors.LightGray, ElementSize / 2);
                p.Draw(canvas);
            }

            foreach (var pair in data.MatchedPair)
            {
                var ellipse1 =
                    new Ellipse(new Rect(new Point((pair.Item1.X + FrameSize)*Scale, (pair.Item1.Y + FrameSize)*Scale), new Size(ElementSize)), new Pen(Colors.Black), Brushes.Black);
                var ellipse2 =
                    new Ellipse(new Rect(new Point((pair.Item2.X + FrameSize)*Scale, (pair.Item2.Y + FrameSize)*Scale), new Size(ElementSize)), new Pen(Colors.Green), Brushes.Green);

                var p = new Path();
                p.MoveTo((pair.Item1.X + FrameSize)*Scale + ElementSize / 2, (pair.Item1.Y + FrameSize)*Scale + ElementSize / 2);
                p.LineTo((pair.Item2.X + FrameSize)*Scale + ElementSize / 2, (pair.Item2.Y + FrameSize)*Scale + ElementSize / 2);

                p.Pen = new Pen(Colors.Red, ElementSize);
                p.Draw(canvas);

                ellipse1.Draw(canvas);
                ellipse2.Draw(canvas);
            }

            var path = $"..\\..\\..\\OutputData\\{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{data.Size}.png";

            canvas.GetImage().SaveAsPng(path);
        }
    }
}
