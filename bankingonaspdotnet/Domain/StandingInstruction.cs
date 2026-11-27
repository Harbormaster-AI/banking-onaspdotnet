
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class StandingInstruction : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string InstructionId { get; set; }
    [Required]
    public required virtual Money Amount { get; set; }
    [Required]
    public required virtual DateOnly NextExecutionDate { get; set; }
    public virtual Account? Account { get; set; }
    public virtual ExternalAccount? Beneficiary { get; set; }
    public virtual StandingInstructionFrequency? Frequency { get; set; }
    public virtual StandingInstructionStatus? Status { get; set; }

    public static StandingInstruction FromRequest(StandingInstructionRequest request)
    {
        return new StandingInstruction
        {
            Id = request.Id,
            InstructionId = request.InstructionId,
            Amount = request.Amount,
            NextExecutionDate = request.NextExecutionDate,
            Frequency = request.Frequency,
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
