namespace Dominio;
public class TipoPersona : BaseEntity
{
    public int IdTipoPersona { get; set; }
    public string ? DescripcionTipoPersona { get; set; }
    public ICollection<Persona> ? Personas { get; set; }
} 
