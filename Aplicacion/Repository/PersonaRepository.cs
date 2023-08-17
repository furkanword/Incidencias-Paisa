using Dominio;
using Persistencia;

namespace Aplicacion.Repository;

public class PersonaRepository : GenericRepository<Persona>
{
    public PersonaRepository(ApiIncidenciasContext context) : base(context)
    {
    }  
    
}
