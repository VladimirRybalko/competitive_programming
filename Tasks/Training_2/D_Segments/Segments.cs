using System.IO;

namespace Tasks
{
    public class Segments : CompetitiveTask
    {
        private const string Training = @"Training_2/D_Segments/";
        public override string InputFile { get; } = Training + @"segments.in";
        public override string OutputFile { get; } = Training + @"segments.out";

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
            // (a1,a2), (b1, b2) - two segments
            var points = reader.ReadIntArray();
            var a1 = new Point(points[0], points[1]);
            
            points = reader.ReadIntArray();
            var a2 = new Point(points[0], points[1]);

            points = reader.ReadIntArray();
            var b1 = new Point(points[0], points[1]);

            points = reader.ReadIntArray();
            var b2 = new Point(points[0], points[1]);

            var checkB1 = StraightPlane(a1, a2, b1);
            var checkB2 = StraightPlane(a1, a2, b2);
            var checkA1 = StraightPlane(b1, b2, a1);
            var checkA2 = StraightPlane(b1, b2, a2);
            
            var planeSegment1 = checkB1 * checkB2;
            var planeSegment2 = checkA1 * checkA2;

            if (planeSegment1 == 0 && planeSegment2 == 0) // segments are collinear or one of the ends of segment belongs to another segments 
            {
                var intersected = (checkB1 != 0 || checkB2 != 0) // one of the ends of segment belongs to another segments 
                    ? true
                    : ((a1.X <= b1.X && b1.X <= a2.X) || (b1.X <= a1.X && a1.X <= b2.X))
                        && ((a1.Y <= b1.Y && b1.Y <= a2.Y) || (b1.Y <= a1.Y && a1.Y <= b2.Y));

                writer.Write(intersected ? "Yes" : "No");
            }
            else if (planeSegment1 >= 0 && planeSegment2 >= 0) // segments are not intersected
            {
                writer.Write("No");
            }
            else // segments are intersected
            {
                writer.Write("Yes");
            }
        }

        private double StraightPlane(Point a, Point b, Point c)
        {
            return (a.Y - b.Y) * c.X + (b.X - a.X) * c.Y + (a.X * b.Y - b.X * a.Y);
        }
    }
}
