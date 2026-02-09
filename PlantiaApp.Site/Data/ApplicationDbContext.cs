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
        public DbSet<PlantiaApp.Site.Data.Fornecedor> Fornecedor { get; set; } = default!;
        public DbSet<PlantiaApp.Site.Data.Categoria> Categoria { get; set; } = default!;
        public DbSet<PlantiaApp.Site.Data.Produto> Produto { get; set; } = default!;
        public DbSet<PlantiaApp.Site.Data.CategoriaProduto> CategoriaProduto { get; set; } = default!;
        public DbSet<PlantiaApp.Site.Data.Estoque> Estoque { get; set; } = default!;
    }
}
