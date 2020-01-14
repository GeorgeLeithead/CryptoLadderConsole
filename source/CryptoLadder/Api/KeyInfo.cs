using System;
using System.Collections.Generic;
using System.Linq;
using CryptoLadder.Client;
using CryptoLadder.Model;
using RestSharp;

namespace CryptoLadder.Api
{
    public class KeyInfo : BaseApi
    {
        /// <summary>API path</summary>
        private string path = "/open-api/api-key";
        /// <summary>API queryparameters.</summary>
        private List<KeyValuePair<string, string>> queryParams = new List<KeyValuePair<string, string>>();
        private Dictionary<string, string> formParams = new Dictionary<string, string>();
        /// <summary>The Accept header</summary>
        private Dictionary<string, string> headerParams = new Dictionary<string, string>();

        /// <summary>Initializes a new instance of the <see cref="KeyInfo"/> class.</summary>
        public KeyInfo(string basePath)
        {
            this.Configuration = new CryptoLadder.Client.Configuration { BasePath = basePath };
            ApiConfiguration();
        }

        /// <summary>Initializes a new instance of the <see cref="KeyInfo"/> class using Configuration object.</summary>
        /// <param name="configuration">An instance of Configuration</param>
        public KeyInfo(CryptoLadder.Client.Configuration configuration = null)
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

        public APIKeyInfo CallApi()
        {
            IRestResponse localVarResponse = (IRestResponse)base.CallApi(path, Method.GET, queryParams, formParams, headerParams);
            return ProcessRestResponce(localVarResponse).Data;
        }

        public async System.Threading.Tasks.Task<APIKeyInfo> CallApiAsync()
        {
            IRestResponse localVarResponse = (IRestResponse)await base.CallApiAsync(path, Method.GET, queryParams, formParams, headerParams);
            return ProcessRestResponce(localVarResponse).Data;
        }

        private ApiResponse<APIKeyInfo> ProcessRestResponce(IRestResponse localVarResponse)
        {
            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("APIkeyInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            APIKeyBase keyBase = (APIKeyBase)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(APIKeyBase));
            return new ApiResponse<APIKeyInfo>((int)localVarResponse.StatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (APIKeyInfo)keyBase.Result[0]);
        }
    }
}