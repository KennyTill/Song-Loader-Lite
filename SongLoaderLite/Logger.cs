using System;
namespace SongLoaderLite
{
    /// <summary>
    /// Logger class for sending out messages to the --verbose console during the main application runtime
    /// </summary>
    static class Logger
    {
        /// <summary>
        /// Basic static logging function, can be called from anywhere in code
        /// </summary>
        /// <param name="severity">Level of severity for display</param>
        /// <param name="message">Message to be displayed in the log line</param>
        public static void Log(Severity severity, string message)
        {
            Console.WriteLine("[Song Loader Lite][" + severity.ToString() + "] " + message);

        }

        public enum Severity
        {
            Debug,
            Info,
            Warn,
            Error,
            Critical
        }
    }
}
