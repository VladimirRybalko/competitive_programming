using System.IO;
using System.Linq;

namespace Tasks
{
    public class Poker : CompetitiveTask
    {
        private const string Training = @"Training_1/F_Poker/";

        public override string InputFile { get; } = Training + @"poker.in";
        public override string OutputFile { get; } = Training + @"poker.out";
                                
        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
            const int maxCard = 13; // constraint from task statement
            var cards = reader.ReadIntArray();
            var frequency = Enumerable.Repeat(0, maxCard + 1).ToArray();
            var combo = Enumerable.Repeat(0, maxCard + 1).ToArray();

            foreach (var card in cards)
                frequency[card]++;
            
            foreach (var f in frequency)
                combo[f]++;

            if (combo[5] == 1)
                writer.Write("Impossible");
            else if (combo[4] == 1)
                writer.Write("Four of a kind");
            else if (combo[3] == 1 && combo[2] == 1)
                writer.Write("Full house");
            else if (combo[3] == 1)
                writer.Write("Three of kind");
            else if (combo[2] == 2)
                writer.Write("Two pairs");
            else if (combo[2] == 1)
                writer.Write("One pair");
            else if (ContainsSequence(frequency))
                writer.Write("Straight");
            else
                writer.Write("Nothing");
        }     
        
        private static bool ContainsSequence(int[] array)
        {
            return array.SkipWhile(x => x == 0).TakeWhile(x => x != 0).Count() == 5;
        }  
    }
}
