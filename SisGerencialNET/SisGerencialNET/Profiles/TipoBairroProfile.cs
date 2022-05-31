using AutoMapper;
using SisGerencialNET.Data.Dtos.TipoBairroDto;
using SisGerencialNET.Models;

namespace SisGerencialNET.Profiles
{
    public class TipoBairroProfile : Profile
    {
        public TipoBairroProfile()
        {
            CreateMap<TipoBairro, ReadTipoBairroDto>();
            CreateMap<CreateTipoBairroDto, TipoBairro>();
            CreateMap<UpdateTipoBairroDto, TipoBairro>();
        }
    }
}
