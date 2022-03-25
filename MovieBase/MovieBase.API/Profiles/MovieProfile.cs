using MovieBase.Core.Models;
using MovieBase.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Profiles
{
    public class MovieProfile : AutoMapper.Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieRequestModel, Movie>();
        }
    }
}
