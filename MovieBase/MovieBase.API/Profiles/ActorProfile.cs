using MovieBase.Core.Models;
using AutoMapper;
using MovieBase.Core.RequestModels;

namespace MovieBase.API.Profiles
{
    public class ActorProfile : AutoMapper.Profile
    {
        public ActorProfile()
        {
            CreateMap<ActorRequestModel, Actor>();
        }
    }
}
