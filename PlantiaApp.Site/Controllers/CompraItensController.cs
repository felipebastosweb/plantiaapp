namespace PlantiaApp.Site.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Models;
using PlantiaApp.Site.Repositories;

[Route("api/[controller]")]
[ApiController]
[Authorize] // Protege todas as operações de itens de compra
public class CompraItensController : ControllerBase
{
    private readonly CompraItemRepository _repository;

    public CompraItensController(CompraItemRepository repository)
    {
        _repository = repository;
    }

    // GET: api/CompraItens/Compra/5
    // Lista todos os itens de uma compra específica
    [HttpGet("Compra/{compraId}")]
    public async Task<ActionResult<IEnumerable<CompraItem>>> GetItensPorCompra(Guid compraId)
    {
        var itens = await _repository.GetByCompraIdAsync(compraId);
        return Ok(itens);
    }

    // GET: api/CompraItens/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CompraItem>> GetCompraItem(Guid id)
    {
        var item = await _repository.GetByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    // PUT: api/CompraItens/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCompraItem(Guid id, CompraItem compraItem)
    {
        if (id != compraItem.Id)
        {
            return BadRequest("O ID do item não confere.");
        }

        try
        {
            // Recalcula totais antes de salvar por segurança
            compraItem.Subtotal = compraItem.Quantidade * compraItem.PrecoUnitario;
            compraItem.Total = compraItem.Subtotal; 

            await _repository.UpdateAsync(compraItem);
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

    // POST: api/CompraItens
    [HttpPost]
    public async Task<ActionResult<CompraItem>> PostAsync(CompraItem compraItem)
    {
        // Garante que o item esteja vinculado a uma compra existente
        await _repository.AddAsync(compraItem);

        return CreatedAtAction(nameof(GetCompraItem), new { id = compraItem.Id }, compraItem);
    }

    // DELETE: api/CompraItens/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var existe = await _repository.ExistsAsync(id);
        if (!existe)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
