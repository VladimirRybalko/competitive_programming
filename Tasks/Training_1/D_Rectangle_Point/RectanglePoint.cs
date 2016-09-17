using System.IO;
using System.Linq;

namespace Tasks
{
    public class Expression : CompetitiveTask
    {
        private const string Training = @"Training_1/D_Rectangle_Point/";

        public override string InputFile { get; } = Training + @"tria-pt.in";
        public override string OutputFile { get; } = Training + @"tria-pt.out";
		               
        protected override void Resolve(StreamReader reader, StreamWriter writer)
        {
        }        
    }
}
