
using MovieBase.API.Contracts.ResponseModels;
using MovieBase.API.RequestModels;
using MovieBase.Application.Commands;
using MovieBase.Core.Models;

namespace MovieBase.API.Profiles
{
    public class PersonalDetailsActor : AutoMapper.Profile
    {
        public PersonalDetailsActor()
        {
            
            CreateMap<PersonalDetailsRequestModel, AddPersonalDetailsCommand>();
            CreateMap<AddPersonalDetailsCommand, PersonalDetails>();
            CreateMap<PersonalDetails, PersonalDetailsResponseModel>();
                
        }
    }
}
