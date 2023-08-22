using Dominio;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers;
public class PaisController : BaseApiController{
    private readonly IUnitOfWork _unitOfWork;
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Pais>>> Get()
    {
        var paises = await _unitOfWork.Paises.GetAllAsync();
        return Ok (paises);
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
    public PaisController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<IActionResult> Get(string id)
    {
        var region = await _unitOfWork.Paises.GetByIdAsync(id);
        return Ok(region);
    }
    
   


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Put(string id, [FromBody]Pais pais){
        if (pais == null)
            return NotFound();
        _unitOfWork.Paises.Update(pais);
        await _unitOfWork.SaveAsync();
        return pais;
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post(Pais pais){
        this._unitOfWork.Paises.Add(pais);
        await _unitOfWork.SaveAsync();
        if (pais == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= pais.IdPais}, pais);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id){
        var pais = await _unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null){
            return NotFound();
        }
        _unitOfWork.Paises.Remove(pais);
        await _unitOfWork.SaveAsync();
        return NoContent();
  
    }
}
