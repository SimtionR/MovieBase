using MovieBase.Core.Models;
using AutoMapper;
using MovieBase.Core.RequestModels;
using MovieBase.Application.Commands;
using MovieBase.API.Contracts.ResponseModels;

namespace MovieBase.API.Profiles
{
    public class ActorProfile : AutoMapper.Profile
    {
        public ActorProfile()
        {
            CreateMap<ActorRequestModel, AddActorCommand>();
            CreateMap<AddActorCommand, Actor>();
            CreateMap<Actor, ActorResponseModel>();
        }
    }
}
