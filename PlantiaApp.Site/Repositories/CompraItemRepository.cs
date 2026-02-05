namespace PlantiaApp.Site.Repositories;

public class CompraItemRepository
{
    private readonly AppDbContext _context;
    public CompraItemRepository(AppDbContext context) => _context = context;

    public async Task<List<CompraItem>> GetByCompraIdAsync(Guid compraId) => 
        await _context.CompraItens.Where(i => i.CompraId == compraId).ToListAsync();

    public async Task UpdateAsync(CompraItem item)
    {
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
