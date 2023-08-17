using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

    public class MatriculaRepository : GenericRepository<Matricula>
    {
        public MatriculaRepository(ApiIncidenciasContext context) : base(context)
        {

        }
    }
