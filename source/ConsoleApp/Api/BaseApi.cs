using InternetWideWorld.CryptoLadder.ConsoleApp.Api.Interfaces;
using InternetWideWorld.CryptoLadder.ConsoleApp.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetWideWorld.CryptoLadder.ConsoleApp.Api
{
    /// <summary>Base API class</summary>
    public class BaseApi : IApiAccessor, IBaseApi
    {
        /// <summary>Exception factory</summary>
        protected ExceptionFactory _exceptionFactory = (name, response) => null;
        /// <summary>Local file parameters.</summary>
        protected Dictionary<string, FileParameter> localVarFileParams = new Dictionary<string, FileParameter>();
        /// <summary>Local path parameters.</summary>
        protected Dictionary<string, string> localVarPathParams = new Dictionary<string, string>();
        /// <summary>The Content-Type header</summary>
        private readonly string localVarHttpContentType = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApi"/> class.
        /// </summary>
        public BaseApi(string basePath)
        {
            Configuration = new Configuration { BasePath = basePath };
            ExceptionFactory = Configuration.DefaultExceptionFactory;
            localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(new string[] {
                "application/json",
                "application/x-www-form-urlencoded"
            });
        }

        /// <summary>Initializes a new instance of the <see cref="BaseApi"/> class using Configuration object</summary>
        /// <param name="configuration">An instance of Configuration</param>
        public BaseApi(Configuration configuration = null)
        {
            Configuration = configuration ?? Configuration.Default;
            ExceptionFactory = Configuration.DefaultExceptionFactory;
            localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(new string[] {
                "application/json",
                "application/x-www-form-urlencoded"
            });
        }

        /// <summary>Gets the base path of the API client.</summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>Gets or sets the configuration object</summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration { get; set; }

        /// <summary>Provides a factory method hook for the creation of exceptions.</summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multi-cast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set => _exceptionFactory = value;
        }

        /// <summary>Makes the HTTP request (Sync).</summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <returns>IRestResponse object</returns>
        protected IRestResponse CallApi(string path, Method method, List<KeyValuePair<string, string>> queryParams, Dictionary<string, string> formParams, Dictionary<string, string> headerParams)
        {
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(path, method, queryParams, null, headerParams, formParams, localVarFileParams, localVarPathParams, localVarHttpContentType);
            return localVarResponse;
        }

        /// <summary>Makes the asynchronous HTTP request.</summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <returns>The Task instance IRestResponse object</returns>
        protected async Task<IRestResponse> CallApiAsync(string path, Method method, List<KeyValuePair<string, string>> queryParams, Dictionary<string, string> formParams, Dictionary<string, string> headerParams)
        {
            IRestResponse localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(path, method, queryParams, null, headerParams, formParams, localVarFileParams, localVarPathParams, localVarHttpContentType);
            return localVarResponse;
        }
    }
}