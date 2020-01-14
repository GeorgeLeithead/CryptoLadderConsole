using System;
using System.Globalization;

namespace CryptoLadder.BusinessLogic
{
    public static class QuantityReader
    {
        public static int Get(int rungs)
        {
            int? matchingTotalQuantity = null;

            do
            {
                Console.Write("Please enter the TOTAL unit quantity: ");
                var read = Console.ReadLine();
                try {
                    matchingTotalQuantity = int.Parse(read, CultureInfo.InvariantCulture);
                    if ((int)matchingTotalQuantity < rungs)
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