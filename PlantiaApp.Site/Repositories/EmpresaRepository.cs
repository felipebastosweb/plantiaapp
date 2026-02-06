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

    public async Task<ActionResult<IEnumerable<Empresa>>> GetAllAsync()
    {
        return await _context.Empresa.ToListAsync();
    }

    public async Task<Empresa> GetByIdAsync(Guid id)
    {
        return await _context.Empresa.FindAsync(id);
    }


    public async Task PutEmpresa(Empresa empresa)
    {
        _context.Entry(empresa).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Empresa> PostEmpresa(Empresa empresa)
    {
        _context.Empresa.Add(empresa);
        await _context.SaveChangesAsync();
        return empresa;
    }

    public async Task DeleteEmpresa(Guid id)
    {
        _context.Empresa.Remove(empresa);
        await _context.SaveChangesAsync();
    }

    private bool EmpresaExists(Guid id)
    {
        return _context.Empresa.Any(e => e.Id == id);
    }
}
