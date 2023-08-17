using Dominio;
using Persistencia;

namespace Aplicacion.Repository;

public class DepartamentoRepository : GenericRepository<Departamento> 
{
        public DepartamentoRepository(ApiIncidenciasContext context) : base(context){

    }
}
