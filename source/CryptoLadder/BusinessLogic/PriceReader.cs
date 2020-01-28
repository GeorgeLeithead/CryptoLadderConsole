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
            string message = startingPrice ? "Please enter a starting price: " : "Please enter a ending price: ";

            do
            {
                Console.Write(message);
                string read = Console.ReadLine();
                if (!IsPriceValid(read))
                {
                    continue;
                }

                return double.Parse(read, CultureInfo.InvariantCulture);
            } while(true);
        }

        /// <summary>Validate that the read price is valid</summary>
        public static bool IsPriceValid(string readPrice)
        {
            double result;
            bool IsDouble = double.TryParse(readPrice, out result);
            if (!IsDouble)
            {
                return false;
            }

            if (result < 0.0001)
            {
                return false;
            }

            return result > 1000000 ? false : true;
        }
    }
}