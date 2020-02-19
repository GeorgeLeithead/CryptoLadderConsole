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
    public partial class APIKeyInfo : IEquatable<APIKeyInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIKeyInfo" /> class.
        /// </summary>
        public APIKeyInfo()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="APIKeyInfo" /> class.
        /// </summary>
        /// <param name="apiKey">apiKey.</param>
        /// <param name="userId">userId.</param>
        /// <param name="ips">IPS.</param>
        /// <param name="note">note.</param>
        /// <param name="permissions">permissions.</param>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="readOnly">readOnly.</param>
        public APIKeyInfo(string apiKey = default, decimal? userId = default, List<string> ips = default, string note = default, List<string> permissions = default, string createdAt = default, bool? readOnly = default)
        {
            ApiKey = apiKey;
            UserId = userId;
            Ips = ips;
            Note = note;
            Permissions = permissions;
            CreatedAt = createdAt;
            ReadOnly = readOnly;
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
        /// Gets or Sets IPS
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
            StringBuilder sb = new StringBuilder();
            sb.Append("class APIKeyInfo {\n");
            sb.Append("  ApiKey: ").Append(ApiKey).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  IPS: ").Append(Ips).Append("\n");
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
            return Equals(input as APIKeyInfo);
        }

        /// <summary>
        /// Returns true if APIKeyInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of APIKeyInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(APIKeyInfo input)
        {
            if (input == null)
            {
                return false;
            }

            return
                (
                    ApiKey == input.ApiKey ||
                    (ApiKey != null &&
                    ApiKey.Equals(input.ApiKey))
                ) &&
                (
                    UserId == input.UserId ||
                    (UserId != null &&
                    UserId.Equals(input.UserId))
                ) &&
                (
                    Ips == input.Ips ||
                    Ips != null &&
                    Ips.SequenceEqual(input.Ips)
                ) &&
                (
                    Note == input.Note ||
                    (Note != null &&
                    Note.Equals(input.Note))
                ) &&
                (
                    Permissions == input.Permissions ||
                    Permissions != null &&
                    Permissions.SequenceEqual(input.Permissions)
                ) &&
                (
                    CreatedAt == input.CreatedAt ||
                    (CreatedAt != null &&
                    CreatedAt.Equals(input.CreatedAt))
                ) &&
                (
                    ReadOnly == input.ReadOnly ||
                    (ReadOnly != null &&
                    ReadOnly.Equals(input.ReadOnly))
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
                if (ApiKey != null)
                {
                    hashCode = hashCode * 59 + ApiKey.GetHashCode();
                }

                if (UserId != null)
                {
                    hashCode = hashCode * 59 + UserId.GetHashCode();
                }

                if (Ips != null)
                {
                    hashCode = hashCode * 59 + Ips.GetHashCode();
                }

                if (Note != null)
                {
                    hashCode = hashCode * 59 + Note.GetHashCode();
                }

                if (Permissions != null)
                {
                    hashCode = hashCode * 59 + Permissions.GetHashCode();
                }

                if (CreatedAt != null)
                {
                    hashCode = hashCode * 59 + CreatedAt.GetHashCode();
                }

                if (ReadOnly != null)
                {
                    hashCode = hashCode * 59 + ReadOnly.GetHashCode();
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
