using System.IO;

namespace Tasks
{
    public class IncreasingSubsequence : CompetitiveTask
    {
        private const string Training = @"Training_1/C_Increasing_Subsequence/";

        public override string InputFile { get; } = Training + @"inseq.in";
        public override string OutputFile { get; } = Training + @"inseq.out";
                                
        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var n = reader.ReadInt();
            var x = reader.ReadLongArray();
            var seqSize = new int[n];
            int max, j;

            // define all increasing subsequence size
            var i = 0;
            while (i < n)
            {
                max = 0;
                j = 0;
                while (j < i)
                {
                    if (seqSize[j] > max && x[j] < x[i])
                        max = seqSize[j];

                    j++;
                }

                seqSize[i] = max + 1;
                i++;
            }

            // find max subsequence
            max = seqSize[0];
            var maxIndex = 0;
            i = 1;
            while (i < n)
            {
                if (seqSize[i] > max)
                {
                    max = seqSize[i];
                    maxIndex = i;
                }
                i++;
            }

            // write length of max subsequence
            writer.WriteLine(max);

            // invert subsequence for correct output
            var sequence = new long[max];
            sequence[0] = x[maxIndex];
            i = maxIndex - 1;
            var index = maxIndex; 
            j = 1; // currenct sequence index
                        
            while(i >= 0)
            {
                if (x[i] < x[index] && seqSize[i] + 1 == seqSize[index])
                {
                    sequence[j] = x[i];
                    index = i;
                    j++;
                }

                i--;
            }

            for (i = max - 1; i >= 0; i--)
                writer.Write(sequence[i] + " ");                
        }        
    }
}
