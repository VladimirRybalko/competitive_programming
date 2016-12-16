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
            var matrix = new int[n + 2, n + 2];
            int i,j;

            // fill matrix with barrier
            for (i = 0; i < n + 2; i++)
            {
                matrix[i, 0] =
                    matrix[i, n + 1] =
                    matrix[n + 1, i] =
                    matrix[0, i] = 1;
            }
            
            // fill in a spiral
            i = 1;
            j = 1;            
            // bypass directions.
            var directions = new int[4, 2] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
            var dirIndex = 1;
            var di = directions[0, 0];
            var dj = directions[0, 1];
            var number = 1;

            while (number <= n * n)
            {
                matrix[i, j] = number;

                if (matrix[i + di, j + dj] != 0)
                {
                    di = directions[dirIndex, 0];
                    dj = directions[dirIndex, 1];
                    dirIndex = dirIndex + 1 == 4 ? 0 : dirIndex + 1;
                }
                                
                i += di;
                j += dj;
                number++;
            }

            
            // write result
            for (i = 1; i < n + 1; i++)
            {
                for (j = 1; j < n + 1; j++)
                    writer.Write(matrix[i, j] + " ");
                writer.WriteLine();
            }
        }
    }
}
