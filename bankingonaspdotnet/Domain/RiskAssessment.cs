
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class RiskAssessment : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public required virtual int Score { get; set; }
    [Required]
    public required virtual DateOnly AssessedOn { get; set; }
    public virtual KycProfile? KycProfile { get; set; }
    public virtual RiskRating? Rating { get; set; }

    public static RiskAssessment FromRequest(RiskAssessmentRequest request)
    {
        return new RiskAssessment
        {
            Id = request.Id,
            Score = request.Score,
            AssessedOn = request.AssessedOn,
            Rating = request.Rating,
        };
    }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        // TODO: Add custom business validation rules here.

        yield break;
    }
}
