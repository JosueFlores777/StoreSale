using System;
using System.Collections.Generic;

namespace Entity;

public partial class Role
{
    public int IdRole { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<RoleMenu> RoleMenus { get; set; } = new List<RoleMenu>();

    public virtual ICollection<UserSt> UserSts { get; set; } = new List<UserSt>();
}
