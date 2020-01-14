namespace CryptoLadder.Definitions
{
    public enum WithdrawStatusEnum
    {
        TobeConfirmed,
        UnderReview,

        /// <summary>Pending transfer</summary>
        Pending,
        Success,
        CancelByUser,
        Reject,
        Expire
    }
}