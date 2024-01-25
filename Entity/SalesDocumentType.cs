using System;
using System.Collections.Generic;

namespace Entity;

public partial class SalesDocumentType
{
    public int IdSalesDocumentType { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
