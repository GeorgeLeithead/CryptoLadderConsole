namespace InternetWideWorld.CryptoLadder.Shared.BusinessLogic
{
    /// <summary>Read from the console the number of rungs in the order ladder.</summary>
    public static class RungsReader
    {
        /// <summary>Validate that the read rungs is valid.</summary>
        public static bool IsRungsValid(string rungs)
        {
            int result;
            bool IsInt = int.TryParse(rungs, out result);
            if (!IsInt)
            {
                return false;
            }

            return (result < 3 || result > 99) ? false : true;
        }
    }
}