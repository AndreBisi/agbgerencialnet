﻿using AutoMapper;
using SisGerencialNET.Data.Dtos;
using SisGerencialNET.Models;

namespace SisGerencialNET.Profiles
{
    public class BairroProfile : Profile
    {
        public BairroProfile()
        {
            CreateMap<Bairro, ReadBairroDto>();
        }
    }
}
