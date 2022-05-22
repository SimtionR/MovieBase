using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Contracts.ResponseModels
{
    public class ConnectionPendingResponseModel
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderPhoto { get; set; }
        public int ReceiverId { get; set; }
    }
}
