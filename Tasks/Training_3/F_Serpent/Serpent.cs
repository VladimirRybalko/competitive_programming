using System.IO;

namespace Tasks
{
    public class Serpent : CompetitiveTask
    {
        private const string Training = @"Training_3/F_Serpent/";
        public override string InputFile { get; } = Training + @"serpent.in";
        public override string OutputFile { get; } = Training + @"serpent.out";

        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var n = reader.ReadInt();

            var result = new int[n, n];
            var counter = 1;

            for (var c = 0; c < 2*n; c++)
            {
                if (c % 2 == 0)
                {
                    var i = n - 1;
                    while (i >= 0)
                    {
                        var j = c - i;
                        if (0 <= j && j < n)
                            result[i, j] = counter++;
                        i--;
                    }
                }
                else
                {
                    var i = 0;
                    while (i < n)
                    {
                        var j = c - i;
                        if (0 <= j && j < n)
                            result[i, j] = counter++;
                        i++;
                    }
                }
            }

            // write result
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                    writer.Write(result[i,j] + " ");

                writer.WriteLine();
            }
            

        }
    }
}
