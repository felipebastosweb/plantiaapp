namespace PlantiaApp.Site.Repositories;

public class FornecedorRepository
{
    private readonly AppDbContext _context;
    public FornecedorRepository(AppDbContext context) => _context = context;

    public async Task<List<Fornecedor>> GetAtivosAsync() => 
        await _context.Fornecedores.Where(f => f.ArquivadoEm == null).ToListAsync();

    public async Task<Fornecedor?> GetByIdAsync(Guid id) => 
        await _context.Fornecedores.Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Id == id);

    public async Task AddAsync(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
        await _context.SaveChangesAsync();
    }
}
