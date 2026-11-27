
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class Dispute : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string DisputeReference { get; set; }
    [Required]
    public required virtual DateOnly RaisedOn { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Reason { get; set; }
    public virtual Transaction? Transaction { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Account? Account { get; set; }
    public virtual PaymentCard? PaymentCard { get; set; }
    public virtual DisputeStatus? Status { get; set; }

    public static Dispute FromRequest(DisputeRequest request)
    {
        return new Dispute
        {
            Id = request.Id,
            DisputeReference = request.DisputeReference,
            RaisedOn = request.RaisedOn,
            Reason = request.Reason,
            Status = request.Status,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
