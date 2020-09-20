using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProprietario.Domain;
using WebApiProprietario.Resources.ProprietarioResource;

namespace WebApiProprietario.AutomapperProfiles
{
    public class ProprietarioProfile : Profile
    {
        public ProprietarioProfile()
        {
            CreateMap<ProprietarioRequest, Proprietario>()
                .ForMember(
                    dest => dest.Foto,
                    opt => opt.MapFrom(src => src.UrlFoto)
                );

            CreateMap<Proprietario, ProprietarioResponse>();
        }
    }
}
