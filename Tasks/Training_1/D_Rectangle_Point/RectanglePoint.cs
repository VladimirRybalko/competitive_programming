using System.IO;

namespace Tasks
{
    public class RectanglePoint : CompetitiveTask
    {
        private const string Training = @"Training_1/D_Rectangle_Point/";

        public override string InputFile { get; } = Training + @"tria-pt.in";
        public override string OutputFile { get; } = Training + @"tria-pt.out";

        struct Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }
                
        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var points = reader.ReadIntArray();
            var a = new Point(points[0], points[1]);

            points = reader.ReadIntArray();
            var b = new Point(points[0], points[1]);

            points = reader.ReadIntArray();
            var c = new Point(points[0], points[1]);

            points = reader.ReadIntArray();
            var x = new Point(points[0], points[1]);

            var samePlane = StraightPlane(a, b, c) * StraightPlane(a, b, x);
            if (samePlane < 0)
            {
                writer.WriteLine("Out");
                return;
            }

            samePlane = StraightPlane(b, c, a) * StraightPlane(b, c, x);
            if (samePlane < 0)
            {
                writer.WriteLine("Out");
                return;
            }

            samePlane = StraightPlane(a, c, b) * StraightPlane(a, c, x);
            if (samePlane < 0)
            {
                writer.WriteLine("Out");
                return;
            }

            writer.WriteLine("In");
        }        


        private double StraightPlane(Point a, Point b, Point c)
        {
            return (a.Y - b.Y) * c.X + (b.X - a.X) * c.Y + (a.X * b.Y - b.X * a.Y);
        }
    }
}
