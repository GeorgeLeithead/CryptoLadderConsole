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
            do
            {
                Console.Write("Please enter the number of rungs (> 2 and < 100): ");
                string read = Console.ReadLine();
                if (!IsRungsValid(read))
                {
                    continue;
                }

                return int.Parse(read, CultureInfo.InvariantCulture);
            } while (true);
        }

        /// <summary>Validate that the read rungs is valid.</summary>
        public static bool IsRungsValid(string rungs)
        {
            int result;
            bool IsInt = int.TryParse(rungs, out result);
            if (!IsInt)
            {
                return false;
            }

            return (result < 3 || result > 99) ? false : true;
        }
    }
}