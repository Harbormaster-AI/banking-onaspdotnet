
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class LoanPayment : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string PaymentReference { get; set; }
    [Required]
    public required virtual Money Amount { get; set; }
    [Required]
    public required virtual DateOnly PaymentDate { get; set; }
    public virtual LoanAccount? LoanAccount { get; set; }
    public virtual Transaction? Transaction { get; set; }
    public virtual PaymentMethod? Method { get; set; }
    public virtual PaymentStatus? Status { get; set; }

    public static LoanPayment FromRequest(LoanPaymentRequest request)
    {
        return new LoanPayment
        {
            Id = request.Id,
            PaymentReference = request.PaymentReference,
            Amount = request.Amount,
            PaymentDate = request.PaymentDate,
            Method = request.Method,
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
