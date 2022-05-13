using AutoMapper;
using MovieBase.API.Contracts.RequestModels;
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.Application.Commands.Reviews;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Profiles
{
    public class UserReviewProfile :AutoMapper.Profile
    {
        public UserReviewProfile()
        {
            CreateMap<UserReviewRequestModel, AddReviewCommand>();
            CreateMap<AddReviewCommand, UserReview>();
            CreateMap<UserReview, UserReviewResponseModel>();
            
        }
    }
}
