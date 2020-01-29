namespace InternetWideWorld.CryptoLadder.Shared.Definitions
{
    /// <summary>Wallet funding type enumeration.</summary>
    public enum WalletFundTypeEnum
    {
        /// <summary>Deposit</summary>
        Deposit,
        /// <summary>Withdraw</summary>
        Withdraw,
        /// <summary>Realised Profit and Loss</summary>
        RealisedPNL,
        /// <summary>Commission</summary>
        Commission,
        /// <summary>Refund</summary>
        Refund,
        /// <summary>Prize</summary>
        Prize,
        /// <summary>Exchange order withdraw</summary>
        ExchangeOrderWithdraw,
        /// <summary>Exchange order deposit</summary>
        ExchangeOrderDeposit
    }
}