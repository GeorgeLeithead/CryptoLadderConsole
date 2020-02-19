namespace InternetWideWorld.CryptoLadder.Shared.BusinessLogic
{
    /// <summary>Read from the console the quantity for the ladder.</summary>
    public static class QuantityReader
    {
        /// <summary>Validate that the read quantity is valid.</summary>
        public static bool IsQuantityValid(string readQuantity, int rungs)
        {
            bool IsInt = int.TryParse(readQuantity, out int result);
            return !IsInt || result < 1 || result > 100000000 ? false : result < rungs ? false : true;
        }
    }
}