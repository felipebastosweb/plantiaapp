using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantiaApp.Site.Data;

namespace PlantiaApp.Site.Repositories;

public class EmpresaRepository
{
    private readonly ApplicationDbContext _context;

    public EmpresaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresa()
    {
        return await _context.Empresa.ToListAsync();
    }

    public async Task<Empresa> GetEmpresa(Guid id)
    {
        try
        {
            var empresa = await _context.Empresa.FindAsync(id);

            if (empresa == null)
            {
                throw new KeyNotFoundException("Empresa não encontrada.");
            }

            return empresa;

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar a empresa: " + ex.Message);
        }
    }


    public async Task PutEmpresa(Guid id, Empresa empresa)
    {

        try
        {
            if (id != empresa.Id)
            {
                throw new ArgumentException("ID da empresa não corresponde.");
            }

            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmpresaExists(id))
            {
                throw new KeyNotFoundException("Empresa não encontrada.");
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<Empresa> PostEmpresa(Empresa empresa)
    {
        _context.Empresa.Add(empresa);
        await _context.SaveChangesAsync();

        return empresa;
    }

    public async Task DeleteEmpresa(Guid id)
    {
        try
        {
            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                throw new KeyNotFoundException("Empresa não encontrada.");
            }

            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao deletar a empresa: " + ex.Message);
        }
    }

    private bool EmpresaExists(Guid id)
    {
        return _context.Empresa.Any(e => e.Id == id);
    }
}
