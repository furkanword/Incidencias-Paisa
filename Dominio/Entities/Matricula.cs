namespace Dominio;

public class Matricula : BaseEntity
{
    public int IdMatricula { get; set; }
    public string ? IdPersonaFK { get; set; }
    public Persona ? Persona { get; set; }
    public int IdSalonFk { get; set; }
    public Salon ? Salon { get; set; }
}
