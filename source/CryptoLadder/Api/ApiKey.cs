using System;
using System.Collections.Generic;
using System.Linq;
using CryptoLadder.Client;
using RestSharp;

namespace CryptoLadder.Api
{
    /// <summary>Get account api-key information via API.</summary>
    public class ApiKey
    {
        private CryptoLadder.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        private const string localVarPath = "/open-api/api-key";
        private Dictionary<string, string> localVarPathParams = new Dictionary<string, string>();
        private List<KeyValuePair<string, string>> localVarQueryParams = new List<KeyValuePair<string, string>>();

        /// <summary>The Accept header</summary>
        private Dictionary<string, string> localVarHeaderParams = new Dictionary<string, string>();
        private Dictionary<string, string> localVarFormParams = new Dictionary<string, string>();
        private Dictionary<string, FileParameter> localVarFileParams = new Dictionary<string, FileParameter>();

        /// <summary>The Content-Type header</summary>
        private string localVarHttpContentType = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKey"/> class.
        /// </summary>
        /// <returns></returns>
        public ApiKey(string basePath)
        {
            this.Configuration = new CryptoLadder.Client.Configuration { BasePath = basePath };
            SetLocalConfiguration();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKey"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ApiKey(CryptoLadder.Client.Configuration configuration = null)
        {
            this.Configuration = (configuration == null) ? CryptoLadder.Client.Configuration.Default : configuration;
            SetLocalConfiguration();
        }

        private void SetLocalConfiguration()
        {
            this.localVarHeaderParams = new Dictionary<string, string>(this.Configuration.DefaultHeader);
            this.localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(new string[] {
                "application/json",
                "application/x-www-form-urlencoded"
            });
            this.localVarHeaderParams.Add("Accept", this.Configuration.ApiClient.SelectHeaderAccept(new string[] {
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

            this.localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "api_key", this.Configuration.GetApiKeyWithPrefix("api_key")));
            this.localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "sign", this.Configuration.GetApiKeyWithPrefix("sign")));
            ExceptionFactory = CryptoLadder.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public CryptoLadder.Client.Configuration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public CryptoLadder.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Get account api-key information. 
        /// </summary>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>APIKeyInfo</returns>
        public T APIkeyInfo<T>()
        {
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);
            return ProcessRestResponce<T>(localVarResponse).Data;
        }

        /// <summary>
        /// Get account api-key information. 
        /// </summary>
        /// <exception cref="CryptoLadder.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of APIKeyInfo</returns>
        public async System.Threading.Tasks.Task<T> APIkeyInfoAsync<T>()
        {
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);
            return ProcessRestResponce<T>(localVarResponse).Data;
        }

        private ApiResponse<T> ProcessRestResponce<T>(IRestResponse localVarResponse)
        {
            int localVarStatusCode = (int)localVarResponse.StatusCode;
            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("APIkeyInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            T keyBase = (T)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(T));
            return new ApiResponse<T>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                keyBase);
        }
    }
}