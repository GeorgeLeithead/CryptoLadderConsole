namespace InternetWideWorld.CryptoLadder.Shared.Definitions
{
    /// <summary>Time in force enumeration.</summary>
    public enum TimeInForceEnum
    {
        /// <summary>Good until cancel (GTC).</summary>
        /// <remarks>Order remains effective indefinitely until fully executed unless cancellation is made.</remarks>
        GoodTillCancel,
        /// <summary>Immediate or cancel (IOC).</summary>
        /// <remarks>Order that must be filled immediately at the limit price or better only.  if the order cannot be filled immediately or fully, the unfilled portion will be canceled.</remarks>
        ImmediateOrcancel,
        /// <summary>Fill or kill (FOC)</summary>
        /// <remarks>Order must be immediately filled in its entirety at the limit price or better; otherwise, it will be totally canceled.  No partial fills are allowed.</remarks>
        FillOrKill,
        /// <summary>Post only (POO)</summary>
        /// <remarks>Strictly ensure that limit orders will be placed into the order book and therefore receive a maker rebate then it is ultimately executed.</remarks>
        PostOnly
    }
}