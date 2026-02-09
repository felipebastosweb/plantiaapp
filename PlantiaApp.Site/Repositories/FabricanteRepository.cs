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

    public async Task<IEnumerable<Fabricante>> GetAllAsync()
    {
        return await _context.Fabricante.ToListAsync();
    }

    public async Task<Fabricante> GetByIdAsync(Guid id)
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

    public async Task<Fabricante> PostAsync(Fabricante fabricante)
    {
        _context.Fabricante.Add(fabricante);
        await _context.SaveChangesAsync();
        return fabricante;
    }

    public async Task PutAsync(Fabricante fabricante)
    {
        if(Exists(fabricante.Id) == false)
        {
            throw new KeyNotFoundException("Fabricante não encontrado.");
        }

        _context.Entry(fabricante).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public bool Exists(Guid id)
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
