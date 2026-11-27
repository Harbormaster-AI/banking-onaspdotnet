
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class ThirdPartyProvider : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Name { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string RegistrationId { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string Website { get; set; }
    public virtual Bank? Bank { get; set; }
    public virtual ICollection<Consent> Consents { get; set; } = new List<Consent>();

    public static ThirdPartyProvider FromRequest(ThirdPartyProviderRequest request)
    {
        return new ThirdPartyProvider
        {
            Id = request.Id,
            Name = request.Name,
            RegistrationId = request.RegistrationId,
            Website = request.Website,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
