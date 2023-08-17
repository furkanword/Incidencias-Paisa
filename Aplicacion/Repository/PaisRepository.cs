using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class PaisRepository : GenericRepository<Pais>
{
    public PaisRepository(ApiIncidenciasContext context) : base(context){

    }

}
