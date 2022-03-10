using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class CriticReview : Review
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int CriticId { get; set; }
    }
}
