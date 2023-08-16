using Dominio;
using Dominio,Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class CiudadRepository : GenericRepository<Ciudad>, ICiudadRepository
{
    public PaisRepository(ApiIncidenciasContext context) : base(context){

    }

}
