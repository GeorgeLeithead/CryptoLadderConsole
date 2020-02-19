using InternetWideWorld.CryptoLadder.Shared.Model;
using System.Collections.Generic;
using System.Linq;

namespace InternetWideWorld.CryptoLadder.Shared.BusinessLogic
{
    /// <summary>Laddering business logic.</summary>
    public static class Ladder
    {
        /// <summary>Linear gradient.</summary>
        private static IReadOnlyList<int> LinearGradient { get; } = new List<int>(new int[] { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 91, 105, 120, 136, 153, 171, 190, 210, 231, 253, 276, 300, 325, 351, 378, 406, 435, 465, 496, 528, 561, 595, 630, 666, 703, 741, 780, 820, 861, 903, 946, 990, 1035, 1081, 1128, 1176, 1225, 1275, 1326, 1378, 1431, 1485, 1540, 1596, 1653, 1711, 1770, 1830, 1891, 1953, 2016, 2080, 2145, 2211, 2278, 2346, 2415, 2485, 2556, 2628, 2701, 2775, 2850, 2926, 3003, 3081, 3160, 3240, 3321, 3403, 3486, 3570, 3655, 3741, 3828, 3916, 4005, 4095, 4186, 4278, 4371, 4465, 4560, 4656, 4753, 4851, 4950, 5050 });

        /// <summary>Calculate the ladder rungs.</summary>
        /// <param name="startPrice">Ladder start price.</param>
        /// <param name="endPrice">Ladder end price.</param>
        /// <param name="rungs">Number of rungs in a ladder.</param>
        /// <returns>The price gap between ladder rungs.</returns>
        public static double Calculate(double startPrice, double endPrice, int rungs)
        {
            return (startPrice - endPrice) / (rungs - 1); // Must remove the last in order to match to start AND end
        }

        /// <summary>Linear gradient ladder.</summary>
        /// <returns>List of <see cref="LinearRungs"/> detailing the price and quantity for each ladder rung.</returns>
        public static List<LinearRungs> Linear(double startPrice, double endPrice, int ladderRungs, int totalQuantity)
        {
            List<LinearRungs> linearLadder = new List<LinearRungs>();
            int linearSum = LinearGradient.Take(ladderRungs).Sum();
            double gaps = Calculate(startPrice, endPrice, ladderRungs);
            double qbase = totalQuantity / (double)linearSum;
            int linearQuantity = 0;
            for (int rungs = 0; rungs < ladderRungs; rungs++)
            {
                double quantity = qbase * LinearGradient[rungs];
                if (rungs + 1 == ladderRungs)
                {
                    quantity = totalQuantity - linearQuantity;
                }

                linearQuantity += (int)quantity;
                double buyIn = startPrice - (rungs * gaps);
                if ((int)quantity > 0)
                {
                    linearLadder.Add(new LinearRungs() { Quantity = (int)quantity, Price = buyIn });
                }
            }

            return linearLadder;
        }
    }
}