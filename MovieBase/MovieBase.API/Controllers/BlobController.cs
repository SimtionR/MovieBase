using Microsoft.AspNetCore.Mvc;
using MovieBase.API.Contracts.RequestModels;
using MovieBase.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    public class BlobController : ApiController
    {
        private IBlobStorageService _blobService;
        //private readonly string blobCotnainer = "profilepictures";

        public BlobController(IBlobStorageService blobService)
        {
            _blobService = blobService;
        }

        [HttpGet]
        [Route("getPicture/{name}")]
        public async Task<ActionResult> GetPicture(string name, string blobContainer)
        {

            var data = await _blobService.GetBlobAsync(name, blobContainer);
            return File(data.Content, data.ContentType);
        }

        [HttpPost]
        [Route("uploadPicture")]
        public async Task<ActionResult> UploadPicture([FromBody] UploadFileRequestModel request, string blobContainer)
        {
            await _blobService.UploadFileBlobAsync(request.FilePath, request.FileName, blobContainer);
            return Ok();
        }
        [HttpDelete]
        [Route("deletePicture/{name}")]
        public async Task<ActionResult> DeletePicture(string name, string blobContainer)
        {
            await _blobService.DeleteBlobAsync(name, blobContainer);
            return Ok();
        }
        //[HttpPost]
        //[Route("upload")]
        //public async Task<ActionResult> Upload([FromForm] IFormFile file, [FromForm]string blobContainer)
        //{
        //    await _blobService.UploadFileContent(file, blobContainer);
        //    return Ok();
        //}
    }
}
