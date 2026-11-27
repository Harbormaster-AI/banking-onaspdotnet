
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class BankingProduct : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string ProductCode { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Name { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Description { get; set; }
    public virtual Bank? Bank { get; set; }
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    public virtual ICollection<LoanAccount> LoanAccounts { get; set; } = new List<LoanAccount>();
    public virtual ICollection<PaymentCard> PaymentCards { get; set; } = new List<PaymentCard>();
    public virtual ProductCategory? ProductCategory { get; set; }

    public static BankingProduct FromRequest(BankingProductRequest request)
    {
        return new BankingProduct
        {
            Id = request.Id,
            ProductCode = request.ProductCode,
            Name = request.Name,
            Description = request.Description,
            ProductCategory = request.ProductCategory,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
