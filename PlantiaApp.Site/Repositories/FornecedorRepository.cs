namespace PlantiaApp.Site.Repositories;


using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Data;

public class FornecedorRepository
{
    private readonly ApplicationDbContext _context;
    public FornecedorRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Fornecedor>> GetAllAsync()
    {
        return await _context.Fornecedor.ToListAsync();
    }
    
    public async Task<List<Fornecedor>> GetAtivosAsync() => 
        await _context.Fornecedor.Where(f => f.ArquivadoEm == null).ToListAsync();

    public async Task<Fornecedor?> GetByIdAsync(Guid id) => 
        await _context.Fornecedor.Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Id == id);

    public async Task AddAsync(Fornecedor fornecedor)
    {
        _context.Fornecedor.Add(fornecedor);
        await _context.SaveChangesAsync();
    }
    
    public async Task PutAsync(Fornecedor fornecedor)
    {
        _context.Entry(fornecedor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    private bool Exists(Guid id)
    {
        return _context.Fornecedor.Any(e => e.Id == id);
    }

}
