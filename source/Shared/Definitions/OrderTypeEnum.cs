namespace InternetWideWorld.CryptoLadder.Shared.Definitions
{
    /// <summary>Order type enumeration.</summary>
    public enum OrderTypeEnum
    {
        /// <summary>Limit order</summary>
        /// <remarks>Setting of an execution price for the other.  Only when last traded price r4eaches the order price, will the system fulfill the order.</remarks>
        Limit,
        /// <summary>Market order</summary>
        /// <remarks>A traditional market price order, will be filled at the best available price.  "Price" can be set to be "" if and only if you are placing a market price order.</remarks>
        Market
    }
}