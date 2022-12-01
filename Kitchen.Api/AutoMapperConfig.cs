using AutoMapper;
using Kitchen.Data.Entities;
using Kitchen.Services;
using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kitchen.Api
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MapperProfile ());
            });

            return mapperConfiguration;
        }
    }
}