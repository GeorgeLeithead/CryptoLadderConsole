using System;
using CryptoLadder.Client;
using CryptoLadder.Definitions;

namespace CryptoLadder.Api.Interfaces {
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOrderApi : IApiAccessor {
        #region Synchronous Operations
        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID</param>
        /// <param name="symbol">Contract type. (optional)</param>
        /// <returns>Object</returns>
        Object OrderCancel (string orderId, SymbolEnum? symbol = null);

        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID</param>
        /// <param name="symbol">Contract type. (optional)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> OrderCancelWithHttpInfo (string orderId, SymbolEnum? symbol = null);
        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="symbol">Contract type.</param>
        /// <returns>Object</returns>
        Object OrderCancelAll (SymbolEnum? symbol);

        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="symbol">Contract type.</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> OrderCancelAllWithHttpInfo (SymbolEnum? symbol);
        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="symbol">Contract type. (optional)</param>
        /// <param name="orderLinkId">Order link id. (optional)</param>
        /// <returns>Object</returns>
        Object OrderCancelV2 (string orderId = null, SymbolEnum? symbol = null, string orderLinkId = null);

        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="symbol">Contract type. (optional)</param>
        /// <param name="orderLinkId">Order link id. (optional)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> OrderCancelV2WithHttpInfo (string orderId = null, SymbolEnum? symbol = null, string orderLinkId = null);
        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="orderLinkId">Customized order ID. (optional)</param>
        /// <param name="symbol">Contract type. Default BTCUSD (optional)</param>
        /// <param name="order">Sort orders by creation date (optional)</param>
        /// <param name="page">Page. Default getting first page data (optional)</param>
        /// <param name="limit">TLimit for data size per page, max size is 50. Default as showing 20 pieces of data per page (optional)</param>
        /// <param name="orderStatus">Query your orders for all statuses if &#39;order_status&#39; is empty. If you want to query orders with specific statuses , you can pass the order_status split by (optional)</param>
        /// <returns>Object</returns>
        Object OrderGetOrders (string orderId = null, string orderLinkId = null, SymbolEnum? symbol = null, string order = null, decimal? page = null, decimal? limit = null, string orderStatus = null);

        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="orderLinkId">Customized order ID. (optional)</param>
        /// <param name="symbol">Contract type. Default BTCUSD (optional)</param>
        /// <param name="order">Sort orders by creation date (optional)</param>
        /// <param name="page">Page. Default getting first page data (optional)</param>
        /// <param name="limit">TLimit for data size per page, max size is 50. Default as showing 20 pieces of data per page (optional)</param>
        /// <param name="orderStatus">Query your orders for all statuses if &#39;order_status&#39; is empty. If you want to query orders with specific statuses , you can pass the order_status split by (optional)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> OrderGetOrdersWithHttpInfo (string orderId = null, string orderLinkId = null, SymbolEnum? symbol = null, string order = null, decimal? page = null, decimal? limit = null, string orderStatus = null);
        /// <summary>
        /// Place active order
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="side">Side</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="orderType">Active order type</param>
        /// <param name="qty"></param>
        /// <param name="price">Order price.</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="takeProfit">take profit price (optional)</param>
        /// <param name="stopLoss">stop loss price (optional)</param>
        /// <param name="reduceOnly">reduce only (optional)</param>
        /// <param name="closeOnTrigger">close on trigger (optional)</param>
        /// <param name="orderLinkId">TCustomized order ID, maximum length at 36 characters, and order ID under the same agency has to be unique. (optional)</param>
        /// <returns>Object</returns>
        Object OrderNew (SideEnum side, SymbolEnum symbol, string orderType, decimal? qty, double? price, string timeInForce, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null);

        /// <summary>
        /// Place active order
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="side">Side</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="orderType">Active order type</param>
        /// <param name="qty"></param>
        /// <param name="price">Order price.</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="takeProfit">take profit price (optional)</param>
        /// <param name="stopLoss">stop loss price (optional)</param>
        /// <param name="reduceOnly">reduce only (optional)</param>
        /// <param name="closeOnTrigger">close on trigger (optional)</param>
        /// <param name="orderLinkId">TCustomized order ID, maximum length at 36 characters, and order ID under the same agency has to be unique. (optional)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> OrderNewWithHttpInfo (SideEnum side, SymbolEnum symbol, string orderType, decimal? qty, double? price, string timeInForce, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null);
        /// <summary>
        /// Place active order
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="side">Side</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="orderType">Active order type</param>
        /// <param name="qty"></param>
        /// <param name="price">Order price.</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="takeProfit">take profit price (optional)</param>
        /// <param name="stopLoss">stop loss price (optional)</param>
        /// <param name="reduceOnly">reduce only (optional)</param>
        /// <param name="closeOnTrigger">close on trigger (optional)</param>
        /// <param name="orderLinkId">TCustomized order ID, maximum length at 36 characters, and order ID under the same agency has to be unique. (optional)</param>
        /// <param name="trailingStop">Trailing stop. (optional)</param>
        /// <returns>Object</returns>
        Object OrderNewV2 (SideEnum side, SymbolEnum symbol, string orderType, decimal? qty, double? price, string timeInForce, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null, string trailingStop = null);

        /// <summary>
        /// Place active order
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="side">Side</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="orderType">Active order type</param>
        /// <param name="qty"></param>
        /// <param name="price">Order price.</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="takeProfit">take profit price (optional)</param>
        /// <param name="stopLoss">stop loss price (optional)</param>
        /// <param name="reduceOnly">reduce only (optional)</param>
        /// <param name="closeOnTrigger">close on trigger (optional)</param>
        /// <param name="orderLinkId">TCustomized order ID, maximum length at 36 characters, and order ID under the same agency has to be unique. (optional)</param>
        /// <param name="trailingStop">Trailing stop. (optional)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> OrderNewV2WithHttpInfo (SideEnum side, SymbolEnum symbol, string orderType, decimal? qty, double? price, string timeInForce, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null, string trailingStop = null);
        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="symbol">Contract type. Default BTCUSD (optional)</param>
        /// <returns>Object</returns>
        Object OrderQuery (string orderId = null, SymbolEnum? symbol = null);

        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="symbol">Contract type. Default BTCUSD (optional)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> OrderQueryWithHttpInfo (string orderId = null, SymbolEnum? symbol = null);
        /// <summary>
        /// Replace active order. Only incomplete orders can be modified. 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID.</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="pRQty">Order quantity. (optional)</param>
        /// <param name="pRPrice">Order price. (optional)</param>
        /// <returns>Object</returns>
        Object OrderReplace (string orderId, SymbolEnum? symbol, decimal? pRQty = null, double? pRPrice = null);

        /// <summary>
        /// Replace active order. Only incomplete orders can be modified. 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID.</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="pRQty">Order quantity. (optional)</param>
        /// <param name="pRPrice">Order price. (optional)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> OrderReplaceWithHttpInfo (string orderId, SymbolEnum? symbol, decimal? pRQty = null, double? pRPrice = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID</param>
        /// <param name="symbol">Contract type. (optional)</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> OrderCancelAsync (string orderId, SymbolEnum? symbol = null);

        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID</param>
        /// <param name="symbol">Contract type. (optional)</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> OrderCancelAsyncWithHttpInfo (string orderId, SymbolEnum? symbol = null);
        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="symbol">Contract type.</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> OrderCancelAllAsync (SymbolEnum? symbol);

        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="symbol">Contract type.</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> OrderCancelAllAsyncWithHttpInfo (SymbolEnum? symbol);
        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="symbol">Contract type. (optional)</param>
        /// <param name="orderLinkId">Order link id. (optional)</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> OrderCancelV2Async (string orderId = null, SymbolEnum? symbol = null, string orderLinkId = null);

        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="symbol">Contract type. (optional)</param>
        /// <param name="orderLinkId">Order link id. (optional)</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> OrderCancelV2AsyncWithHttpInfo (string orderId = null, SymbolEnum? symbol = null, string orderLinkId = null);
        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="orderLinkId">Customized order ID. (optional)</param>
        /// <param name="symbol">Contract type. Default BTCUSD (optional)</param>
        /// <param name="order">Sort orders by creation date (optional)</param>
        /// <param name="page">Page. Default getting first page data (optional)</param>
        /// <param name="limit">TLimit for data size per page, max size is 50. Default as showing 20 pieces of data per page (optional)</param>
        /// <param name="orderStatus">Query your orders for all statuses if &#39;order_status&#39; is empty. If you want to query orders with specific statuses , you can pass the order_status split by (optional)</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> OrderGetOrdersAsync (string orderId = null, string orderLinkId = null, SymbolEnum? symbol = null, string order = null, decimal? page = null, decimal? limit = null, string orderStatus = null);

        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="orderLinkId">Customized order ID. (optional)</param>
        /// <param name="symbol">Contract type. Default BTCUSD (optional)</param>
        /// <param name="order">Sort orders by creation date (optional)</param>
        /// <param name="page">Page. Default getting first page data (optional)</param>
        /// <param name="limit">TLimit for data size per page, max size is 50. Default as showing 20 pieces of data per page (optional)</param>
        /// <param name="orderStatus">Query your orders for all statuses if &#39;order_status&#39; is empty. If you want to query orders with specific statuses , you can pass the order_status split by (optional)</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> OrderGetOrdersAsyncWithHttpInfo (string orderId = null, string orderLinkId = null, SymbolEnum? symbol = null, string order = null, decimal? page = null, decimal? limit = null, string orderStatus = null);
        /// <summary>
        /// Place active order
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="side">Side</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="orderType">Active order type</param>
        /// <param name="qty"></param>
        /// <param name="price">Order price.</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="takeProfit">take profit price (optional)</param>
        /// <param name="stopLoss">stop loss price (optional)</param>
        /// <param name="reduceOnly">reduce only (optional)</param>
        /// <param name="closeOnTrigger">close on trigger (optional)</param>
        /// <param name="orderLinkId">TCustomized order ID, maximum length at 36 characters, and order ID under the same agency has to be unique. (optional)</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> OrderNewAsync (SideEnum side, SymbolEnum symbol, string orderType, decimal? qty, double? price, string timeInForce, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null);

        /// <summary>
        /// Place active order
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="side">Side</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="orderType">Active order type</param>
        /// <param name="qty"></param>
        /// <param name="price">Order price.</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="takeProfit">take profit price (optional)</param>
        /// <param name="stopLoss">stop loss price (optional)</param>
        /// <param name="reduceOnly">reduce only (optional)</param>
        /// <param name="closeOnTrigger">close on trigger (optional)</param>
        /// <param name="orderLinkId">TCustomized order ID, maximum length at 36 characters, and order ID under the same agency has to be unique. (optional)</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> OrderNewAsyncWithHttpInfo (SideEnum side, SymbolEnum symbol, string orderType, decimal? qty, double? price, string timeInForce, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null);
        /// <summary>
        /// Place active order
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="side">Side</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="orderType">Active order type</param>
        /// <param name="qty"></param>
        /// <param name="price">Order price.</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="takeProfit">take profit price (optional)</param>
        /// <param name="stopLoss">stop loss price (optional)</param>
        /// <param name="reduceOnly">reduce only (optional)</param>
        /// <param name="closeOnTrigger">close on trigger (optional)</param>
        /// <param name="orderLinkId">TCustomized order ID, maximum length at 36 characters, and order ID under the same agency has to be unique. (optional)</param>
        /// <param name="trailingStop">Trailing stop. (optional)</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> OrderNewV2Async (SideEnum side, SymbolEnum symbol, string orderType, decimal? qty, double? price, string timeInForce, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null, string trailingStop = null);

        /// <summary>
        /// Place active order
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="side">Side</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="orderType">Active order type</param>
        /// <param name="qty"></param>
        /// <param name="price">Order price.</param>
        /// <param name="timeInForce">Time in force</param>
        /// <param name="takeProfit">take profit price (optional)</param>
        /// <param name="stopLoss">stop loss price (optional)</param>
        /// <param name="reduceOnly">reduce only (optional)</param>
        /// <param name="closeOnTrigger">close on trigger (optional)</param>
        /// <param name="orderLinkId">TCustomized order ID, maximum length at 36 characters, and order ID under the same agency has to be unique. (optional)</param>
        /// <param name="trailingStop">Trailing stop. (optional)</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> OrderNewV2AsyncWithHttpInfo (SideEnum side, SymbolEnum symbol, string orderType, decimal? qty, double? price, string timeInForce, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null, string trailingStop = null);
        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="symbol">Contract type. Default BTCUSD (optional)</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> OrderQueryAsync (string orderId = null, SymbolEnum? symbol = null);

        /// <summary>
        /// Get my active order list.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID (optional)</param>
        /// <param name="symbol">Contract type. Default BTCUSD (optional)</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> OrderQueryAsyncWithHttpInfo (string orderId = null, SymbolEnum? symbol = null);
        /// <summary>
        /// Replace active order. Only incomplete orders can be modified. 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID.</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="pRQty">Order quantity. (optional)</param>
        /// <param name="pRPrice">Order price. (optional)</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> OrderReplaceAsync (string orderId, SymbolEnum symbol, decimal? pRQty = null, double? pRPrice = null);

        /// <summary>
        /// Replace active order. Only incomplete orders can be modified. 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">Order ID.</param>
        /// <param name="symbol">Contract type.</param>
        /// <param name="pRQty">Order quantity. (optional)</param>
        /// <param name="pRPrice">Order price. (optional)</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> OrderReplaceAsyncWithHttpInfo (string orderId, SymbolEnum? symbol, decimal? pRQty = null, double? pRPrice = null);
        #endregion Asynchronous Operations
    }
}