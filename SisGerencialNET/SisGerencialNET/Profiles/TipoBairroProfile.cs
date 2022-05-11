﻿using AutoMapper;
using SisGerencialNET.Data.Dtos;
using SisGerencialNET.Models;

namespace SisGerencialNET.Profiles
{
    public class TipoBairroProfile : Profile
    {
        public TipoBairroProfile()
        {
            CreateMap<TipoBairro, ReadTipoBairroDto>();
        }
    }
}
