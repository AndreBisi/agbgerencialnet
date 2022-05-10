using AutoMapper;
using SisGerencialNET.Data.Dtos;

namespace SisGerencialNET.Profiles
{
    public class PlanoProfile : Profile
    {
        public PlanoProfile()
        {
            CreateMap<PlanoProfile, ReadPlanoDto>();
        }
    }
}
