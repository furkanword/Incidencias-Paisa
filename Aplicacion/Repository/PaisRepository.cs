using System.Security.AccessControl;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PaisRepository : GenericRepository<Pais> , IPaisRepository
{
    private  readonly ApiIncidenciasContext  _context;
    public PaisRepository(ApiIncidenciasContext context) : base(context){
        _context =  context;

    }
    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Paises!.Include(x => x.Departamentos)
        .ToListAsync();
    }
    public override async Task<Pais> GetByIdAsync(string id)
    {
        return (await _context.Set<Pais>().Include(x => x.Departamentos).FirstAsync(p=> p.IdPais == id))!;
        
    }
    public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(int pageIndex,int pageSize, string search){
        var query = _context.Paises as IQueryable<Pais>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query!.Where(x => x.NombrePais!.ToLower().Contains(search));
        }
        var totalRegistros = await query!.CountAsync();
        var registros = await query!
        .Include(u => u.Departamentos)
        .Skip((pageIndex - 1) * pageSize)
        .Take(pageSize)
        .ToArrayAsync();
        return (totalRegistros, registros);
    }


}
