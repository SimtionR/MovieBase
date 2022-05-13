using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure.Services
{
    public class BlobInfo
    {
      
      public Stream Content { get; set; }
      public string ContentType { get; set; }

        public BlobInfo(Stream content, string contentType)
        {
            this.Content = content;
            this.ContentType = contentType;
        }

    }
}
