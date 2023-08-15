
namespace Dominio;

public class Persona
{
    public string ? IdTipoPersona { get; set; }
    public string ? NombrePersona { get; set; }
    public int IdGeneroFk { get; set; }
    public int IdCiudadFk { get; set; }
    public int IdTipoPerFk { get; set; }
    
}
