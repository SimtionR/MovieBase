using Microsoft.AspNetCore.Mvc;
using MovieBase.API.RequestModels;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.API.Controllers
{
    public class FilmographyController : ApiController
    {
        [HttpPost]
        [Route("addFilmography")]
        public async Task<Filmography> AddFilmography(int actorId, FilmographyRequestModel model)
        {
            return null;
        }
    }
}
