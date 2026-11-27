
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class RepaymentSchedule : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public required virtual int InstallmentNumber { get; set; }
    [Required]
    public required virtual DateOnly DueDate { get; set; }
    [Required]
    public required virtual Money PrincipalDue { get; set; }
    [Required]
    public required virtual Money InterestDue { get; set; }
    [Required]
    public required virtual Money TotalDue { get; set; }
    public virtual LoanAccount? LoanAccount { get; set; }
    public virtual LoanPayment? Payment { get; set; }
    public virtual InstallmentStatus? Status { get; set; }

    public static RepaymentSchedule FromRequest(RepaymentScheduleRequest request)
    {
        return new RepaymentSchedule
        {
            Id = request.Id,
            InstallmentNumber = request.InstallmentNumber,
            DueDate = request.DueDate,
            PrincipalDue = request.PrincipalDue,
            InterestDue = request.InterestDue,
            TotalDue = request.TotalDue,
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
