using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Contracts.RequestModels
{
    public class ResponsePendingRequestModel
    {
        public int SenderId { get; set; }
        public int PendingId { get; set; }
        public string SenderName { get; set; }
        public string SenderPhoto { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoto { get; set; }
    }
}
