using AutoMapper;
using SisGerencialNET.Data.Dtos.TipoBairroDto;
using SisGerencialNET.Models;

namespace SisGerencialNET.Profiles
{
    public class TipoBairroProfile : Profile
    {
        public TipoBairroProfile()
        {
            CreateMap<CreateTipoBairroDto, TipoBairro>();
            CreateMap<TipoBairro, ReadTipoBairroDto>();            
            CreateMap<UpdateTipoBairroDto, TipoBairro>();
        }
    }
}
