using System.IO;

namespace Tasks
{
    public class Spiral : CompetitiveTask
    {
        private const string Training = @"Training_2/F_Spiral/";
        public override string InputFile { get; } = Training + @"spiral.in";
        public override string OutputFile { get; } = Training + @"spiral.out";

        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var n = reader.ReadInt();
            var spiral = new int[n, n];

            for (var i = 0; i < n; i++)
            {
                var array = reader.ReadIntArray();
                for (var j = 0; j < n; j++)
                    spiral[i, j] = array[j];
            }

            // NOT RESOLVED
        }
    }
}
