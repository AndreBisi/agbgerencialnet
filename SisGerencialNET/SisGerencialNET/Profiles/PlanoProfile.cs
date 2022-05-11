using AutoMapper;
using SisGerencialNET.Data.Dtos;
using SisGerencialNET.Models;

namespace SisGerencialNET.Profiles
{
    public class PlanoProfile : Profile
    {
        public PlanoProfile()
        {
            CreateMap<Plano, ReadPlanoDto>();
        }
    }
}
