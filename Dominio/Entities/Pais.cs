
using System.Security.Cryptography;

namespace Dominio;

public class Pais : BaseEntity
{
    public string ? IdPais { get; set; }
    public string ? NombrePais { get; set; }
    public ICollection<Departamento> ? Departamentos { get; set; }
}
