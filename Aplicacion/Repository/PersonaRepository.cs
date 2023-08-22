using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class PersonaRepository : GenericRepository<Persona> , IPersonaRepository
{
    public PersonaRepository(ApiIncidenciasContext context) : base(context)
    {
    }  
    
}
