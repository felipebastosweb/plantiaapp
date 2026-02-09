namespace PlantiaApp.Site.Repositories;

using PlantiaApp.Site.Data;
using Microsoft.EntityFrameworkCore;

public class EstoqueRepository
{
    private readonly ApplicationDbContext _context;
    public EstoqueRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ICollection<Estoque>> GetResumoEstoqueAsync()
    {
        return await _context.Estoque
            .Include(e => e.Produto)
            .ToListAsync();
    }
}
