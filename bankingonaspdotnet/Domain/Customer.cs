
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class Customer : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string FirstName { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string LastName { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string LegalName { get; set; }
    [Required]
    public required virtual DateOnly DateOfBirth { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string TaxId { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Email { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Phone { get; set; }
    [Required]
    public required virtual Address Address { get; set; }
    public virtual Bank? Bank { get; set; }
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    public virtual ICollection<LoanAccount> LoanAccounts { get; set; } = new List<LoanAccount>();
    public virtual ICollection<PaymentCard> PaymentCards { get; set; } = new List<PaymentCard>();
    public virtual ICollection<ExternalAccount> ExternalAccounts { get; set; } = new List<ExternalAccount>();
    public virtual ICollection<FundsTransfer> FundsTransfers { get; set; } = new List<FundsTransfer>();
    public virtual ICollection<Dispute> Disputes { get; set; } = new List<Dispute>();
    public virtual ICollection<KycProfile> KycProfiles { get; set; } = new List<KycProfile>();
    public virtual ICollection<Consent> Consents { get; set; } = new List<Consent>();
    public virtual CustomerType? CustomerType { get; set; }
    public virtual RiskRating? RiskRating { get; set; }
    public virtual KycStatus? KycStatus { get; set; }

    public static Customer FromRequest(CustomerRequest request)
    {
        return new Customer
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            LegalName = request.LegalName,
            DateOfBirth = request.DateOfBirth,
            TaxId = request.TaxId,
            Email = request.Email,
            Phone = request.Phone,
            Address = request.Address,
            CustomerType = request.CustomerType,
            RiskRating = request.RiskRating,
            KycStatus = request.KycStatus,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
