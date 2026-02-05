namespace PlantiaApp.Site.Controllers;

using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Data;


public class EnderecoRepository
{
    private readonly ApplicationDbContext _context;

    public EnderecoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Endereco>> GetEndereco()
    {
        return await _context.Endereco.ToListAsync();
    }

    public async Task<Endereco> GetEndereco(Guid id)
    {
        try
        {
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                throw new KeyNotFoundException("Endereço não encontrado.");
            }
            return endereco;
        }
        catch (Exception)
        {
            throw;
        }

    }


    public async Task PutEndereco(Guid id, Endereco endereco)
    {
        if (id != endereco.Id)
        {
            throw new ArgumentException("ID do endereço não corresponde ao ID fornecido.");
        }

        _context.Entry(endereco).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EnderecoExists(id))
            {
                throw new KeyNotFoundException("Endereço não encontrado.");
            }
            else
            {
                throw;
            }
        }
    }


    public async Task<Endereco> PostEndereco(Endereco endereco)
    {
        _context.Endereco.Add(endereco);
        await _context.SaveChangesAsync();

        return endereco;
    }


    public async Task DeleteEndereco(Guid id)
    {
        var endereco = await _context.Endereco.FindAsync(id);
        if (endereco == null)
        {
            throw new KeyNotFoundException("Endereço não encontrado.");
        }

        _context.Endereco.Remove(endereco);
        await _context.SaveChangesAsync();
    }

    private bool EnderecoExists(Guid id)
    {
        return _context.Endereco.Any(e => e.Id == id);
    }
}
