using System;
using System.Globalization;

namespace CryptoLadder.BusinessLogic
{
    /// <summary>Read from the console the starting or ending price for the ladder.</summary>
    public static class PriceReader
    {
        /// <summary>Get the price.</summary>
        /// <param name="startingPrice"></param>
        /// <returns>The price.</returns>
        public static double Get(bool startingPrice)
        {
            double? matchingPrice = null;
            string message = startingPrice ? "Please enter a starting price: " : "Please enter a ending price: ";

            do
            {
                Console.Write(message);
                string read = Console.ReadLine();
                try
                {
                    matchingPrice = double.Parse(read, CultureInfo.InvariantCulture);
                }
                catch { }
            } while (matchingPrice == null);

            return (double)matchingPrice;
        }
    }
}