using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class SalonRepository : GenericRepository<Salon> , ISalonRepository
{
    public SalonRepository(ApiIncidenciasContext context) : base(context)
    {
    }
}
