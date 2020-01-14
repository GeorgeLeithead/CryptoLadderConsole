using System;
using System.Collections.Generic;
using System.Linq;
using CryptoLadder.Client;
using CryptoLadder.Definitions;
using CryptoLadder.Model;
using RestSharp;

namespace CryptoLadder.Api
{
    public class OrderCreate : BaseApi
    {
        /// <summary>API path</summary>
        private string path = "/v2/private/order/create";
        /// <summary>API queryparameters.</summary>
        private List<KeyValuePair<string, string>> queryParams = new List<KeyValuePair<string, string>>();
        private Dictionary<string, string> formParams = new Dictionary<string, string>();
        /// <summary>The Accept header</summary>
        private Dictionary<string, string> headerParams = new Dictionary<string, string>();

        /// <summary>Initializes a new instance of the <see cref="OrderCreate"/> class.</summary>
        public OrderCreate(string basePath)
        {
            this.Configuration = new CryptoLadder.Client.Configuration { BasePath = basePath };
            ApiConfiguration();
        }

        /// <summary>Initializes a new instance of the <see cref="OrderCreate"/> class using Configuration object.</summary>
        /// <param name="configuration">An instance of Configuration</param>
        public OrderCreate(CryptoLadder.Client.Configuration configuration = null)
        {
            this.Configuration = (configuration == null) ? CryptoLadder.Client.Configuration.Default : configuration;
            ApiConfiguration();
        }

        private void ApiConfiguration()
        {
            this.headerParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            this.headerParams.Add("Accept", this.Configuration.ApiClient.SelectHeaderAccept(new string[] {
                "application/json"
            }));
            if (string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("api_key")))
            {
                throw new InvalidOperationException("apiKey required");
            }

            if (string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("sign")))
            {
                throw new InvalidOperationException("sign required");
            }

            this.queryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "api_key", this.Configuration.GetApiKeyWithPrefix("api_key")));
            this.queryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "sign", this.Configuration.GetApiKeyWithPrefix("sign")));
        }

        public OrderResBase CallApi(SideEnum side, SymbolEnum symbol, OrderTypeEnum orderType, TimeInForceEnum timeInForce, decimal qty, double price, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null, string trailingStop = null)
        {
            this.formParams.Add("side", this.Configuration.ApiClient.ParameterToString(side)); // form parameter
            this.formParams.Add("symbol", this.Configuration.ApiClient.ParameterToString(symbol)); // form parameter
            this.formParams.Add("order_type", this.Configuration.ApiClient.ParameterToString(orderType)); // form parameter
            this.formParams.Add("time_in_force", this.Configuration.ApiClient.ParameterToString(timeInForce)); // form parameter
            this.formParams.Add("qty", this.Configuration.ApiClient.ParameterToString(qty)); // form parameter
            this.queryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "price", price)); // query parameter
            if (takeProfit != null) this.queryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "take_profit", takeProfit)); // query parameter
            if (stopLoss != null) this.formParams.Add("stop_loss", this.Configuration.ApiClient.ParameterToString(stopLoss)); // form parameter
            if (reduceOnly != null) this.formParams.Add("reduce_only", this.Configuration.ApiClient.ParameterToString(reduceOnly)); // form parameter
            if (closeOnTrigger != null) this.formParams.Add("close_on_trigger", this.Configuration.ApiClient.ParameterToString(closeOnTrigger)); // form parameter
            if (orderLinkId != null) this.formParams.Add("order_link_id", this.Configuration.ApiClient.ParameterToString(orderLinkId)); // form parameter
            if (trailingStop != null) this.formParams.Add("trailing_stop", this.Configuration.ApiClient.ParameterToString(trailingStop)); // form parameter
            IRestResponse localVarResponse = (IRestResponse)base.CallApi(path, Method.POST, queryParams, formParams, headerParams);
            return ProcessRestResponce(localVarResponse).Data;
        }

        public async System.Threading.Tasks.Task<OrderResBase> CallApiAsync(SideEnum side, SymbolEnum symbol, OrderTypeEnum orderType, TimeInForceEnum timeInForce, decimal qty, double price, double? takeProfit = null, double? stopLoss = null, bool? reduceOnly = null, bool? closeOnTrigger = null, string orderLinkId = null, string trailingStop = null)
        {
            this.formParams.Add("side", this.Configuration.ApiClient.ParameterToString(side)); // form parameter
            this.formParams.Add("symbol", this.Configuration.ApiClient.ParameterToString(symbol)); // form parameter
            this.formParams.Add("order_type", this.Configuration.ApiClient.ParameterToString(orderType)); // form parameter
            this.formParams.Add("time_in_force", this.Configuration.ApiClient.ParameterToString(timeInForce)); // form parameter
            this.formParams.Add("qty", this.Configuration.ApiClient.ParameterToString(qty)); // form parameter
            this.queryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "price", price)); // query parameter
            if (takeProfit != null) this.queryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "take_profit", takeProfit)); // query parameter
            if (stopLoss != null) this.formParams.Add("stop_loss", this.Configuration.ApiClient.ParameterToString(stopLoss)); // form parameter
            if (reduceOnly != null) this.formParams.Add("reduce_only", this.Configuration.ApiClient.ParameterToString(reduceOnly)); // form parameter
            if (closeOnTrigger != null) this.formParams.Add("close_on_trigger", this.Configuration.ApiClient.ParameterToString(closeOnTrigger)); // form parameter
            if (orderLinkId != null) this.formParams.Add("order_link_id", this.Configuration.ApiClient.ParameterToString(orderLinkId)); // form parameter
            if (trailingStop != null) this.formParams.Add("trailing_stop", this.Configuration.ApiClient.ParameterToString(trailingStop)); // form parameter
            IRestResponse localVarResponse = (IRestResponse)await base.CallApiAsync(path, Method.POST, queryParams, formParams, headerParams);
            return ProcessRestResponce(localVarResponse).Data;
        }

        private ApiResponse<OrderResBase> ProcessRestResponce(IRestResponse localVarResponse)
        {
            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("OrderCreate", localVarResponse);
                if (exception != null) throw exception;
            }

            OrderResBase keyBase = (OrderResBase)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(OrderResBase));
            OrderRes keyResource = (OrderRes)keyBase.Result;
            keyBase.Result = keyResource;
            return new ApiResponse<Model.OrderResBase>((int)localVarResponse.StatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                keyBase);
            /*
            return new ApiResponse<OrderRes>((int)localVarResponse.StatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (OrderRes)keyBase.Result);
            */
        }
    }
}