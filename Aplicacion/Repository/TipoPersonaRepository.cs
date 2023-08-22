using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class TipoPersonaRepository : GenericRepository<TipoPersona> , ITipoPersonaRepository
{
    public TipoPersonaRepository(ApiIncidenciasContext context) : base(context)
    {
    }
}
