using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ProductHunt.Data.Entity;
using ProductHunt.Domain.Models;

namespace ProductHunt.Service
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {                             
                cfg.CreateMap<Article,ArticleModel>()
                .ReverseMap();                
            });
        }
    }
}
