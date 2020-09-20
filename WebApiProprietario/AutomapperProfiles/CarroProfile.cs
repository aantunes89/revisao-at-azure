using AutoMapper;
using WebApiProprietario.Domain;
using WebApiProprietario.Resources.ProprietarioResource;

namespace WebApiProprietario.AutomapperProfiles
{
    public class CarroProfile : Profile
    {
        public CarroProfile()
        {
            CreateMap<Carro, CarroResponse>();
            CreateMap<CarroRequest, Carro>();
        }
    }
}
