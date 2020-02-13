using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using InternetWideWorld.CryptoLadder.Shared.Definitions;

namespace InternetWideWorld.CryptoLadder.MobileApi.Domain
{
    public class LadderOrder : Signature, IValidatableObject
    {
        /// <summary>Order currency.</summary>
        [Required]
        [StringLength(3, MinimumLength=3, ErrorMessage = "{0} must be between {2} and {1} in length.")]
        public string Currency { get; set; }

        /// <summary>Number of ladder rungs.</summary>
        [Required]
        [Range(2, 99, ErrorMessage = "{0} must be between {2} and {1}.")]
        public int Rungs { get; set; }

        /// <summary>Ladder starting price.</summary>
        [Required]
        [Range(0.0001, 1000000, ErrorMessage = "{0} must be in the range of {2} to {1}.")]
        public decimal StartPrice { get; set; }

        /// <summary>Ladder ending price.</summary>
        [Required]
        [Range(0.0001, 1000000, ErrorMessage = "{0} must be in the range of {2} to {1}.")]
        public decimal EndPrice { get; set; }

        /// <summary>Order quantity.</summary>
        [Required]
        [Range(1, 100000000, ErrorMessage = "{0} must be in the range of {2} to {1}.")]
        public int Quantity { get; set; }

        /// <summary>Custom validation of the ladder order object.</summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartPrice == EndPrice)
            {
                yield return new ValidationResult(
                    $"Start price '{StartPrice}' must not be the same as end price '{EndPrice}'",
                    new[] { nameof(StartPrice), nameof(EndPrice) }
                );
            }

            if (Enum.GetValues(typeof(CurrencyEnum)).Cast<CurrencyEnum?>().FirstOrDefault(c => c.ToString().ToUpperInvariant() == Currency.ToUpperInvariant()) == null)
            {
                yield return new ValidationResult(
                    $"Currency '{Currency}' is not a valid currency symbol.",
                    new[] { nameof(Currency) }
                );
            }
        }
    }
}