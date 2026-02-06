namespace PlantiaApp.Site.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Models;
using PlantiaApp.Site.Repositories;

[Route("api/[controller]")]
[ApiController]
[Authorize] // Exige autenticação para qualquer operação de compra
public class ComprasController : ControllerBase
{
    private readonly CompraRepository _compraRepository;

    public ComprasController(CompraRepository compraRepository)
    {
        _compraRepository = compraRepository;
    }

    // GET: api/Compras
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Compra>>> GetCompras()
    {
        var compras = await _compraRepository.GetAllAsync();
        return Ok(compras);
    }

    // GET: api/Compras/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Compra>> GetCompra(Guid id)
    {
        var compra = await _compraRepository.GetByIdAsync(id);

        if (compra == null)
        {
            return NotFound();
        }

        return Ok(compra);
    }

    // POST: api/Compras
    [HttpPost]
    public async Task<ActionResult<Compra>> PostCompra(Compra compra)
    {
        if (compra.Itens == null || !compra.Itens.Any())
        {
            return BadRequest("Uma compra deve possuir pelo menos um item.");
        }

        try
        {
            // O repositório deve salvar a Compra e os CompraItems em cascata
            await _compraRepository.AddAsync(compra);
            
            return CreatedAtAction(nameof(GetCompra), new { id = compra.Id }, compra);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao processar a compra: {ex.Message}");
        }
    }

    // DELETE: api/Compras/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompra(Guid id)
    {
        var compra = await _compraRepository.GetByIdAsync(id);
        if (compra == null)
        {
            return NotFound();
        }

        await _compraRepository.DeleteAsync(compra);
        return NoContent();
    }
}
