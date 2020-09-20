using AutoMapper;
using WebApiPessoa.Controllers;
using WebApiPessoa.Models;

namespace WebApiPessoa.Mappers
{
    public class PessoaMap : Profile
    {
        public PessoaMap()
        {
            CreateMap<Pessoa, PessoaResponse>();
        }
    }
}
