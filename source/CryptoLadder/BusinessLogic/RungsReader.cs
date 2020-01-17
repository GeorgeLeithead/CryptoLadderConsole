using System;
using System.Globalization;

namespace CryptoLadder.BusinessLogic
{
    /// <summary>Read from the console the number of rungs in the order ladder.</summary>
    public static class RungsReader
    {
        /// <summary>Get the number of rungs.</summary>
        /// <returns>The number of ladder rungs.</returns>
        public static int Get()
        {
            int? matchingRungs = null;

            do
            {
                Console.Write("Please enter the number of rungs (> 2 and < 100): ");
                string read = Console.ReadLine();
                try
                {
                    matchingRungs = int.Parse(read, CultureInfo.InvariantCulture);
                    if (matchingRungs < 3 || matchingRungs > 99)
                    {
                        matchingRungs = null;
                    }
                }
                catch { }
            } while (matchingRungs == null);

            return (int)matchingRungs;
        }
    }
}