using System;
using System.Collections.Generic;

namespace _05.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char currentSymbol = text[i];
                if (!symbols.ContainsKey(currentSymbol))
                {
                    symbols.Add(currentSymbol, 0);
                }
                symbols[currentSymbol]++;
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine("{0}: {1} time/s", symbol.Key, symbol.Value);
            }
        }
    }
}
