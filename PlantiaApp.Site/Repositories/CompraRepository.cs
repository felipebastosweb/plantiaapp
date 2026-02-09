namespace PlantiaApp.Site.Repositories;

using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Data;

public class CompraRepository
{
    private readonly AppDbContext _context;
    
    public CompraRepository(AppDbContext context) => _context = context;

    public async Task<List<Compra>> GetAllAsync() => 
        await _context.Compra.Include(c => c.Fornecedor).ToListAsync();

    public async Task<Compra?> GetByIdAsync(Guid id) => 
        await _context.Compra
            .Include(c => c.Itens)
            .ThenInclude(i => i.Produto)
            .Include(c => c.Fornecedor)
            .FirstOrDefaultAsync(c => c.Id == id);

    public async Task AddAsync(Compra compra)
    {
        await _context.Compra.AddAsync(compra);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var compra = await _context.Compra.FindAsync(id);
        if (compra == null)
        {
            throw new KeyNotFoundException("Compra não encontrado.");
        }
        _context.Compra.Remove(compra);
        await _context.SaveChangesAsync();
    
    }

    private bool Exists(Guid id)
    {
        return _context.Compra.Any(e => e.Id == id);
    }

}
