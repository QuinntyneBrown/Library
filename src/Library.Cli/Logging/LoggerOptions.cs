using System;
using System.IO;

namespace Library.Cli
{
    public class LoggerOptions
    {
        public LoggerOptions(bool enableColors, ConsoleColor errorColor, ConsoleColor warningColor, TextWriter writer)
        {
            EnableColors = enableColors;
            ErrorColor = errorColor;
            WarningColor = warningColor;
            Writer = writer;
        }

        public bool EnableColors { get; }

        public ConsoleColor ErrorColor { get; }

        public ConsoleColor WarningColor { get; }

        public TextWriter Writer { get; }
    }
}
