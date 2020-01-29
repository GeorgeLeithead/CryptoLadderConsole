using InternetWideWorld.CryptoLadder.Shared.Definitions;
using System;
using System.Linq;

namespace InternetWideWorld.CryptoLadder.Shared.BusinessLogic
{
    /// <summary>Read from the console the currency symbol for the order.</summary>
    public static class SymbolReader
    {
        /// <summary>Validate that the read currency symbol is valid.</summary>
        public static bool IsSymbolValid(string symbol)
        {
            return null == Enum.GetValues(typeof(CurrencyEnum)).Cast<CurrencyEnum?>().FirstOrDefault(c => c.ToString().ToUpperInvariant() == symbol.ToUpperInvariant()) ? false : true;
        }
    }
}