using System;
using System.Globalization;
using System.Linq;
using CryptoLadder.Definitions;

namespace CryptoLadder.BusinessLogic
{
    public static class SymbolReader
    {
        public static SymbolEnum Get()
        {
            SymbolEnum? matchingSymbol = null;

            do
            {
                Console.Write("Please enter a symbol (BTC, ETH, EOS, XRP): ");
                string read = Console.ReadLine().ToUpperInvariant();
                matchingSymbol = Enum.GetValues(typeof(SymbolEnum)).Cast<SymbolEnum?>().FirstOrDefault(a => a.ToString().StartsWith(read));
            } while (matchingSymbol == null);

            return (SymbolEnum)matchingSymbol;
        }
    }
}