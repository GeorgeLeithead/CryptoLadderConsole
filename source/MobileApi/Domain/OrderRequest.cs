
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using InternetWideWorld.CryptoLadder.Shared.Definitions;

namespace InternetWideWorld.CryptoLadder.MobileApi.Domain
{
    public class OrderRequest : Signature, IValidatableObject
    {
        private string currency;
        private string side;

        /// <summary>Order currency.</summary>
        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} in length.")]
        public string Currency
        {
            get => currency;
            set
            {
                currency = value;
                try
                {
                    Symbol = Enum.GetValues(typeof(SymbolEnum)).Cast<SymbolEnum>().First(a => a.ToString().StartsWith(value.ToUpperInvariant()));
                }
                catch { }
            }
        }

        /// <summary>Order currency symbol.</summary>
        public SymbolEnum? Symbol { get; set; }

        /// <summary>Order side.</summary>
        [Required]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} in length.")]
        public string Side
        {
            get => side;
            set
            {
                side = value;
                try
                {
                    OrderSide = Enum.GetValues(typeof(SideEnum)).Cast<SideEnum>().First(s => s.ToString().ToUpperInvariant() == Side.ToUpperInvariant());
                }
                catch { }
            }
        }

        /// <summary>Order side.</summary>
        public SideEnum? OrderSide { get; set; }

        /// <summary>Order price.</summary>
        [Required]
        [Range(0.0001, 1000000, ErrorMessage = "{0} must be in the range of {2} to {1}.")]
        public double StartPrice { get; set; }

        /// <summary>Order quantity.</summary>
        [Required]
        [Range(1, 100000000, ErrorMessage = "{0} must be in the range of {2} to {1}.")]
        public int Quantity { get; set; }

        /// <summary>Custom validation of the ladder order object.</summary>
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Symbol == null)
            {
                yield return new ValidationResult(
                    $"Currency '{Currency}' is not a valid currency symbol.",
                    new[] { nameof(Currency) }
                );
            }

            if (OrderSide == null)
            {
                yield return new ValidationResult(
                    $"Order side '{Side}' is not a valid side.",
                    new[] { nameof(Side) }
                );
            }
        }
    }
}