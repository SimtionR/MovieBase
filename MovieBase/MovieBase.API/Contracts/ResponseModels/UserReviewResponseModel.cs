using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Contracts.ResponseModels
{
    public class UserReviewResponseModel
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string Title { get; set; }
        public ProfileResponseModel Profile { get; set; }
        public string RewiewContent { get; set; }
        public DateTime CommentDate { get; set; }
        public double Rating { get; set; }
        public int MovieId { get; set; }
    }
}
