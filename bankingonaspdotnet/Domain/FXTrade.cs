
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using bankingonaspdotnet.Contracts;

namespace bankingonaspdotnet.Domain;

public class FXTrade : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Length(0, int.MaxValue)]
    public required virtual string TradeReference { get; set; }
    [Required]
    public required virtual DateOnly TradeDate { get; set; }
    [Required]
    public required virtual DateOnly SettlementDate { get; set; }
    [Required]
    public required virtual Money AmountSold { get; set; }
    [Required]
    public required virtual Money AmountBought { get; set; }
    [Required]
    public required virtual decimal Rate { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Bank? Bank { get; set; }
    public virtual ExchangeRate? ExchangeRate { get; set; }
    public virtual Account? SourceAccount { get; set; }
    public virtual Account? DestinationAccount { get; set; }
    public virtual Transaction? Transaction { get; set; }
    public virtual TradeStatus? Status { get; set; }

    public static FXTrade FromRequest(FXTradeRequest request)
    {
        return new FXTrade
        {
            Id = request.Id,
            TradeReference = request.TradeReference,
            TradeDate = request.TradeDate,
            SettlementDate = request.SettlementDate,
            AmountSold = request.AmountSold,
            AmountBought = request.AmountBought,
            Rate = request.Rate,
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
