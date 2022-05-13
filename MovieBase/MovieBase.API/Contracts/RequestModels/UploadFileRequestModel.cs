using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Contracts.RequestModels
{
    public class UploadFileRequestModel
    {
        public string FilePath { get; set; }
        public string FileName  { get; set; }
    }
}
