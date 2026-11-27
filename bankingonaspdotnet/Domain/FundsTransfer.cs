
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class FundsTransfer : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string TransferReference { get; set; }
    [Required]
    public required virtual Money Amount { get; set; }
    [Required]
    public required virtual DateOnly RequestedDate { get; set; }
    [Required]
    public required virtual DateOnly ExecutionDate { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Purpose { get; set; }
    [Required]
    public required virtual Money FeeAmount { get; set; }
    public virtual Account? SourceAccount { get; set; }
    public virtual Account? DestinationAccount { get; set; }
    public virtual ExternalAccount? ExternalBeneficiary { get; set; }
    public virtual Customer? InitiatedBy { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public virtual PaymentMethod? Method { get; set; }
    public virtual PaymentStatus? Status { get; set; }

    public static FundsTransfer FromRequest(FundsTransferRequest request)
    {
        return new FundsTransfer
        {
            Id = request.Id,
            TransferReference = request.TransferReference,
            Amount = request.Amount,
            RequestedDate = request.RequestedDate,
            ExecutionDate = request.ExecutionDate,
            Purpose = request.Purpose,
            FeeAmount = request.FeeAmount,
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
