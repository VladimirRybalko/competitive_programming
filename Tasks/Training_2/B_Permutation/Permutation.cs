using System.IO;
using System.Linq;

namespace Tasks
{
    public class Permutation : CompetitiveTask
    {
        private const string Training = @"Training_2/B_Permutation/";
        public override string InputFile { get; } = Training + @"permut.in";
        public override string OutputFile { get; } = Training + @"permut.out";
        
        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var value = reader.ReadLine().ToArray();

            writer.WriteLine(value);
            Permut(value, 0, writer);
        }

        private void Permut(char[] value, int index, StreamWriter writer)
        {
            if (index == value.Length)
                return;

            Permut(value, index + 1, writer);

            var i = index + 1;
            while (i < value.Length)
            {
                var result = Swap(value, index, i);
                writer.WriteLine(result);
                Permut(result, index + 1, writer);
                i++;
            }            
        }

        private char[] Swap(char[] value, int i, int j)
        {
            var result = value.ToArray();

            var temp = result[i];
            result[i] = result[j];
            result[j] = temp;

            return result;
        }
    }
}
