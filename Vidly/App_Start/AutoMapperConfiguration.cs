using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Dtos;
using Vidly.Dtos.Movie;
using Vidly.Dtos.Rentals;

namespace Vidly.App_Start
{
    public class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }
        public static void Initailize()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                //customers
                cfg.CreateMap<Customer, CustomerDto>().ForMember(dis=>dis.MembershipType,src => src.MapFrom(x=>x.MembershipType.Name));
                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<CustomerCreateDto, Customer>();


                //movies
                cfg.CreateMap<Movie, Movie>();
                cfg.CreateMap<Movie, MovieDto>().ForMember(dis=>dis.Genre,src => src.MapFrom(x=>x.Genre.Name));
                cfg.CreateMap<MovieCreateDto, Movie>();


                //rentals
                cfg.CreateMap<Rental, RentalDto>().ForMember(d=>d.Customer,s=>s.MapFrom(x=>x.Customer.Name)).ForMember(d=>d.Movie,s=>s.MapFrom(x=>x.Movie.Name));
            });
            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}