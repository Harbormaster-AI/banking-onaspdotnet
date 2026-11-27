
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class Consent : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public required virtual DateOnly GrantedOn { get; set; }
    [Required]
    public required virtual DateOnly ExpiresOn { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Bank? Bank { get; set; }
    public virtual ICollection<Account> AuthorizedAccounts { get; set; } = new List<Account>();
    public virtual ThirdPartyProvider? ThirdPartyProvider { get; set; }
    public virtual ConsentType? ConsentType { get; set; }
    public virtual ConsentStatus? Status { get; set; }

    public static Consent FromRequest(ConsentRequest request)
    {
        return new Consent
        {
            Id = request.Id,
            GrantedOn = request.GrantedOn,
            ExpiresOn = request.ExpiresOn,
            ConsentType = request.ConsentType,
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
