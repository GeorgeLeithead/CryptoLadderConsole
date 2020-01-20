using CryptoLadder.Client;
using CryptoLadder.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoLadder.Api
{
    /// <summary>Get user API key information class.</summary>
    public class KeyInfo : BaseApi
    {
        /// <summary>API path</summary>
        private readonly string path = "/open-api/api-key";
        /// <summary>API query parameters.</summary>
        private readonly List<KeyValuePair<string, string>> queryParams = new List<KeyValuePair<string, string>>();
        private readonly Dictionary<string, string> formParams = new Dictionary<string, string>();
        /// <summary>The Accept header</summary>
        private Dictionary<string, string> headerParams = new Dictionary<string, string>();

        /// <summary>Initializes a new instance of the <see cref="KeyInfo"/> class.</summary>
        public KeyInfo(string basePath)
        {
            Configuration = new Configuration { BasePath = basePath };
            ApiConfiguration();
        }

        /// <summary>Initializes a new instance of the <see cref="KeyInfo"/> class using Configuration object.</summary>
        /// <param name="configuration">An instance of Configuration</param>
        public KeyInfo(Configuration configuration = null)
        {
            Configuration = (configuration == null) ? Configuration.Default : configuration;
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
        /// <returns><see cref="APIKeyBase"/> object.</returns>
        public APIKeyBase CallApi()
        {
            IRestResponse localVarResponse = CallApi(path, Method.GET, queryParams, formParams, headerParams);
            return ProcessRestResponce(localVarResponse).Data;
        }

        /// <summary>Makes the HTTP request (Async).</summary>
        /// <returns><see cref="APIKeyBase"/> object.</returns>
        public async System.Threading.Tasks.Task<APIKeyBase> CallApiAsync()
        {
            IRestResponse localVarResponse = await CallApiAsync(path, Method.GET, queryParams, formParams, headerParams);
            return ProcessRestResponce(localVarResponse).Data;
        }

        /// <summary>Process the JSON rest response.</summary>
        /// <param name="localVarResponse">JSON rest response.</param>
        /// <returns><see cref="ApiResponse{T}"/> object.</returns>
        private ApiResponse<APIKeyBase> ProcessRestResponce(IRestResponse localVarResponse)
        {
            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("APIkeyInfo", localVarResponse);
                if (exception != null)
                {
                    throw exception;
                }
            }

            APIKeyBase keyBase = (APIKeyBase)Configuration.ApiClient.Deserialize(localVarResponse, typeof(APIKeyBase));
            if (keyBase.RetCode != 0)
            {
                throw new ApiException((int)keyBase.RetCode, keyBase.RetMsg);
            }

            return new ApiResponse<APIKeyBase>((int)localVarResponse.StatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                keyBase);
        }
    }
}