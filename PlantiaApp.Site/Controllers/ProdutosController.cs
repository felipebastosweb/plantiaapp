namespace PlantiaApp.Site.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Data;
using PlantiaApp.Site.Repositories;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoRepository _repository;

    public ProdutosController(ProdutoRepository repository)
    {
        _repository = repository;
    }

    // GET: api/Produtos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetAllAsync()
    {
        var produtos = await _repository.GetAllAsync();
        return Ok(produtos);
    }

    // GET: api/Produtos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetByIdAsync(Guid id)
    {
        var produto = await _repository.GetByIdAsync(id);

        if (produto == null)
        {
            return NotFound(new { Message = "Produto não cadastrado." });
        }

        return Ok(produto);
    }

    // GET: api/Produtos/EstoqueStatus
    // Endpoint customizado para o formulário de Ordem de Compra
    [HttpGet("EstoqueStatus")]
    public async Task<ActionResult> GetEstoqueStatus()
    {
        var status = await _repository.GetResumoEstoqueAsync();
        return Ok(status);
    }

    // POST: api/Produtos
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Produto>> PostAsync(Produto produto)
    {
        // Ao criar um produto, o repositório deve idealmente inicializar 
        // um registro na tabela Estoque com quantidade zero.
        await _repository.AddAsync(produto);
        
        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
    }

    // PUT: api/Produtos/5
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(Guid id, Produto produto)
    {
        if (id != produto.Id)
        {
            return BadRequest();
        }

        try
        {
            await _repository.UpdateAsync(produto);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _repository.ExistsAsync(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Produtos/5
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        if (!await _repository.ExistsAsync(id))
        {
            return NotFound();
        }

        // Validação de negócio: Evitar deletar produtos com movimentação de estoque
        var possuiMovimentacao = await _repository.HasMovementAsync(id);
        if (possuiMovimentacao)
        {
            return BadRequest("Não é possível excluir um produto que possui histórico de movimentação. Considere arquivá-lo.");
        }

        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
