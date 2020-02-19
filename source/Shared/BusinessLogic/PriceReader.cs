namespace InternetWideWorld.CryptoLadder.Shared.BusinessLogic
{
    /// <summary>Read from the console the starting or ending price for the ladder.</summary>
    public static class PriceReader
    {
        /// <summary>Validate that the read price is valid</summary>
        public static bool IsPriceValid(string readPrice)
        {
            bool IsDouble = double.TryParse(readPrice, out double result);
            return !IsDouble || result < 0.0001 ? false : result > 1000000 ? false : true;
        }
    }
}