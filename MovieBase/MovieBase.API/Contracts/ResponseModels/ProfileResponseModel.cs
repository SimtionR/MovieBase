using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Contracts.ResponseModels
{
    public class ProfileResponseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string ProfilePicture { get; set; }
        public List<MovieResponseModel> WatctList { get; set; } = new List<MovieResponseModel>();
        public List<MovieResponseModel> Ratings { get; set; } = new List<MovieResponseModel>();
        //public List<UserReview> Reviews { get; set; } = new List<UserReview>();
        public List<MovieResponseModel> PlayList { get; set; } = new List<MovieResponseModel>();
    }
}
