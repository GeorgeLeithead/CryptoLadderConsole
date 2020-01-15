using System;
using System.Globalization;

namespace CryptoLadder.BusinessLogic
{
    public static class PriceReader
    {
        public static double Get(bool startingPrice)
        {
            double? matchingPrice = null;
            string message = startingPrice ? "Please enter a starting price: " : "Please enter a ending price: ";

            do
            {
                Console.Write(message);
                var read = Console.ReadLine();
                try {
                    matchingPrice = double.Parse(read, CultureInfo.InvariantCulture);
                }
                catch {}
            } while (matchingPrice == null);

            return (double)matchingPrice;
        }
    }
}