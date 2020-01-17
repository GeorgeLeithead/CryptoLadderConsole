using CryptoLadder.Definitions;
using System;
using System.Linq;

namespace CryptoLadder.BusinessLogic
{
    /// <summary>Read from the console the currency symbol for the order.</summary>
    public static class SymbolReader
    {
        /// <summary>Get the order currency symbol.</summary>
        /// <returns>The <see cref="SymbolEnum"/></returns>
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