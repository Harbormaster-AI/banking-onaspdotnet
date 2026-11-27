
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class Transaction : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public required virtual DateOnly BookingDate { get; set; }
    [Required]
    public required virtual DateOnly ValueDate { get; set; }
    [Required]
    public required virtual Money Amount { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Description { get; set; }
    public virtual Account? Account { get; set; }
    public virtual ExternalAccount? ExternalCounterparty { get; set; }
    public virtual PaymentCard? PaymentCard { get; set; }
    public virtual FundsTransfer? FundsTransfer { get; set; }
    public virtual FXTrade? FxTrade { get; set; }
    public virtual Dispute? Dispute { get; set; }
    public virtual TransactionDirection? Direction { get; set; }
    public virtual TransactionType? TransactionType { get; set; }
    public virtual TransactionStatus? Status { get; set; }
    public virtual ChannelType? Channel { get; set; }

    public static Transaction FromRequest(TransactionRequest request)
    {
        return new Transaction
        {
            Id = request.Id,
            BookingDate = request.BookingDate,
            ValueDate = request.ValueDate,
            Amount = request.Amount,
            Description = request.Description,
            Direction = request.Direction,
            TransactionType = request.TransactionType,
            Status = request.Status,
            Channel = request.Channel,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
