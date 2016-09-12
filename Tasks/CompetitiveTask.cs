using System.IO;

namespace Tasks
{
    public abstract class CompetitiveTask
    {
        /// <summary>
        /// Input file path
        /// </summary>
        public abstract string InputFile { get; }

        /// <summary>
        /// Output file path
        /// </summary>
        public abstract string OutputFile { get; }

        /// <summary>
        /// Resolve task
        /// </summary>
        public void Resolve()
        {
            using (var reader = new StreamReader(InputFile))
            using (var writer = new StreamWriter(OutputFile))
                Resolve(reader, writer);
        }

        protected abstract void Resolve(StreamReader reader, StreamWriter writer);
    }
}
