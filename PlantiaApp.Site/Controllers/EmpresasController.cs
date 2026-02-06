using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using PlantiaApp.Site.Data;

namespace PlantiaApp.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly EmpresaRepository _repository;
    
        public EmpresasController(EmpresaRepository repository)
        {
            _repository = repository;
        }
    
        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresa()
        {
            var empresas = await _repository.GetAllAsync();
            return Ok(empresas);
        }
    
        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(Guid id)
        {
            var empresa = await _repository.GetByIdAsync(id);
    
            if (empresa == null)
            {
                return NotFound();
            }
    
            return Ok(empresa);
        }
    
        // PUT: api/Empresas/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutEmpresa(Guid id, Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();
            }
    
            try
            {
                await _repository.PutEmpresa(empresa);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.EmpresaExists(id))
                {
                    return NotFound();
                }
                throw;
            }
    
            return NoContent();
        }
    
        // POST: api/Empresas
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            await _repository.PostEmpresa(empresa);
            return CreatedAtAction("GetEmpresa", new { id = empresa.Id }, empresa);
        }
    
        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEmpresa(Guid id)
        {
            if (!_repository.EmpresaExists(id))
            {
                return NotFound();
            }
    
            await _repository.DeleteEmpresa(id);
            return NoContent();
        }
    }
}
