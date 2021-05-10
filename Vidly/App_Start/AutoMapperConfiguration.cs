using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Dtos;
using Vidly.Dtos.Movie;

namespace Vidly.App_Start
{
    public class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }
        public static void Initailize()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Movie, Movie>();
                cfg.CreateMap<Customer, CustomerDto>().ForMember(dis=>dis.MembershipType,src => src.MapFrom(x=>x.MembershipType.Name));
                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<Movie, MovieDto>().ForMember(dis=>dis.Genre,src => src.MapFrom(x=>x.Genre.Name));
                cfg.CreateMap<MovieDto, Movie>();
                cfg.CreateMap<CustomerCreateDto, Customer>();
            });
            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}