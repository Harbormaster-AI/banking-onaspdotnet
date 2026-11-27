
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class Branch : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Name { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string BranchCode { get; set; }
    [Required]
    public required virtual Address Address { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Phone { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string OpeningHours { get; set; }
    public virtual Bank? Bank { get; set; }
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    public virtual ICollection<LoanAccount> LoanAccounts { get; set; } = new List<LoanAccount>();
    public virtual ICollection<ATM> Atms { get; set; } = new List<ATM>();

    public static Branch FromRequest(BranchRequest request)
    {
        return new Branch
        {
            Id = request.Id,
            Name = request.Name,
            BranchCode = request.BranchCode,
            Address = request.Address,
            Phone = request.Phone,
            OpeningHours = request.OpeningHours,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
