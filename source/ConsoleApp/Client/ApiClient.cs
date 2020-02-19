using InternetWideWorld.CryptoLadder.Shared.BusinessLogic;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace InternetWideWorld.CryptoLadder.ConsoleApp.Client
{
    /// <summary>API client is mainly responsible for making the HTTP call to the API back-end.</summary>
    public partial class ApiClient
    {
        private readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        /// <summary>Allows for extending request processing for <see cref="ApiClient"/> generated code.</summary>
        /// <param name="request">The RestSharp request object</param>
        partial void InterceptRequest(IRestRequest request);

        /// <summary>Allows for extending response processing for <see cref="ApiClient"/> generated code.</summary>
        /// <param name="request">The RestSharp request object</param>
        /// <param name="response">The RestSharp response object</param>
        partial void InterceptResponse(IRestRequest request, IRestResponse response);

        /// <summary>Initializes a new instance of the <see cref="ApiClient" /> class with default configuration.</summary>
        public ApiClient()
        {
            Configuration = Client.Configuration.Default;
            RestClient = new RestClient("https://api-testnet.bybit.com");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default base path (https://api-testnet.bybit.com).
        /// </summary>
        /// <param name="config">An instance of Configuration.</param>
        public ApiClient(Configuration config)
        {
            Configuration = config ?? Client.Configuration.Default;
            RestClient = new RestClient(Configuration.BasePath);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" /> class
        /// with default configuration.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        public ApiClient(string basePath = "https://api-testnet.bybit.com")
        {
            if (string.IsNullOrEmpty(basePath))
            {
                throw new ArgumentException("basePath cannot be empty");
            }

            RestClient = new RestClient(basePath);
            Configuration = Client.Configuration.Default;
        }

        /// <summary>Gets or sets an instance of the IReadableConfiguration.</summary>
        /// <value>An instance of the IReadableConfiguration.</value>
        /// <remarks><see cref="IReadableConfiguration"/> helps us to avoid modifying possibly global configuration values from within a given client. It does not guarantee thread-safety of the <see cref="Configuration"/> instance in any way.</remarks>
        public IReadableConfiguration Configuration { get; set; }

        /// <summary>Gets or sets the RestClient.</summary>
        /// <value>An instance of the RestClient</value>
        public RestClient RestClient { get; set; }

        // Creates and sets up a RestRequest prior to a call.
        private RestRequest PrepareRequest(
            string path, Method method, List<KeyValuePair<string, string>> queryParams, object postBody,
            Dictionary<string, string> headerParams, Dictionary<string, string> formParams,
            Dictionary<string, FileParameter> fileParams, Dictionary<string, string> pathParams,
            string contentType)
        {
            RestRequest request = new RestRequest(path, method);

            // add path parameter, if any
            foreach (KeyValuePair<string, string> param in pathParams)
            {
                request.AddParameter(param.Key, param.Value, ParameterType.UrlSegment);
            }

            // add header parameter, if any
            foreach (KeyValuePair<string, string> param in headerParams)
            {
                request.AddHeader(param.Key, param.Value);
            }

            List<KeyValuePair<string, string>> signingKeys = new List<KeyValuePair<string, string>>();
            // add query parameter, if any
            KeyValuePair<string, string> signature = queryParams.FirstOrDefault(qp => qp.Key == "sign");
            queryParams.Add(new KeyValuePair<string, string>("timestamp", new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds().ToString()));
            foreach (KeyValuePair<string, string> param in queryParams.Where(qp => qp.Key != "sign").OrderBy(qp => qp.Key))
            {
                signingKeys.Add(param);
                request.AddQueryParameter(param.Key, param.Value);
            }

            // add form parameter, if any
            foreach (KeyValuePair<string, string> param in formParams.Where(fp => fp.Key != "sign").OrderBy(fp => fp.Key))
            {
                signingKeys.Add(param);
                request.AddParameter(param.Key, param.Value);
            }

            // add file parameter, if any
            foreach (KeyValuePair<string, FileParameter> param in fileParams)
            {
                request.AddFile(param.Value.Name, param.Value.Writer, param.Value.FileName, param.Value.ContentLength, param.Value.ContentType);
            }

            if (postBody != null) // HTTP body (model or byte[]) parameter
            {
                request.AddParameter(contentType, postBody, ParameterType.RequestBody);
            }

            // Generate the signature from all query and form parameters
            if (signature.Key != null)
            {
                string queryString = string.Empty;
                foreach (KeyValuePair<string, string> param in signingKeys.OrderBy(qp => qp.Key))
                {
                    queryString += string.Format(CultureInfo.InvariantCulture, "&{0}={1}", param.Key, param.Value);
                }

                queryString = queryString[1..];
                request.AddQueryParameter("sign", Signature.Create(Configuration.GetApiKeyWithPrefix("sign"), queryString));
            }

            return request;
        }

        /// <summary>Makes the HTTP request (Sync).</summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body (POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="pathParams">Path parameters.</param>
        /// <param name="contentType">Content Type of the request</param>
        /// <returns>Object</returns>
        public object CallApi(
            string path, Method method, List<KeyValuePair<string, string>> queryParams, object postBody,
            Dictionary<string, string> headerParams, Dictionary<string, string> formParams,
            Dictionary<string, FileParameter> fileParams, Dictionary<string, string> pathParams,
            string contentType)
        {
            RestRequest request = PrepareRequest(
                path, method, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, contentType);
            RestClient.Timeout = Configuration.Timeout; // set timeout
            RestClient.UserAgent = Configuration.UserAgent; // set User agent
            InterceptRequest(request);
            IRestResponse response = RestClient.Execute(request);
            InterceptResponse(request, response);
            return response;
        }

        /// <summary>Makes the asynchronous HTTP request.</summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body (POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="pathParams">Path parameters.</param>
        /// <param name="contentType">Content type.</param>
        /// <returns>The Task instance.</returns>
        public async System.Threading.Tasks.Task<object> CallApiAsync(
            string path, Method method, List<KeyValuePair<string, string>> queryParams, object postBody,
            Dictionary<string, string> headerParams, Dictionary<string, string> formParams,
            Dictionary<string, FileParameter> fileParams, Dictionary<string, string> pathParams,
            string contentType)
        {
            RestRequest request = PrepareRequest(
                path, method, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, contentType);
            InterceptRequest(request);
            IRestResponse response = await RestClient.ExecuteTaskAsync(request);
            InterceptResponse(request, response);
            return response;
        }

        /// <summary>
        /// If parameter is DateTime, output in a formatted string (default ISO 8601), customizable with Configuration.DateTime.
        /// If parameter is a list, join the list with ",".
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter (header, path, query, form).</param>
        /// <returns>Formatted string.</returns>
        public string ParameterToString(object obj)
        {
            if (obj is DateTime)
            {
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTime)obj).ToString(Configuration.DateTimeFormat);
            }
            else if (obj is DateTimeOffset)
            {
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTimeOffset)obj).ToString(Configuration.DateTimeFormat);
            }
            else if (obj is IList)
            {
                StringBuilder flattenedString = new StringBuilder();
                foreach (object param in (IList)obj)
                {
                    if (flattenedString.Length > 0)
                    {
                        flattenedString.Append(",");
                    }

                    flattenedString.Append(param);
                }
                return flattenedString.ToString();
            }
            else
            {
                return Convert.ToString(obj);
            }
        }

        /// <summary>De-serialize the JSON string into a proper object.</summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="type">Object type.</param>
        /// <returns>Object representation of the JSON string.</returns>
        public object Deserialize(IRestResponse response, Type type)
        {
            IList<Parameter> headers = response.Headers;
            if (type == typeof(byte[])) // return byte array
            {
                return response.RawBytes;
            }

            // TODO: ? if (type.IsAssignableFrom(typeof(Stream)))
            if (type == typeof(Stream))
            {
                if (headers != null)
                {
                    string filePath = string.IsNullOrEmpty(Configuration.TempFolderPath) ?
                        Path.GetTempPath() :
                        Configuration.TempFolderPath;
                    Regex regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$");
                    foreach (Parameter header in headers)
                    {
                        Match match = regex.Match(header.ToString());
                        if (match.Success)
                        {
                            string fileName = filePath + SanitizeFilename(match.Groups[1].Value.Replace("\"", "").Replace("'", ""));
                            File.WriteAllBytes(fileName, response.RawBytes);
                            return new FileStream(fileName, FileMode.Open);
                        }
                    }
                }
                MemoryStream stream = new MemoryStream(response.RawBytes);
                return stream;
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a date time object
            {
                return DateTime.Parse(response.Content, null, DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(string) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return ConvertType(response.Content, type);
            }

            // at this point, it must be a model (json)
            try
            {
                return JsonSerializer.Deserialize(response.Content, type, null);//  (response.Content, type, serializerOptions);
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        /// <summary>Check if the given MIME is a JSON MIME.
        ///JSON MIME examples:
        ///    application/json
        ///    application/json; CharSet=UTF8
        ///    APPLICATION/JSON
        ///    application/vnd.company+json
        /// </summary>
        /// <param name="mime">MIME</param>
        /// <returns>Returns True if MIME type is json.</returns>
        public bool IsJsonMime(string mime)
        {
            Regex jsonRegex = new Regex("(?i)^(application/json|[^;/ \t]+/[^;/ \t]+[+]json)[ \t]*(;.*)?$");
            return mime != null && (jsonRegex.IsMatch(mime) || mime.Equals("application/json-patch+json"));
        }

        /// <summary>
        /// Select the Content-Type header's value from the given content-type array:
        /// if JSON type exists in the given array, use it;
        /// otherwise use the first one defined in 'consumes'
        /// </summary>
        /// <param name="contentTypes">The Content-Type array to select from.</param>
        /// <returns>The Content-Type header to use.</returns>
        public string SelectHeaderContentType(string[] contentTypes)
        {
            if (contentTypes.Length == 0)
            {
                return "application/json";
            }

            foreach (string contentType in from string contentType in contentTypes
                                        where IsJsonMime(contentType.ToLower())
                                        select contentType)
            {
                return contentType;
            }

            return contentTypes[0]; // use the first content type specified in 'consumes'
        }

        /// <summary>Select the Accept header's value from the given accepts array: if JSON exists in the given array, use it; otherwise use all of them (joining into a string)</summary>
        /// <param name="accepts">The accepts array to select from.</param>
        /// <returns>The Accept header to use.</returns>
        public string SelectHeaderAccept(string[] accepts)
        {
            return accepts.Length == 0
                ? null
                : accepts.Contains("application/json", StringComparer.OrdinalIgnoreCase) ? "application/json" : string.Join(",", accepts);
        }

        /// <summary>Dynamically cast the object into target type.</summary>
        /// <param name="fromObject">Object to be casted</param>
        /// <param name="toObject">Target type</param>
        /// <returns>Casted object</returns>
        public static dynamic ConvertType(dynamic fromObject, Type toObject)
        {
            return Convert.ChangeType(fromObject, toObject);
        }

        /// <summary>Sanitize filename by removing the path</summary>
        /// <param name="filename">Filename</param>
        /// <returns>Filename</returns>
        public static string SanitizeFilename(string filename)
        {
            Match match = Regex.Match(filename, @".*[/\\](.*)$");
            return match.Success ? match.Groups[1].Value : filename;
        }

        /// <summary>Convert parameters to key/value pairs. Use collectionFormat to properly format lists and collections.</summary>
        /// <param name="collectionFormat">Collection format</param>
        /// <param name="name">Key name.</param>
        /// <param name="value">Value object.</param>
        /// <returns>A list of KeyValuePairs</returns>
        public IEnumerable<KeyValuePair<string, string>> ParameterToKeyValuePairs(string collectionFormat, string name, object value)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            if (IsCollection(value) && collectionFormat == "multi")
            {
                IEnumerable valueCollection = value as IEnumerable;
                parameters.AddRange(from object item in valueCollection select new KeyValuePair<string, string>(name, ParameterToString(item)));
            }
            else
            {
                parameters.Add(new KeyValuePair<string, string>(name, ParameterToString(value)));
            }

            return parameters;
        }

        /// <summary>Check if generic object is a collection.</summary>
        /// <param name="value"></param>
        /// <returns>True if object is a collection type</returns>
        private static bool IsCollection(object value)
        {
            return value is IList || value is ICollection;
        }
    }
}