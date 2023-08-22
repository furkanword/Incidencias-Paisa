namespace Dominio;
public class Genero
{
    public int IdGeneroFk { get; set; }
    public string ? NombreGenero { get; set; }
    public ICollection<Persona> ? Personas { get; set; }
}
