using Dominio;
using Persistencia;

namespace Aplicacion.Repository;

public class GeneroRepository : GenericRepository<Genero>
{
    public GeneroRepository(ApiIncidenciasContext context) : base(context)
    {
    }
}
