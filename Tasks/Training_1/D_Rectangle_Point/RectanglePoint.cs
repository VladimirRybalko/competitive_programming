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

                        
        }        
    }
}
