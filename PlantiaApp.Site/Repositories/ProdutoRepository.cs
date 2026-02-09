namespace PlantiaApp.Site.Repositories;

using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Data;

public class ProdutoRepository
{
    private readonly ApplicationDbContext _context;
    public ProdutoRepository(ApplicationDbContext context) => _context = context;

    public async Task<List<Produto>> GetAllAsync() => 
        await _context.Produto.ToListAsync();

    public async Task<Produto?> GetByIdAsync(Guid id) => 
        await _context.Produto.FindAsync(id);

    // Método útil para o formulário de ordem de compra (alerta de estoque)
    public async Task<dynamic> GetResumoEstoqueAsync()
    {
        return await _context.Estoque
            .Select(e => new {
                e.ProdutoId,
                e.QuantidadeDisponivel,
                e.QuantidadeMinima
            }).ToListAsync();
    }
}
