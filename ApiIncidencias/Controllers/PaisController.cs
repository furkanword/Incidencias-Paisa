using System.Reflection.Metadata.Ecma335;
using ApiIncidencias.Dtos;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using iText.Barcodes.Dmcode;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class PaisController : BaseApiController{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaisController(IUnitOfWork unitOfWork, IMapper mapper){
        
        this._unitOfWork = unitOfWork;
        
        _mapper = mapper;
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Pais>>> Get()
    {
        var paises = await _unitOfWork.Paises.GetAllAsync();
        return Ok (paises);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<PaisDto>>> Get()
    {
        var Paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<PaisDto>>(Paises);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
   

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<IActionResult> Get(string id)
    {
        var pais = await _unitOfWork.Paises.GetByIdAsync(id);
        return Ok(_mapper.Map<PaisxDepDto>(pais));
    }


    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
    [HttpPut("{id}")]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaisDto>> Put(string id, [FromBody]PaisDto paisDto){
        if (paisDto == null)
            return NotFound();
        var paises = _mapper.Map<Pais>(paisDto);
        _unitOfWork.Paises.Update(paises);
        await _unitOfWork.SaveAsync();
        return paisDto;
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post(PaisDto paisDto){
        var pais = _mapper.Map<Pais>(paisDto);
        this._unitOfWork.Paises.Add(pais);
        await _unitOfWork.SaveAsync();
        if (pais == null)
        {
            return BadRequest();
        }
        paisDto.Id = pais.IdPais;
        return CreatedAtAction(nameof(Post),new {id= paisDto.Id}, paisDto);
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
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
