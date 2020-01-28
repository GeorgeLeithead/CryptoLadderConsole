using System.Collections.Generic;
using CryptoLadder.Model;
using Xunit;

namespace CryptoLadder.Tests
{
    public class LadderTests
    {
        [Theory]
        [InlineData(0.11, 0.01, 10, 0.011111111111111112)]
        [InlineData(0.11, 0.01, 11, 0.01)]
        [InlineData(0.01, 0.11, 11, -0.01)]
        public void CalculateGapsTests(double startPrice, double endPrice, int rungs, double expectedGap)
        {
            // When
            double actualGap = CryptoLadder.BusinessLogic.Ladder.Calculate(startPrice, endPrice, rungs);
            // Then
            Assert.Equal(expectedGap, actualGap);
        }

        [Fact]
        public void EmptyLinearTest()
        {
            // When
            List<LinearRungs> list = new List<LinearRungs>();
            // Then
            Assert.Empty(list);
            //List<LinearRungs> actualResult = CryptoLadder.BusinessLogic.Ladder.Linear(startPrice, endPrice, ladderRungs, totalQuantity)
        }
    }
}