using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InternetWideWorld.CryptoLadder.Shared.Model
{
    /// <summary>
    /// Place new order response
    /// </summary>
    [DataContract]
    public partial class OrderResBase : IEquatable<OrderResBase>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderResBase" /> class.
        /// </summary>
        public OrderResBase()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderResBase" /> class.
        /// </summary>
        /// <param name="retCode">retCode.</param>
        /// <param name="retMsg">retMsg.</param>
        /// <param name="extCode">extCode.</param>
        /// <param name="extInfo">extInfo.</param>
        /// <param name="result">result.</param>
        /// <param name="timeNow">timeNow.</param>
        public OrderResBase(decimal? retCode = default(decimal?), string retMsg = default(string), string extCode = default(string), string extInfo = default(string), OrderRes result = default(OrderRes), string timeNow = default(string))
        {
            this.RetCode = retCode;
            this.RetMsg = retMsg;
            this.ExtCode = extCode;
            this.ExtInfo = extInfo;
            this.Result = result;
            this.TimeNow = timeNow;
        }

        /// <summary>
        /// Gets or Sets RetCode
        /// </summary>
        [JsonPropertyName("ret_code")]
        [DataMember(Name = "ret_code", EmitDefaultValue = false)]
        public decimal? RetCode { get; set; }

        /// <summary>
        /// Gets or Sets RetMsg
        /// </summary>
        [JsonPropertyName("ret_msg")]
        [DataMember(Name = "ret_msg", EmitDefaultValue = false)]
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
        public OrderRes Result { get; set; }

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
            var sb = new StringBuilder();
            sb.Append("class OrderResBase {\n");
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
            return this.Equals(input as OrderResBase);
        }

        /// <summary>
        /// Returns true if OrderResBase instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderResBase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderResBase input)
        {
            if (input == null)
                return false;

            return (
                this.RetCode == input.RetCode ||
                (this.RetCode != null &&
                    this.RetCode.Equals(input.RetCode))
            ) &&
            (
                this.RetMsg == input.RetMsg ||
                (this.RetMsg != null &&
                    this.RetMsg.Equals(input.RetMsg))
            ) &&
            (
                this.ExtCode == input.ExtCode ||
                (this.ExtCode != null &&
                    this.ExtCode.Equals(input.ExtCode))
            ) &&
            (
                this.ExtInfo == input.ExtInfo ||
                (this.ExtInfo != null &&
                    this.ExtInfo.Equals(input.ExtInfo))
            ) &&
            (
                this.Result == input.Result ||
                (this.Result != null &&
                    this.Result.Equals(input.Result))
            ) &&
            (
                this.TimeNow == input.TimeNow ||
                (this.TimeNow != null &&
                    this.TimeNow.Equals(input.TimeNow))
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
                if (this.RetCode != null)
                    hashCode = hashCode * 59 + this.RetCode.GetHashCode();
                if (this.RetMsg != null)
                    hashCode = hashCode * 59 + this.RetMsg.GetHashCode();
                if (this.ExtCode != null)
                    hashCode = hashCode * 59 + this.ExtCode.GetHashCode();
                if (this.ExtInfo != null)
                    hashCode = hashCode * 59 + this.ExtInfo.GetHashCode();
                if (this.Result != null)
                    hashCode = hashCode * 59 + this.Result.GetHashCode();
                if (this.TimeNow != null)
                    hashCode = hashCode * 59 + this.TimeNow.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}