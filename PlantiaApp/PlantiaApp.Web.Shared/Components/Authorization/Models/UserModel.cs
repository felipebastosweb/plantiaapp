using PlantiaApp.Shared.Components.Authorization.Interfaces;
using PlantiaApp.Shared.Core.Entities;

namespace PlantiaApp.Shared.Components.Authorization.Models
{
    public class UserModel : BaseEntity, IUser
    {
        public required string Username { get; set; }
        public string? PasswordHash { get; set; }
    }

    public class UserEmail : BaseEntity
    {
        public required string Email { get; set; }
    }

    public class UserTelephone : BaseEntity
    {
        public required string Telephone { get; set; }
    }


}
