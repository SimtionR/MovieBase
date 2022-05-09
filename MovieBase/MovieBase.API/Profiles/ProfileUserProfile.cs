using AutoMapper;
using MovieBase.API.Contracts.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Profiles
{
    public class ProfileUserProfile : Profile
    {
        public ProfileUserProfile()
        {
            CreateMap<MovieBase.Core.Models.Profile, ProfileResponseModel>().ReverseMap();
        }

            

           
    }
}
