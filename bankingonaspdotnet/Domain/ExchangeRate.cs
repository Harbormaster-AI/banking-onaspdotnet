
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class ExchangeRate : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string BaseCurrency { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string CounterCurrency { get; set; }
    [Required]
    public required virtual decimal Rate { get; set; }
    [Required]
    public required virtual DateOnly AsOf { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Source { get; set; }
    public virtual Bank? Bank { get; set; }
    public virtual ICollection<FXTrade> FxTrades { get; set; } = new List<FXTrade>();

    public static ExchangeRate FromRequest(ExchangeRateRequest request)
    {
        return new ExchangeRate
        {
            Id = request.Id,
            BaseCurrency = request.BaseCurrency,
            CounterCurrency = request.CounterCurrency,
            Rate = request.Rate,
            AsOf = request.AsOf,
            Source = request.Source,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
