using Dominio;
using Persistencia;

namespace Aplicacion.Repository;

public class TrainerSalonRepository : GenericRepository<TrainerSalon>
{
    public TrainerSalonRepository(ApiIncidenciasContext context) : base(context)
    {
    }
}
    