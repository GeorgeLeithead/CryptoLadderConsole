using System.ComponentModel.DataAnnotations;

namespace InternetWideWorld.CryptoLadder.MobileApi.Domain
{
    /// <summary>API signature domain model.</summary>
    public class Signature
    {
        /// <summary>Use the MainNet network; otherwise TestNet</summary>
        [Required]
        public bool MainNet { get; set; }

        /// <summary>Users API key</summary>
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} must be valid and length must be between {2} and {1}.")]
        public string ApiKey { get; set; }

        /// <summary>Users API signing key.</summary>
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} must be valid and length must be between {2} and {1}.")]
        public string Sign { get; set; }

        public System.Uri Network { get; set; }
    }
}
