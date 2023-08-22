using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class DepartamentoRepository : GenericRepository<Departamento> , IDepartamentoRepository
{
        public DepartamentoRepository(ApiIncidenciasContext context) : base(context){

    }
}
