namespace InternetWideWorld.CryptoLadder.Shared.BusinessLogic
{
    /// <summary>Read from the console the number of rungs in the order ladder.</summary>
    public static class RungsReader
    {
        /// <summary>Validate that the read rungs is valid.</summary>
        public static bool IsRungsValid(string rungs)
        {
            bool IsInt = int.TryParse(rungs, out int result);
            if (!IsInt)
            {
                return false;
            }

            return (result < 2 || result > 100) ? false : true;
        }
    }
}