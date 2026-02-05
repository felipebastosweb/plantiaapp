namespace PlantiaApp.Site.Repositories;

public class CompraRepository
{
    private readonly AppDbContext _context;
    
    public CompraRepository(AppDbContext context) => _context = context;

    public async Task<List<Compra>> GetAllAsync() => 
        await _context.Compras.Include(c => c.Fornecedor).ToListAsync();

    public async Task<Compra?> GetByIdAsync(Guid id) => 
        await _context.Compras
            .Include(c => c.Itens)
            .ThenInclude(i => i.Produto)
            .Include(c => c.Fornecedor)
            .FirstOrDefaultAsync(c => c.Id == id);

    public async Task AddAsync(Compra compra)
    {
        await _context.Compras.AddAsync(compra);
        await _context.SaveChangesAsync();
    }
    
    private bool CompraExists(Guid id)
    {
        return _context.Compra.Any(e => e.Id == id);
    }

    public async Task DeleteCompra(Guid id)
    {
        var compra = await _context.Compra.FindAsync(id);
        if (compra == null)
        {
            throw new KeyNotFoundException("Compra não encontrado.");
        }
        _context.Fabricante.Remove(compra);
        await _context.SaveChangesAsync();
    }
}
