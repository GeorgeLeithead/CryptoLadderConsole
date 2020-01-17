namespace CryptoLadder.Definitions
{
    /// <summary>Trigger by price enumeration.</summary>
    public enum TriggerPriceTypeEnum
    {
        /// <summary>ByBit's current market price (LTP).</summary>
        /// <remarks>The Last Traded Price is always anchored to the spot price using the funding mechanism.</remarks>
        LastPrice,
        /// <summary>ByBit's Index Price (ISP).</summary>
        /// <remarks>A calculation of the Spot Price from the respective reference exchange.</remarks>
        IndexPrice,
        /// <summary>ByBit's Mark Price (MP)</summary>
        /// <remarks>A global spot price index plus a decaying funding basis rate.  Mark price can be considered as a price that reflects the real-time spot price on the major exchanges.</remarks>
        MarkPrice
    }
}