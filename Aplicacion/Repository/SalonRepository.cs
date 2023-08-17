using Dominio;
using Persistencia;

namespace Aplicacion.Repository;

public class SalonRepository : GenericRepository<Salon>
{
    public SalonRepository(ApiIncidenciasContext context) : base(context)
    {
    }
}
