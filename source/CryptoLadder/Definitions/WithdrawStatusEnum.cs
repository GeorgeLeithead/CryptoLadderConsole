namespace CryptoLadder.Definitions
{
    /// <summary>Withdraw status enumeration.</summary>
    public enum WithdrawStatusEnum
    {
        /// <summary>To be confirmed.</summary>
        TobeConfirmed,
        /// <summary>Under review.</summary>
        UnderReview,

        /// <summary>Pending transfer</summary>
        Pending,
        /// <summary>Success</summary>
        Success,
        /// <summary>Canceled by user.</summary>
        CancelByUser,
        /// <summary>Rejected.</summary>
        Reject,
        /// <summary>Expired.</summary>
        Expire
    }
}