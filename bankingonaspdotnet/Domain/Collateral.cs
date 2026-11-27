
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class Collateral : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string CollateralIdentifier { get; set; }
    [Required]
    public required virtual Money AppraisedValue { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Description { get; set; }
    [Required]
    public required virtual Address Location { get; set; }
    public virtual LoanAccount? LoanAccount { get; set; }
    public virtual CollateralType? CollateralType { get; set; }

    public static Collateral FromRequest(CollateralRequest request)
    {
        return new Collateral
        {
            Id = request.Id,
            CollateralIdentifier = request.CollateralIdentifier,
            AppraisedValue = request.AppraisedValue,
            Description = request.Description,
            Location = request.Location,
            CollateralType = request.CollateralType,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
