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
            do
            {
                Console.Write("Please enter a symbol (BTC, ETH, EOS, XRP): ");
                string read = Console.ReadLine().ToUpperInvariant();
                if (!IsSymbolValid(read))
                {
                    continue;
                }

                return Enum.GetValues(typeof(SymbolEnum)).Cast<SymbolEnum>().First(a => a.ToString().StartsWith(read));
            } while (true);
        }

        /// <summary>Validate that the read currency symbol is valid.</summary>
        public static bool IsSymbolValid(string symbol)
        {
            return null == Enum.GetValues(typeof(CurrencyEnum)).Cast<CurrencyEnum?>().FirstOrDefault(c => c.ToString().ToUpperInvariant() == symbol.ToUpperInvariant()) ? false : true;
        }
    }
}