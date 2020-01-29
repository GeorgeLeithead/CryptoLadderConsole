using System;
using System.Globalization;

namespace InternetWideWorld.CryptoLadder.ConsoleApp.BusinessLogic
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
                if (!Shared.BusinessLogic.RungsReader.IsRungsValid(read))
                {
                    continue;
                }

                return int.Parse(read, CultureInfo.InvariantCulture);
            } while (true);
        }
    }
}