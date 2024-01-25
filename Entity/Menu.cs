using System;
using System.Collections.Generic;

namespace Entity;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? Description { get; set; }

    public int? IdParentMenu { get; set; }

    public string? Icon { get; set; }

    public string? Controller { get; set; }

    public string? ActionPage { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual Menu? IdParentMenuNavigation { get; set; }

    public virtual ICollection<Menu> InverseIdParentMenuNavigation { get; set; } = new List<Menu>();

    public virtual ICollection<RoleMenu> RoleMenus { get; set; } = new List<RoleMenu>();
}
