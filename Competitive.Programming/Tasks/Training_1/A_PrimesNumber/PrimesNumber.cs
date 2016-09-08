using System;
using System.IO;

namespace Tasks.Training_1
{
    public class PrimesNumber
    {
        private const string InputFile = @"primes.in";
        private const string OutputFile = @"primes.out";

        public void Resolve()
        {
            var input = File.ReadAllLines(InputFile);
            var spliting = input[0].Split(' ');
            var m = int.Parse(spliting[0]);
            var n = int.Parse(spliting[1]);

            using (var writer = new StreamWriter(OutputFile))
            {
                var existPrimes = false;
                for (var i = m; i <= n; i++)
                {
                    if (IsPrime(i))
                    {
                        existPrimes = true;
                        writer.Write(i);
                    }                       
                }

                if (!existPrimes)
                    writer.Write("Absent");                
            }
        }

        private bool IsPrime(int number)
        {
            var i = 2;
            while(i <= Math.Sqrt(number))
            {
                if (number % i == 0)
                    return true;
                i++;
            }

            return false;
        }
    }
}
