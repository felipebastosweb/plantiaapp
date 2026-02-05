using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Data;

namespace PlantiaApp.Site.Repositories;

public class FabricanteRepository
{
    private readonly ApplicationDbContext _context;
    public FabricanteRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Fabricante>> GetFabricante()
    {
        return await _context.Fabricante.ToListAsync();
    }
    public async Task<Fabricante> GetFabricante(Guid id)
    {
        try
        {
            var fabricante = await _context.Fabricante.FindAsync(id);
            if (fabricante == null)
            {
                throw new KeyNotFoundException("Fabricante não encontrado.");
            }
            return fabricante;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Fabricante> PostFabricante(Fabricante fabricante)
    {
        _context.Fabricante.Add(fabricante);
        await _context.SaveChangesAsync();
        return fabricante;
    }

    public async Task PutFabricante(Guid id, Fabricante fabricante)
    {
        if (id != fabricante.Id)
        {
            throw new ArgumentException("ID do fabricante não corresponde ao ID fornecido.");
        }
        _context.Entry(fabricante).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FabricanteExists(id))
            {
                throw new KeyNotFoundException("Fabricante não encontrado.");
            }
            else
            {
                throw;
            }
        }
    }
    private bool FabricanteExists(Guid id)
    {
        return _context.Fabricante.Any(e => e.Id == id);
    }

    public async Task DeleteFabricante(Guid id)
    {
        var fabricante = await _context.Fabricante.FindAsync(id);
        if (fabricante == null)
        {
            throw new KeyNotFoundException("Fabricante não encontrado.");
        }
        _context.Fabricante.Remove(fabricante);
        await _context.SaveChangesAsync();
    }

}
