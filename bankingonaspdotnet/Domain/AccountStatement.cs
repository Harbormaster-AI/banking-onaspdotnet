
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class AccountStatement : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string StatementNumber { get; set; }
    [Required]
    public required virtual DateOnly PeriodStart { get; set; }
    [Required]
    public required virtual DateOnly PeriodEnd { get; set; }
    [Required]
    public required virtual Money OpeningBalance { get; set; }
    [Required]
    public required virtual Money ClosingBalance { get; set; }
    public virtual Account? Account { get; set; }
    public virtual StatementDeliveryMethod? DeliveryMethod { get; set; }

    public static AccountStatement FromRequest(AccountStatementRequest request)
    {
        return new AccountStatement
        {
            Id = request.Id,
            StatementNumber = request.StatementNumber,
            PeriodStart = request.PeriodStart,
            PeriodEnd = request.PeriodEnd,
            OpeningBalance = request.OpeningBalance,
            ClosingBalance = request.ClosingBalance,
            DeliveryMethod = request.DeliveryMethod,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
