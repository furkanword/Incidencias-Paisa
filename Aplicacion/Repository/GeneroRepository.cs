using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class GeneroRepository : GenericRepository<Genero> , IGeneroRepository
{
    public GeneroRepository(ApiIncidenciasContext context) : base(context) 
    {
    }
}
