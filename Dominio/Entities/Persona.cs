
using Dominio.Entities;

namespace Dominio;

public class Persona 
{
    public string ? IdPersona { get; set; }
    public string ? NombrePersona { get; set; }
    public int IdGeneroFk { get; set; }
    public Genero ? Genero { get; set; }
    public string ? IdCiudadFk { get; set; }
    public Ciudad ? Ciudad { get; set; }
    public int IdTipoPerFk { get; set; }
    public TipoPersona ? TipoPersona { get; set;}
    public ICollection<Matricula> ? Matriculas { get; set; }
    public ICollection<TrainerSalon>? TrainerSalones { get; set; }
    public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
    public ICollection<PersonaRol> ? PersonaRoles { get; set; }

    
}
