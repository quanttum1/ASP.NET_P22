using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebSmonder.Data.Entities.Idenity;

public class UserEntity : IdentityUser<int>
{
    [StringLength(100)]
    public string? FirstName { get; set; }
    [StringLength(100)]
    public string? LastName { get; set; }
    [StringLength(100)]
    public string? Image { get; set; }

    public ICollection<UserRoleEntity>? UserRoles { get; set; }
}
