
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class ExternalAccount : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Name { get; set; }
    [Required]
    public required virtual IBAN Iban { get; set; }
    [Required]
    public required virtual AccountNumber AccountNumber { get; set; }
    [Required]
    public required virtual BIC Bic { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string BankName { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Country { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public static ExternalAccount FromRequest(ExternalAccountRequest request)
    {
        return new ExternalAccount
        {
            Id = request.Id,
            Name = request.Name,
            Iban = request.Iban,
            AccountNumber = request.AccountNumber,
            Bic = request.Bic,
            BankName = request.BankName,
            Country = request.Country,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
