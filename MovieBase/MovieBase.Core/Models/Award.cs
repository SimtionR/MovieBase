using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Models
{
    public class Award
    {
        public int Id { get; set; }
        public int MovieStarId { get; set; }
        public string Movie { get; set; }
        public string Name { get; set; }
        public bool isWinner { get; set; }
        public DateTime Date { get; set; }

    }
}
