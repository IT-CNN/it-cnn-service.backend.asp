using Microsoft.AspNetCore.Identity;

namespace CNN.Core.Domain.Entities;

public class User: IdentityUser<Guid>
{
    public string Picture { get; set; } = DefaultParams.defaultUserPicture;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime BirthDate { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsActivate { get; set; } = true;

    public virtual ICollection<UserRole> UserRoles { get; set; } = null!;
}
