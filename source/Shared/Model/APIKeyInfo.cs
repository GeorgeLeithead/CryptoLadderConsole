using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InternetWideWorld.CryptoLadder.Shared.Model
{
    /// <summary>
    /// Get bybit server time.
    /// </summary>
    [DataContract]
    public partial class APIKeyInfo : IEquatable<APIKeyInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIKeyInfo" /> class.
        /// </summary>
        public APIKeyInfo()
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="APIKeyInfo" /> class.
        /// </summary>
        /// <param name="apiKey">apiKey.</param>
        /// <param name="userId">userId.</param>
        /// <param name="ips">ips.</param>
        /// <param name="note">note.</param>
        /// <param name="permissions">permissions.</param>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="readOnly">readOnly.</param>
        public APIKeyInfo(string apiKey = default(string), decimal? userId = default(decimal?), List<string> ips = default(List<string>), string note = default(string), List<string> permissions = default(List<string>), string createdAt = default(string), bool? readOnly = default(bool?))
        {
            this.ApiKey = apiKey;
            this.UserId = userId;
            this.Ips = ips;
            this.Note = note;
            this.Permissions = permissions;
            this.CreatedAt = createdAt;
            this.ReadOnly = readOnly;
        }

        /// <summary>
        /// Gets or Sets ApiKey
        /// </summary>
        [JsonPropertyName("api_key")]
        [DataMember(Name = "api_key", EmitDefaultValue = false)]
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [JsonPropertyName("user_id")]
        [DataMember(Name = "user_id", EmitDefaultValue = false)]
        public decimal? UserId { get; set; }

        /// <summary>
        /// Gets or Sets Ips
        /// </summary>
        [JsonPropertyName("ips")]
        [DataMember(Name = "ips", EmitDefaultValue = false)]
        public List<string> Ips { get; set; }

        /// <summary>
        /// Gets or Sets Note
        /// </summary>
        [JsonPropertyName("note")]
        [DataMember(Name = "note", EmitDefaultValue = false)]
        public string Note { get; set; }

        /// <summary>
        /// Gets or Sets Permissions
        /// </summary>
        [JsonPropertyName("permissions")]
        [DataMember(Name = "permissions", EmitDefaultValue = false)]
        public List<string> Permissions { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [JsonPropertyName("created_at")]
        [DataMember(Name = "created_at", EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets ReadOnly
        /// </summary>
        [JsonPropertyName("read_only")]
        [DataMember(Name = "read_only", EmitDefaultValue = false)]
        public bool? ReadOnly { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class APIKeyInfo {\n");
            sb.Append("  ApiKey: ").Append(ApiKey).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  Ips: ").Append(Ips).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  Permissions: ").Append(Permissions).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  ReadOnly: ").Append(ReadOnly).Append("\n");
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
            return this.Equals(input as APIKeyInfo);
        }

        /// <summary>
        /// Returns true if APIKeyInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of APIKeyInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(APIKeyInfo input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ApiKey == input.ApiKey ||
                    (this.ApiKey != null &&
                    this.ApiKey.Equals(input.ApiKey))
                ) &&
                (
                    this.UserId == input.UserId ||
                    (this.UserId != null &&
                    this.UserId.Equals(input.UserId))
                ) &&
                (
                    this.Ips == input.Ips ||
                    this.Ips != null &&
                    this.Ips.SequenceEqual(input.Ips)
                ) &&
                (
                    this.Note == input.Note ||
                    (this.Note != null &&
                    this.Note.Equals(input.Note))
                ) &&
                (
                    this.Permissions == input.Permissions ||
                    this.Permissions != null &&
                    this.Permissions.SequenceEqual(input.Permissions)
                ) &&
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) &&
                (
                    this.ReadOnly == input.ReadOnly ||
                    (this.ReadOnly != null &&
                    this.ReadOnly.Equals(input.ReadOnly))
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
                if (this.ApiKey != null)
                    hashCode = hashCode * 59 + this.ApiKey.GetHashCode();
                if (this.UserId != null)
                    hashCode = hashCode * 59 + this.UserId.GetHashCode();
                if (this.Ips != null)
                    hashCode = hashCode * 59 + this.Ips.GetHashCode();
                if (this.Note != null)
                    hashCode = hashCode * 59 + this.Note.GetHashCode();
                if (this.Permissions != null)
                    hashCode = hashCode * 59 + this.Permissions.GetHashCode();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
                if (this.ReadOnly != null)
                    hashCode = hashCode * 59 + this.ReadOnly.GetHashCode();
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
