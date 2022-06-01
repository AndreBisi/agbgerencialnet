using AutoMapper;
using SisGerencialNET.Data.Dtos.BairroDto;
using SisGerencialNET.Models;

namespace SisGerencialNET.Profiles
{
    public class BairroProfile : Profile
    {
        public BairroProfile()
        {
            CreateMap<CreateBairroDto, Bairro>();
            CreateMap<Bairro, ReadBairroDto>();
            CreateMap<UpdateBairroDto, Bairro>();

        }
    }
}
