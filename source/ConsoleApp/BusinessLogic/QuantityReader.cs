using System;
using System.Globalization;

namespace InternetWideWorld.CryptoLadder.ConsoleApp.BusinessLogic
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
                if (!Shared.BusinessLogic.QuantityReader.IsQuantityValid(read, rungs))
                {
                    continue;
                }

                return int.Parse(read, CultureInfo.InvariantCulture);
            } while (true);
        }
    }
}