using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Data;

namespace PlantiaApp.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresa()
        {
            return await _context.Empresa.ToListAsync();
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(Guid id)
        {
            var empresa = await _context.Empresa.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }

        // PUT: api/Empresas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(Guid id, Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Empresas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            _context.Empresa.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresa", new { id = empresa.Id }, empresa);
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(Guid id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaExists(Guid id)
        {
            return _context.Empresa.Any(e => e.Id == id);
        }
    }
}
