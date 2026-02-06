namespace PlantiaApp.Site.Repositories;

public class FornecedorRepository
{
    private readonly AppDbContext _context;
    public FornecedorRepository(AppDbContext context) => _context = context;

    public async Task<Fornecedor> GetAllAsync() => await _context.Fornecedor.ToListAsync();
    
    public async Task<List<Fornecedor>> GetAtivosAsync() => 
        await _context.Fornecedores.Where(f => f.ArquivadoEm == null).ToListAsync();

    public async Task<Fornecedor?> GetByIdAsync(Guid id) => 
        await _context.Fornecedores.Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Id == id);

    public async Task AddAsync(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
        await _context.SaveChangesAsync();
    }
    
    public async Task PutAsync(Fornecedor fornecedor)
    {
        if (id != fornecedor.Id)
        {
            throw new ArgumentException("ID do fornecedor não corresponde ao ID fornecido.");
        }
        _context.Entry(fornecedor).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FornecedorExists(id))
            {
                throw new KeyNotFoundException("Fornecedor não encontrado.");
            }
            else
            {
                throw;
            }
        }
    }
    private async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Fornecedor.AnyAsync(e => e.Id == id);
    }

}
