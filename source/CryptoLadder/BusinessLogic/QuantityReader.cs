using System;
using System.Globalization;

namespace CryptoLadder.BusinessLogic
{
    /// <summary>Read from the console the quantity for the ladder.</summary>
    public static class QuantityReader
    {
        /// <summary>Get the total unit quantity for the order.</summary>
        /// <param name="rungs">The number of rungs in the ladder.</param>
        /// <returns>Order quantity.</returns>
        public static int Get(int rungs)
        {
            int? matchingTotalQuantity = null;

            do
            {
                Console.Write("Please enter the TOTAL unit quantity: ");
                string read = Console.ReadLine();
                try {
                    matchingTotalQuantity = int.Parse(read, CultureInfo.InvariantCulture);
                    if (matchingTotalQuantity < rungs)
                    {
                        matchingTotalQuantity = null;
                    }
                }
                catch {}
            } while (matchingTotalQuantity == null);

            return (int)matchingTotalQuantity;
        }
    }
}