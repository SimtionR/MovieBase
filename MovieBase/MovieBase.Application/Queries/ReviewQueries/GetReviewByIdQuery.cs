using MediatR;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Queries.ReviewQueries
{
    public class GetReviewByIdQuery : IRequest<UserReview>
    {
        public int ReviewId { get; set; }
    }
}
