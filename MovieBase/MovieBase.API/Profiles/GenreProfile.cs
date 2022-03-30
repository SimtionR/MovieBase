using MovieBase.API.Contracts.ResponseModels;
using MovieBase.API.RequestModels;
using MovieBase.Application.Commands;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Profiles
{
    public class GenreProfile :AutoMapper.Profile
    {
        public GenreProfile()
        {
            CreateMap<GenreRequestModel, AddGenreCommand>();
            CreateMap<AddGenreCommand, Genre>();
            CreateMap<Genre, GenreResponseModel>();
        }
    }
}
