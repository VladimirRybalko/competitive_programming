using System;
using System.IO;

namespace Tasks
{
    public class PrimesNumber : CompetitiveTask
    {
        private const string Training = @"Training_1/A_PrimesNumber/";
        public override string InputFile { get; } = Training + @"primes.in";
        public override string OutputFile { get; } = Training + @"primes.out";

        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            var spliting = reader.ReadLine().Split(' ');
            var m = spliting[0].ToInt();
            var n = spliting[1].ToInt();
            
            var existPrimes = false;
            for (var i = m; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    existPrimes = true;
                    writer.Write(i + " ");
                }
            }

            if (!existPrimes)
                writer.Write("Absent");

        }

        private static bool IsPrime(int number)
        {
            var i = 2;
            while (i <= Math.Sqrt(number))
            {
                if (number % i == 0)
                    return false;
                i++;
            }

            return true;
        }
    }
}
