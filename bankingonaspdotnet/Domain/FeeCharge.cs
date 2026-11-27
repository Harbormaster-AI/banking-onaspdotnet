
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class FeeCharge : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string FeeCode { get; set; }
    [Required]
    public required virtual Money Amount { get; set; }
    [Required]
    public required virtual DateOnly AppliedOn { get; set; }
    public virtual Account? Account { get; set; }
    public virtual LoanAccount? LoanAccount { get; set; }
    public virtual FeeType? FeeType { get; set; }

    public static FeeCharge FromRequest(FeeChargeRequest request)
    {
        return new FeeCharge
        {
            Id = request.Id,
            FeeCode = request.FeeCode,
            Amount = request.Amount,
            AppliedOn = request.AppliedOn,
            FeeType = request.FeeType,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
