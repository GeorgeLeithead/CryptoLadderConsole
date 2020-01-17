using CryptoLadder.Client;
using CryptoLadder.Definitions;
using CryptoLadder.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoLadder.Api
{
    /// <summary>Create active order class.</summary>
    public class OrderCreate : BaseApi
    {
        /// <summary>API path</summary>
        private readonly string path = "/v2/private/order/create";
        /// <summary>API query parameters.</summary>
        private readonly List<KeyValuePair<string, string>> queryParams = new List<KeyValuePair<string, string>>();
        private readonly Dictionary<string, string> formParams = new Dictionary<string, string>();
        /// <summary>The Accept header</summary>
        private Dictionary<string, string> headerParams = new Dictionary<string, string>();

        /// <summary>Initializes a new instance of the <see cref="OrderCreate"/> class.</summary>
        public OrderCreate(string basePath)
        {
            Configuration = new Configuration { BasePath = basePath };
            ApiConfiguration();
        }

        /// <summary>Initializes a new instance of the <see cref="OrderCreate"/> class using Configuration object.</summary>
        /// <param name="configuration">An instance of Configuration</param>
        public OrderCreate(Configuration configuration = null)
        {
            Configuration = configuration ?? Configuration.Default;
            ApiConfiguration();
        }

        /// <summary>Configure the API parameters.</summary>
        private void ApiConfiguration()
        {
            headerParams = new Dictionary<string, string>(Configuration.DefaultHeader)
            {
                {
                    "Accept",
                    Configuration.ApiClient.SelectHeaderAccept(new string[] {
                "application/json"
            })
                }
            };
            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("api_key")))
            {
                throw new InvalidOperationException("apiKey required");
            }

            if (string.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("sign")))
            {
                throw new InvalidOperationException("sign required");
            }

            queryParams.AddRange(Configuration.ApiClient.ParameterToKeyValuePairs("", "api_key", Configuration.GetApiKeyWithPrefix("api_key")));
            queryParams.AddRange(Configuration.ApiClient.ParameterToKeyValuePairs("", "sign", Configuration.GetApiKeyWithPrefix("sign")));
        }

        /// <summary>Makes the HTTP request (Sync).</summary>
        /// <param name="side">Order side</param>
        /// <param name="symbol">Currency symbol for order</param>
        /// <param name="orderType">Order type</param>
        /// <param name="timeInForce">Time in force for order</param>
        /// <param name="qty">Order quantity of perpetual contracts to buy or sell</param>
        /// <param name="price">Order price of perpetual contracts to buy or sell.</param>
        /// <param name="takeProfit">Order take profit (TP) price</param>
        /// <param name="stopLoss">Order stop loss (SL) price </param>
        /// <param name="reduceOnly">Reduce only</param>
        /// <param name="closeOnTrigger">Closing trigger.  When creating a closing order, it is highly recommended to set as true to avoid failing by insufficient available margin.</param>
        /// <param name="orderLinkId">Custom order identifier.</param>
        /// <param name="trailingStop">Order trailing stop (TS) units.</param>
        /// <remarks>As of 20190117 ByBit only support order quantity in an integer.</remarks>
        /// <returns><see cref="OrderResBase"/> object.</returns>
        public OrderResBase CallApi(SideEnum side, SymbolEnum symbol, OrderTypeEnum orderType, TimeInForceEnum timeInForce, decimal qty, double price, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null, string trailingStop = null)
        {
            formParams.Add("side", Configuration.ApiClient.ParameterToString(side)); // form parameter
            formParams.Add("symbol", Configuration.ApiClient.ParameterToString(symbol)); // form parameter
            formParams.Add("order_type", Configuration.ApiClient.ParameterToString(orderType)); // form parameter
            formParams.Add("time_in_force", Configuration.ApiClient.ParameterToString(timeInForce)); // form parameter
            formParams.Add("qty", Configuration.ApiClient.ParameterToString(qty)); // form parameter
            queryParams.AddRange(Configuration.ApiClient.ParameterToKeyValuePairs("", "price", price)); // query parameter
            if (takeProfit != null)
            {
                queryParams.AddRange(Configuration.ApiClient.ParameterToKeyValuePairs("", "take_profit", takeProfit)); // query parameter
            }

            if (stopLoss != null)
            {
                formParams.Add("stop_loss", Configuration.ApiClient.ParameterToString(stopLoss)); // form parameter
            }

            if (reduceOnly != null)
            {
                formParams.Add("reduce_only", Configuration.ApiClient.ParameterToString(reduceOnly)); // form parameter
            }

            if (closeOnTrigger != null)
            {
                formParams.Add("close_on_trigger", Configuration.ApiClient.ParameterToString(closeOnTrigger)); // form parameter
            }

            if (orderLinkId != null)
            {
                formParams.Add("order_link_id", Configuration.ApiClient.ParameterToString(orderLinkId)); // form parameter
            }

            if (trailingStop != null)
            {
                formParams.Add("trailing_stop", Configuration.ApiClient.ParameterToString(trailingStop)); // form parameter
            }

            IRestResponse localVarResponse = base.CallApi(path, Method.POST, queryParams, formParams, headerParams);
            return ProcessRestResponce(localVarResponse).Data;
        }

        /// <summary>Makes the HTTP request (Async).</summary>
        /// <param name="side">Order side</param>
        /// <param name="symbol">Currency symbol for order</param>
        /// <param name="orderType">Order type</param>
        /// <param name="timeInForce">Time in force for order</param>
        /// <param name="qty">Order quantity of perpetual contracts to buy or sell</param>
        /// <param name="price">Order price of perpetual contracts to buy or sell.</param>
        /// <param name="takeProfit">Order take profit (TP) price</param>
        /// <param name="stopLoss">Order stop loss (SL) price </param>
        /// <param name="reduceOnly">Reduce only</param>
        /// <param name="closeOnTrigger">Closing trigger.  When creating a closing order, it is highly recommended to set as true to avoid failing by insufficient available margin.</param>
        /// <param name="orderLinkId">Custom order identifier.</param>
        /// <param name="trailingStop">Order trailing stop (TS) units.</param>
        /// <remarks>As of 20190117 ByBit only support order quantity in an integer.</remarks>
        /// <returns><see cref="OrderResBase"/> object.</returns>
        public async System.Threading.Tasks.Task<OrderResBase> CallApiAsync(SideEnum side, SymbolEnum symbol, OrderTypeEnum orderType, TimeInForceEnum timeInForce, decimal qty, double price, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null, string trailingStop = null)
        {
            formParams.Add("side", Configuration.ApiClient.ParameterToString(side)); // form parameter
            formParams.Add("symbol", Configuration.ApiClient.ParameterToString(symbol)); // form parameter
            formParams.Add("order_type", Configuration.ApiClient.ParameterToString(orderType)); // form parameter
            formParams.Add("time_in_force", Configuration.ApiClient.ParameterToString(timeInForce)); // form parameter
            formParams.Add("qty", Configuration.ApiClient.ParameterToString(qty)); // form parameter
            queryParams.AddRange(Configuration.ApiClient.ParameterToKeyValuePairs("", "price", price)); // query parameter
            if (takeProfit != null)
            {
                queryParams.AddRange(Configuration.ApiClient.ParameterToKeyValuePairs("", "take_profit", takeProfit)); // query parameter
            }

            if (stopLoss != null)
            {
                formParams.Add("stop_loss", Configuration.ApiClient.ParameterToString(stopLoss)); // form parameter
            }

            if (reduceOnly != null)
            {
                formParams.Add("reduce_only", Configuration.ApiClient.ParameterToString(reduceOnly)); // form parameter
            }

            if (closeOnTrigger != null)
            {
                formParams.Add("close_on_trigger", Configuration.ApiClient.ParameterToString(closeOnTrigger)); // form parameter
            }

            if (orderLinkId != null)
            {
                formParams.Add("order_link_id", Configuration.ApiClient.ParameterToString(orderLinkId)); // form parameter
            }

            if (trailingStop != null)
            {
                formParams.Add("trailing_stop", Configuration.ApiClient.ParameterToString(trailingStop)); // form parameter
            }

            IRestResponse localVarResponse = await base.CallApiAsync(path, Method.POST, queryParams, formParams, headerParams);
            return ProcessRestResponce(localVarResponse).Data;
        }

        /// <summary>Process the JSON rest response.</summary>
        /// <param name="localVarResponse">JSON rest response.</param>
        /// <returns><see cref="ApiResponse{T}"/> object.</returns>
        private ApiResponse<OrderResBase> ProcessRestResponce(IRestResponse localVarResponse)
        {
            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("OrderCreate", localVarResponse);
                if (exception != null)
                {
                    throw exception;
                }
            }

            OrderResBase keyBase = (OrderResBase)Configuration.ApiClient.Deserialize(localVarResponse, typeof(OrderResBase));
            OrderRes keyResource = keyBase.Result;
            keyBase.Result = keyResource;
            return new ApiResponse<OrderResBase>((int)localVarResponse.StatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                keyBase);
        }
    }
}