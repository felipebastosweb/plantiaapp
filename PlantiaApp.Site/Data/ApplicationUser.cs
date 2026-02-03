using Microsoft.AspNetCore.Identity;

namespace PlantiaApp.Site.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
}


public partial class Empresa
{
    public string ApplicationUserId { get; set; } = string.Empty;
}