using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public abstract class Review
    {
        public string Title { get; set; }
        public string RewiewContent { get; set; }
        public double Rating { get; set; }
        public DateTime CommentDate { get; set; }
        public int MovieId { get; set; }
        public Movie MovieReviewd { get; set; }
    }
}
