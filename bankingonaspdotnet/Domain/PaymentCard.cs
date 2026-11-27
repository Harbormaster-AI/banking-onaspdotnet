
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class PaymentCard : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public required virtual CardPAN CardNumber { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string EmbossedName { get; set; }
    [Required]
    public required virtual int ExpiryMonth { get; set; }
    [Required]
    public required virtual int ExpiryYear { get; set; }
    public virtual Bank? Bank { get; set; }
    public virtual Account? Account { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public virtual CardType? CardType { get; set; }
    public virtual CardStatus? CardStatus { get; set; }
    public virtual CardNetwork? Network { get; set; }

    public static PaymentCard FromRequest(PaymentCardRequest request)
    {
        return new PaymentCard
        {
            Id = request.Id,
            CardNumber = request.CardNumber,
            EmbossedName = request.EmbossedName,
            ExpiryMonth = request.ExpiryMonth,
            ExpiryYear = request.ExpiryYear,
            CardType = request.CardType,
            CardStatus = request.CardStatus,
            Network = request.Network,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
