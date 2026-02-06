namespace PlantiaApp.Site.Controllers;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Repositories; // Certifique-se de importar o namespace do repo
using PlantiaApp.Site.Models;

[Route("api/[controller]")]
[ApiController]
public class FabricantesController : ControllerBase
{
    private readonly FabricanteRepository _repository;

    public FabricantesController(FabricanteRepository repository)
    {
        _repository = repository;
    }

    // GET: api/Fabricantes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fabricante>>> GetFabricante()
    {
        var fabricantes = await _repository.GetAllAsync();
        return Ok(fabricantes);
    }

    // GET: api/Fabricantes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Fabricante>> GetFabricante(Guid id)
    {
        var fabricante = await _repository.GetByIdAsync(id);

        if (fabricante == null)
        {
            return NotFound();
        }

        return Ok(fabricante);
    }

    // PUT: api/Fabricantes/5
    [Authorize] // Exige autenticação Identity
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFabricante(Guid id, Fabricante fabricante)
    {
        if (id != fabricante.Id)
        {
            return BadRequest();
        }

        try
        {
            await _repository.PutFabricante(fabricante);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_repository.FabricanteExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // POST: api/Fabricantes
    [Authorize] // Exige autenticação Identity
    [HttpPost]
    public async Task<ActionResult<Fabricante>> PostFabricante(Fabricante fabricante)
    {
        var novoFabricante = await _repository.PostFabricante(fabricante);
        return CreatedAtAction(nameof(GetFabricante), new { id = novoFabricante.Id }, novoFabricante);
    }

    // DELETE: api/Fabricantes/5
    [Authorize] // Exige autenticação Identity
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFabricante(Guid id)
    {
        if (!_repository.FabricanteExists(id))
        {
            return NotFound();
        }

        await _repository.DeleteFabricante(id);
        return NoContent();
    }
}
