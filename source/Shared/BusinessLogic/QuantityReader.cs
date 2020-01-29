namespace InternetWideWorld.CryptoLadder.Shared.BusinessLogic
{
    /// <summary>Read from the console the quantity for the ladder.</summary>
    public static class QuantityReader
    {
        /// <summary>Validate that the read quantity is valid.</summary>
        public static bool IsQuantityValid(string readQuantity, int rungs)
        {
            int result;
            bool IsInt = int.TryParse(readQuantity, out result);
            if (!IsInt)
            {
                return false;
            }

            if (result < 1 || result > 100000000)
            {
                return false;
            }

            return result < rungs ? false : true;
        }
    }
}