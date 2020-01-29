using System;
using System.Globalization;

namespace InternetWideWorld.CryptoLadder.ConsoleApp.BusinessLogic
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
                if (!Shared.BusinessLogic.PriceReader.IsPriceValid(read))
                {
                    continue;
                }

                return double.Parse(read, CultureInfo.InvariantCulture);
            } while(true);
        }
    }
}