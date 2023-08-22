
using Aplicacion.Repository;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

public class CiudadRepository : GenericRepository<Ciudad> , ICiudadRepository
{
    public CiudadRepository(ApiIncidenciasContext context) : base(context){

    }

}
