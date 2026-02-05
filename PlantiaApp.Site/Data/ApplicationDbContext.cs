using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Data;

namespace PlantiaApp.Site.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<PlantiaApp.Site.Data.Endereco> Endereco { get; set; } = default!;
        public DbSet<PlantiaApp.Site.Data.Empresa> Empresa { get; set; } = default!;
        public DbSet<PlantiaApp.Site.Data.Fabricante> Fabricante { get; set; } = default!;
    }
}
