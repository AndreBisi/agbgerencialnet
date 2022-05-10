using AutoMapper;
using SisGerencialNET.Data.Dtos;

namespace SisGerencialNET.Profiles
{
    public class BairroProfile : Profile
    {
        public BairroProfile()
        {
            CreateMap<BairroProfile, ReadBairroDto>();
        }
    }
}
