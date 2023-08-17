
using Aplicacion.Repository;
using Dominio;
using Persistencia;

public class CiudadRepository : GenericRepository<Ciudad>
{
    public CiudadRepository(ApiIncidenciasContext context) : base(context){

    }

}
