using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Chomp.Dtos;
using Chomp.Models;

namespace Chomp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            Mapper.CreateMap<Recipe, RecipeDto>();
            Mapper.CreateMap<Cuisine, CuisineDto>();
            Mapper.CreateMap<Difficulty, DifficultyDto>();

            Mapper.CreateMap<RecipeDto, Recipe>()
                .ForMember(r => r.Id, opt => opt.Ignore());
        }
    }
}