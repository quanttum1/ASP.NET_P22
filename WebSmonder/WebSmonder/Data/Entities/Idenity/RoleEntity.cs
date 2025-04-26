using Microsoft.AspNetCore.Identity;

namespace WebSmonder.Data.Entities.Idenity;

public class RoleEntity : IdentityRole<int>
{
    public ICollection<UserRoleEntity>? UserRoles { get; set; }
}
