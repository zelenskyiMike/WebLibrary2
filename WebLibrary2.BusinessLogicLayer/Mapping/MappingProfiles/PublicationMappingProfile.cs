﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLibrary2.EntitiesLayer.Entities;
using WebLibrary2.ViewModelsLayer.ViewModels;

namespace WebLibrary2.BusinessLogicLayer.Mapping.MappingProfiles
{
    public class PublicationMappingProfile : Profile
    {
        public PublicationMappingProfile()
        {
            CreateMap<Publication, GetPublicationView>().ReverseMap();
            CreateMap<Publication, GetAllPublicationsView>().ForMember(dest => dest.PublicationGenreID, opt => opt.MapFrom(src => src.PublicationGenres.PublicationGenreID)).
                                              ForMember(dest => dest.PublicationGenreName, opt => opt.MapFrom(src => src.PublicationGenres.PublicationGenreName)).ReverseMap();
        }
    }
}