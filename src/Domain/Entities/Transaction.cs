﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Connectlime.Domain.Entities;

public class Transaction : BaseAuditableEntity
{
    public int CompanyId { get; init; }
    public int PersonId { get; init; }
    public string? ProductId { get; init; }

    [Column(TypeName = "decimal(9,4)")]
    public decimal UnitPrice { get; init; }

    public int Quantity { get; init; }

    [Column(TypeName = "decimal(9,4)")]
    public decimal CompanyTax { get; init; }

    [Column(TypeName = "decimal(9,4)")]
    public decimal PersonTax { get; init; }

    public Company Company { get; set; } = null!;

    public Person Person { get; set; } = null!;
}
