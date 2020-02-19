using InternetWideWorld.CryptoLadder.Shared.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace InternetWideWorld.CryptoLadder.MobileApi.Domain
{
    public class LadderOrder : OrderRequest, IValidatableObject
    {
        /// <summary>Number of ladder rungs.</summary>
        [Required]
        [Range(2, 100, ErrorMessage = "{0} must be between {2} and {1}.")]
        public int Rungs { get; set; }

        /// <summary>Ladder ending price.</summary>
        [Required]
        [Range(0.0001, 1000000, ErrorMessage = "{0} must be in the range of {2} to {1}.")]
        public double EndPrice { get; set; }

        /// <summary>Custom validation of the ladder order object.</summary>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (ValidationResult result in base.Validate(validationContext).ToList())
            {
                yield return result;
            }


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