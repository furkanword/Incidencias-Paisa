using Dominio;
using Persistencia;

namespace Aplicacion.Repository;

public class TipoPersonaRepository : GenericRepository<TipoPersona>
{
    public TipoPersonaRepository(ApiIncidenciasContext context) : base(context)
    {
    }
}
