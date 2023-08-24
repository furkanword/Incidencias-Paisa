
namespace Dominio.Entities;

public class Rol
{
    public int Id { get; set; }
    public string ? Nombre { get; set; }
    public ICollection<Persona> Personas { get; set; } = new HashSet<Persona>();
    public ICollection<PersonaRol> ? PersonRoles { get; set; }
}
