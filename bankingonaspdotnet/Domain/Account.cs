
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class Account : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public required virtual AccountNumber AccountNumber { get; set; }
    [Required]
    public required virtual IBAN Iban { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string AccountName { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Currency { get; set; }
    [Required]
    public required virtual DateOnly OpenedOn { get; set; }
    [Required]
    public required virtual DateOnly ClosedOn { get; set; }
    public virtual Bank? Bank { get; set; }
    public virtual Branch? Branch { get; set; }
    public virtual BankingProduct? Product { get; set; }
    public virtual ICollection<Customer> Owners { get; set; } = new List<Customer>();
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public virtual ICollection<AccountStatement> Statements { get; set; } = new List<AccountStatement>();
    public virtual ICollection<StandingInstruction> StandingInstructions { get; set; } = new List<StandingInstruction>();
    public virtual ICollection<FeeCharge> FeeCharges { get; set; } = new List<FeeCharge>();
    public virtual AccountType? AccountType { get; set; }
    public virtual AccountOwnershipType? OwnershipType { get; set; }
    public virtual AccountStatus? Status { get; set; }

    public static Account FromRequest(AccountRequest request)
    {
        return new Account
        {
            Id = request.Id,
            AccountNumber = request.AccountNumber,
            Iban = request.Iban,
            AccountName = request.AccountName,
            Currency = request.Currency,
            OpenedOn = request.OpenedOn,
            ClosedOn = request.ClosedOn,
            AccountType = request.AccountType,
            OwnershipType = request.OwnershipType,
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
