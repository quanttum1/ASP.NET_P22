using Microsoft.AspNetCore.Identity;

namespace WebSmonder.Data.Entities.Idenity;

public class UserRoleEntity : IdentityUserRole<int>
{
    public UserEntity User { get; set; } = new();
    public RoleEntity Role { get; set; } = new();
}
