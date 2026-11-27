
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class IdentityDocument : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string DocumentNumber { get; set; }
    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string IssuingCountry { get; set; }
    [Required]
    public required virtual DateOnly ExpirationDate { get; set; }
    public virtual KycProfile? KycProfile { get; set; }
    public virtual IdentityDocumentType? DocumentType { get; set; }

    public static IdentityDocument FromRequest(IdentityDocumentRequest request)
    {
        return new IdentityDocument
        {
            Id = request.Id,
            DocumentNumber = request.DocumentNumber,
            IssuingCountry = request.IssuingCountry,
            ExpirationDate = request.ExpirationDate,
            DocumentType = request.DocumentType,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
