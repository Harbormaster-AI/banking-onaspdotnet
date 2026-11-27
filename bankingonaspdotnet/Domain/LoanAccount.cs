
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class LoanAccount : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string LoanNumber { get; set; }
    [Required]
    public required virtual Money PrincipalAmount { get; set; }
    [Required]
    public required virtual Money OutstandingPrincipal { get; set; }
    [Required]
    public required virtual Percentage InterestRate { get; set; }
    [Required]
    public required virtual DateOnly OriginationDate { get; set; }
    [Required]
    public required virtual DateOnly MaturityDate { get; set; }
    [Required]
    public required virtual int PaymentDayOfMonth { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Currency { get; set; }
    public virtual Bank? Bank { get; set; }
    public virtual Branch? Branch { get; set; }
    public virtual BankingProduct? Product { get; set; }
    public virtual ICollection<Customer> Borrowers { get; set; } = new List<Customer>();
    public virtual ICollection<RepaymentSchedule> RepaymentSchedule { get; set; } = new List<RepaymentSchedule>();
    public virtual ICollection<LoanPayment> Payments { get; set; } = new List<LoanPayment>();
    public virtual ICollection<Collateral> Collateral { get; set; } = new List<Collateral>();
    public virtual ICollection<FeeCharge> FeeCharges { get; set; } = new List<FeeCharge>();
    public virtual LoanType? LoanType { get; set; }
    public virtual RateType? RateType { get; set; }
    public virtual InterestCompounding? Compounding { get; set; }
    public virtual LoanStatus? Status { get; set; }

    public static LoanAccount FromRequest(LoanAccountRequest request)
    {
        return new LoanAccount
        {
            Id = request.Id,
            LoanNumber = request.LoanNumber,
            PrincipalAmount = request.PrincipalAmount,
            OutstandingPrincipal = request.OutstandingPrincipal,
            InterestRate = request.InterestRate,
            OriginationDate = request.OriginationDate,
            MaturityDate = request.MaturityDate,
            PaymentDayOfMonth = request.PaymentDayOfMonth,
            Currency = request.Currency,
            LoanType = request.LoanType,
            RateType = request.RateType,
            Compounding = request.Compounding,
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
