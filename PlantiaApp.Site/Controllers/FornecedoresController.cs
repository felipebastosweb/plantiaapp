namespace PlantiaApp.Site.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Models;
using PlantiaApp.Site.Repositories;

[Route("api/[controller]")]
[ApiController]
public class FornecedoresController : ControllerBase
{
    private readonly FornecedorRepository _repository;

    public FornecedoresController(FornecedorRepository repository)
    {
        _repository = repository;
    }

    // GET: api/Fornecedores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
    {
        // Retorna apenas fornecedores não arquivados
        var fornecedores = await _repository.GetAtivosAsync();
        return Ok(fornecedores);
    }

    // GET: api/Fornecedores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Fornecedor>> GetFornecedor(Guid id)
    {
        var fornecedor = await _repository.GetByIdAsync(id);

        if (fornecedor == null)
        {
            return NotFound(new { Message = "Fornecedor não encontrado." });
        }

        return Ok(fornecedor);
    }

    // POST: api/Fornecedores
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
    {
        // Garante que a data de criação seja definida no servidor
        fornecedor.CriadoEm = DateTime.UtcNow;
        
        await _repository.AddAsync(fornecedor);
        
        return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
    }

    // PUT: api/Fornecedores/5
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFornecedor(Guid id, Fornecedor fornecedor)
    {
        if (id != fornecedor.Id)
        {
            return BadRequest("O ID fornecido não coincide com o objeto.");
        }

        try
        {
            fornecedor.AlteradoEm = DateTime.UtcNow;
            await _repository.UpdateAsync(fornecedor);
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

    // DELETE: api/Fornecedores/5 (Soft Delete sugerido)
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFornecedor(Guid id)
    {
        var existe = await _repository.ExistsAsync(id);
        if (!existe)
        {
            return NotFound();
        }

        // Em sistemas de ERP, geralmente arquivamos em vez de deletar fisicamente
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
