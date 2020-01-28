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
            do
            {
                Console.Write("Please enter the TOTAL unit quantity: ");
                string read = Console.ReadLine();
                if (!IsQuantityValid(read, rungs))
                {
                    continue;
                }

                return int.Parse(read, CultureInfo.InvariantCulture);
            } while (true);
        }

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