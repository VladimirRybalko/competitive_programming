using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class PrimesNumber2 : CompetitiveTask
    {
        private const string Training = @"Training_2/A_PrimesNumber2/";
        public override string InputFile { get; } = Training + @"primes2.in";
        public override string OutputFile { get; } = Training + @"primes2.out";

        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            const int maxSqrtConstraint = 1000; // task constraints

            var m = reader.ReadInt();
            var n = reader.ReadInt();

            // find all primes from 1 to maximum sqrt constraint
            var primes = new List<int>();
            for (var i = 2; i < maxSqrtConstraint; i++)
                if (IsPrime(i))
                    primes.Add(i);

            // find sqrt for all numbers from m to n
            var sqrts = new int[n - m + 1];
            sqrts[0] = (int)Math.Floor(Math.Sqrt(m));
            var j = 1;
            for (var number = m + 1; number <= n; number++)
            {
                var sqr = sqrts[j - 1] + 1;
                sqrts[j] = (sqr * sqr == number) 
                    ? sqrts[j - 1] + 1
                    : sqrts[j - 1];
                j++;
            }

            // find all primes numbers from m to n
            j = 0;
            var existPrimes = false;
            for (var number = m; number <= n; number++)
            {
                var primesBeforeSqrt = primes.Where(x => x <= sqrts[j]).ToArray();

                if (IsPrime(number, primesBeforeSqrt))
                {
                    existPrimes = true;
                    writer.WriteLine(number);
                }

                j++;
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


        private static bool IsPrime(int number, int[] primes)
        {
            var i = 0;
            while (i < primes.Length)
            {
                if (number % primes[i] == 0)
                    return false;
                i++;
            }

            return true;
        }
    }
}
