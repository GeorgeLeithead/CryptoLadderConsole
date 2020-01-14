using System;
using System.Globalization;

namespace CryptoLadder.BusinessLogic
{
    public static class RungsReader
    {
        public static int Get()
        {
            int? matchingRungs = null;

            do
            {
                Console.Write("Please enter the number of rungs (> 2 and < 100): ");
                var read = Console.ReadLine();
                try {
                    matchingRungs = int.Parse(read, CultureInfo.InvariantCulture);
                    if ((int)matchingRungs < 3 || (int)matchingRungs > 99)
                    {
                        matchingRungs = null;
                    }
                }
                catch {}
            } while (matchingRungs == null);

            return (int)matchingRungs;
        }
    }
}