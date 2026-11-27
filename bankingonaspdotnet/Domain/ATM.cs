
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class ATM : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string TerminalId { get; set; }
    [Required]
    public required virtual Address Location { get; set; }
    public virtual Branch? Branch { get; set; }
    public virtual ATMStatus? Status { get; set; }

    public static ATM FromRequest(ATMRequest request)
    {
        return new ATM
        {
            Id = request.Id,
            TerminalId = request.TerminalId,
            Location = request.Location,
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
