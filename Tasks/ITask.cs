namespace Tasks
{
    /// <summary>
    /// Define a common contract for all competitive programming task
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// Input file path
        /// </summary>
        string InputFile { get; }

        /// <summary>
        /// Output file path
        /// </summary>
        string OutputFile { get; }

        /// <summary>
        /// Resolve task
        /// </summary>
        void Resolve();
    }
}
