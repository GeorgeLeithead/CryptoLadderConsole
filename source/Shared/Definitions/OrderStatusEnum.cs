namespace InternetWideWorld.CryptoLadder.Shared.Definitions
{
    /// <summary>Order status enumeration.</summary>
    public enum OrderStatusEnum
    {
        /// <summary>Created</summary>
        Created,
        /// <summary>New</summary>
        New,
        /// <summary>Partially filled</summary>
        PartiallyFilled,
        /// <summary>Filled</summary>
        Filled,
        /// <summary>Canceled</summary>
        Cancelled,
        /// <summary>Rejected</summary>
        Rejected,
        /// <summary>Pending cancel</summary>
        /// <remarks>The matching engine has received the cancellation but there is no guarantee that it will be successful.</remarks>
        PendingCancel,
        /// <summary>Deactivated.</summary>
        /// <remarks>The conditional order was canceled before triggering.</remarks>
        Deactivated
    }
}