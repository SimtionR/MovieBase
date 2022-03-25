
using MovieBase.API.RequestModels;
using MovieBase.Core.Models;

namespace MovieBase.API.Profiles
{
    public class PersonalDetailsActor : AutoMapper.Profile
    {
        public PersonalDetailsActor()
        {
            CreateMap<PersonalDetailsRequestModel, PersonalDetails>();
                
        }
    }
}
