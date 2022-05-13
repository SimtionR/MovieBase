using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Contracts.RequestModels
{
    public class UploadContentRequestModel
    {
        public string Content { get; set; }
        public string FileName { get; set; }
    }
}
