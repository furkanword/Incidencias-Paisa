using ApiIncidencias.Dtos;
using AutoMapper;
using Dominio;

namespace ApiIncidencias.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles(){
        CreateMap<PaisxDepDto,Pais>()
        .ForMember(p => p.IdPais, opt => opt.MapFrom(src => src.Id))
        .ReverseMap();

        CreateMap<DepartamentoDto,Departamento>()
        .ReverseMap();

        CreateMap<PaisDto,Pais>()
        .ForMember(o => o.Departamentos, d => d.Ignore())
        .ForMember(p => p.IdPais, opt => opt.MapFrom(src => src.Id))
        .ReverseMap();

        CreateMap<Pais, PaisxDepDto>().ReverseMap();

    }
}
