using System.IO;
using System.Linq;

namespace Tasks
{
    public class Expression : CompetitiveTask
    {
        private const string Training = @"Training_1/B_Expression/";

        public override string InputFile { get; } = Training + @"expr.in";
        public override string OutputFile { get; } = Training + @"expr.out";

        int[] x;
        char[] signs;
        int n;
        long S;
        
        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var line1 = reader.ReadLine().Split(' ');
            n = line1[0].ToInt();
            S = line1[1].ToInt();

            var line2 = reader.ReadLine();
            x = line2.Split(' ').Select(x => x.ToInt()).ToArray();
            signs = new char[n];
            
            var result = Traverse(0, x[0], '+');

            if (!result)
                writer.Write("No solution");
            else
            {
                writer.Write(x[0]);
                for (int i = 1; i < n; i++)
                {
                    writer.Write(signs[i]);
                    writer.Write(x[i]);
                }

                writer.Write("=" + S);
            }
        }

        private bool Traverse(int i, long sum, char sign)
        {
            signs[i] = sign;

            if (i == n - 1)
                return S == sum;

            i++;
            return Traverse(i, sum + x[i], '+') || Traverse(i, sum - x[i], '-');
        }
    }
}
