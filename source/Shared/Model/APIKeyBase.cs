using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InternetWideWorld.CryptoLadder.Shared.Model
{
    /// <summary>
    /// Get ByBit server time.
    /// </summary>
    [DataContract]
    public partial class APIKeyBase : IEquatable<APIKeyBase>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIKeyBase" /> class.
        /// </summary>
        public APIKeyBase()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="APIKeyBase" /> class.
        /// </summary>
        /// <param name="retCode">retCode.</param>
        /// <param name="retMsg">retMsg.</param>
        /// <param name="extCode">extCode.</param>
        /// <param name="extInfo">extInfo.</param>
        /// <param name="result">result.</param>
        /// <param name="timeNow">timeNow.</param>
        public APIKeyBase(decimal? retCode = default, string retMsg = default, string extCode = default, string extInfo = default, List<APIKeyInfo> result = default, string timeNow = default)
        {
            RetCode = retCode;
            RetMsg = retMsg;
            ExtCode = extCode;
            ExtInfo = extInfo;
            Result = result;
            TimeNow = timeNow;
        }

        /// <summary>
        /// Gets or Sets RetCode
        /// </summary>
        [DataMember(Name = "ret_code", EmitDefaultValue = false)]
        [JsonPropertyName("ret_code")]
        public decimal? RetCode { get; set; }

        /// <summary>
        /// Gets or Sets RetMsg
        /// </summary>
        [DataMember(Name = "ret_msg", EmitDefaultValue = false)]
        [JsonPropertyName("ret_msg")]
        public string RetMsg { get; set; }

        /// <summary>
        /// Gets or Sets ExtCode
        /// </summary>
        [JsonPropertyName("ext_code")]
        [DataMember(Name = "ext_code", EmitDefaultValue = false)]
        public string ExtCode { get; set; }

        /// <summary>
        /// Gets or Sets ExtInfo
        /// </summary>
        [JsonPropertyName("ext_info")]
        [DataMember(Name = "ext_info", EmitDefaultValue = false)]
        public string ExtInfo { get; set; }

        /// <summary>
        /// Gets or Sets Result
        /// </summary>
        [JsonPropertyName("result")]
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public List<APIKeyInfo> Result { get; set; }

        /// <summary>
        /// Gets or Sets TimeNow
        /// </summary>
        [JsonPropertyName("time_now")]
        [DataMember(Name = "time_now", EmitDefaultValue = false)]
        public string TimeNow { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class APIKeyBase {\n");
            sb.Append("  RetCode: ").Append(RetCode).Append("\n");
            sb.Append("  RetMsg: ").Append(RetMsg).Append("\n");
            sb.Append("  ExtCode: ").Append(ExtCode).Append("\n");
            sb.Append("  ExtInfo: ").Append(ExtInfo).Append("\n");
            sb.Append("  Result: ").Append(Result).Append("\n");
            sb.Append("  TimeNow: ").Append(TimeNow).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as APIKeyBase);
        }

        /// <summary>
        /// Returns true if APIKeyBase instances are equal
        /// </summary>
        /// <param name="input">Instance of APIKeyBase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(APIKeyBase input)
        {
            if (input == null)
            {
                return false;
            }

            return
                (
                    RetCode == input.RetCode ||
                    (RetCode != null &&
                    RetCode.Equals(input.RetCode))
                ) &&
                (
                    RetMsg == input.RetMsg ||
                    (RetMsg != null &&
                    RetMsg.Equals(input.RetMsg))
                ) &&
                (
                    ExtCode == input.ExtCode ||
                    (ExtCode != null &&
                    ExtCode.Equals(input.ExtCode))
                ) &&
                (
                    ExtInfo == input.ExtInfo ||
                    (ExtInfo != null &&
                    ExtInfo.Equals(input.ExtInfo))
                ) &&
                (
                    Result == input.Result ||
                    Result != null &&
                    Result.SequenceEqual(input.Result)
                ) &&
                (
                    TimeNow == input.TimeNow ||
                    (TimeNow != null &&
                    TimeNow.Equals(input.TimeNow))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (RetCode != null)
                {
                    hashCode = hashCode * 59 + RetCode.GetHashCode();
                }

                if (RetMsg != null)
                {
                    hashCode = hashCode * 59 + RetMsg.GetHashCode();
                }

                if (ExtCode != null)
                {
                    hashCode = hashCode * 59 + ExtCode.GetHashCode();
                }

                if (ExtInfo != null)
                {
                    hashCode = hashCode * 59 + ExtInfo.GetHashCode();
                }

                if (Result != null)
                {
                    hashCode = hashCode * 59 + Result.GetHashCode();
                }

                if (TimeNow != null)
                {
                    hashCode = hashCode * 59 + TimeNow.GetHashCode();
                }

                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
