using System;
using System.Collections.Generic;

namespace Entity;

public partial class Sale
{
    public int IdSale { get; set; }

    public string? SaleNumber { get; set; }

    public int? IdSalesDocumentType { get; set; }

    public int? IdUser { get; set; }

    public string? CustomerDocument { get; set; }

    public string? CustomerName { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? TaxTotal { get; set; }

    public decimal? Total { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual SalesDocumentType? IdSalesDocumentTypeNavigation { get; set; }

    public virtual UserSt? IdUserNavigation { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
