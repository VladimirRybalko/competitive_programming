using System;
using System.IO;

namespace Tasks
{
    public class PrimesNumber2 : CompetitiveTask
    {
        private const string Training = @"Training_2/A_PrimesNumber2/";
        public override string InputFile { get; } = Training + @"primes2.in";
        public override string OutputFile { get; } = Training + @"primes2.out";

        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            //var m = reader.ReadInt();
            //var n = reader.ReadInt();

            //var existPrimes = false;
            //for (var i = m; i <= n; i++)
            //{
            //    if (IsPrime(i))
            //    {
            //        existPrimes = true;
            //        writer.Write(i + " ");
            //    }
            //}

            //if (!existPrimes)
            //    writer.Write("Absent");

        }

        // Detect all prime numbers from statement range
        //private static int[] DetectAllPrimeNumbers()
        //{


        //}
        
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
