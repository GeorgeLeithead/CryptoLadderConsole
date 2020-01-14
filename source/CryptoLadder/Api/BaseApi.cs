using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using CryptoLadder.Api.Interfaces;
using CryptoLadder.Client;

namespace CryptoLadder.Api
{
    public class BaseApi : IApiAccessor
    {
        protected CryptoLadder.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        protected Dictionary<string, FileParameter> localVarFileParams = new Dictionary<string, FileParameter>();
        protected Dictionary<string, string> localVarPathParams = new Dictionary<string, string>();
        /// <summary>The Content-Type header</summary>
        private string localVarHttpContentType = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BaseApi(string basePath)
        {
            this.Configuration = new CryptoLadder.Client.Configuration { BasePath = basePath };
            ExceptionFactory = CryptoLadder.Client.Configuration.DefaultExceptionFactory;
            this.localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(new string[] {
                "application/json",
                "application/x-www-form-urlencoded"
            });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public BaseApi(CryptoLadder.Client.Configuration configuration = null)
        {
            this.Configuration = (configuration == null) ? CryptoLadder.Client.Configuration.Default : configuration;
            ExceptionFactory = CryptoLadder.Client.Configuration.DefaultExceptionFactory;
            this.localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(new string[] {
                "application/json",
                "application/x-www-form-urlencoded"
            });
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

        /// <summary>Makes the HTTP request (Sync).</summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <returns>IRestResponse object</returns>
        protected IRestResponse CallApi(string path, RestSharp.Method method, List<KeyValuePair<string, string>> queryParams, Dictionary<String, String> formParams, Dictionary<string, string> headerParams)
        {
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(path, method, queryParams, null, headerParams, formParams, localVarFileParams, localVarPathParams, localVarHttpContentType);
            return localVarResponse;
        }

        /// <summary>Makes the asynchronous HTTP request.</summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <returns>The Task instance IRestResponse object</returns>
        protected async Task<IRestResponse> CallApiAsync(string path, RestSharp.Method method, List<KeyValuePair<string, string>> queryParams, Dictionary<String, String> formParams, Dictionary<string, string> headerParams)
        {
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(path, method, queryParams, null, headerParams, formParams, localVarFileParams, localVarPathParams, localVarHttpContentType);
            return localVarResponse;
        }
    }
}