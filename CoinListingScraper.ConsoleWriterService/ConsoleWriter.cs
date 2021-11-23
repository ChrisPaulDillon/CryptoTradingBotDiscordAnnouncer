using System;

namespace CoinListingScraper.ConsoleWriterService
{
    public static class ConsoleWriter
    {
        private static ConsoleColor _defaultColour = ConsoleColor.Blue;

        public static void WriteLine(string text)
        {
            Console.ForegroundColor = _defaultColour;
            Console.WriteLine(text);
        }

        public static void WriteLineCustom(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = _defaultColour;
        }

        public static void WriteLinePositive(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = _defaultColour;
        }

        public static void WriteLineNegative(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = _defaultColour;
        }
    }
}
