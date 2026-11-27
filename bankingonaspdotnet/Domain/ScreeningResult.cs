
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class ScreeningResult : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public required virtual DateOnly ScreeningDate { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Provider { get; set; }
    public virtual KycProfile? KycProfile { get; set; }
    public virtual ScreeningOutcome? Outcome { get; set; }

    public static ScreeningResult FromRequest(ScreeningResultRequest request)
    {
        return new ScreeningResult
        {
            Id = request.Id,
            ScreeningDate = request.ScreeningDate,
            Provider = request.Provider,
            Outcome = request.Outcome,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
