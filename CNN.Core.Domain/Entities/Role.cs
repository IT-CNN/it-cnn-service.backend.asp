using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Domain.Entities;

public class Role: IdentityRole<Guid>
{
    public string LongName { get; set;} = string.Empty;

    public virtual ICollection<UserRole> UserRoles { get; set; } = null!;
}
