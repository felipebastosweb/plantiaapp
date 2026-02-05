namespace PlantiaApp.Site.Repositories;

public class ProdutoRepository
{
    private readonly AppDbContext _context;
    public ProdutoRepository(AppDbContext context) => _context = context;

    public async Task<List<Produto>> GetAllAsync() => 
        await _context.Produtos.ToListAsync();

    public async Task<Produto?> GetByIdAsync(Guid id) => 
        await _context.Produtos.FindAsync(id);

    // Método útil para o formulário de ordem de compra (alerta de estoque)
    public async Task<dynamic> GetResumoEstoqueAsync()
    {
        return await _context.Estoques
            .Select(e => new {
                e.ProdutoId,
                e.QuantidadeDisponivel,
                e.QuantidadeMinima
            }).ToListAsync();
    }
}
