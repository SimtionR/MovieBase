using MediatR;
using MovieBase.Application.Commands;
using MovieBase.Core.Models;
using MovieBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Application.Handlers
{
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, Genre>
    {
        private readonly MovieBaseDbContext _ctx;

        public AddGenreCommandHandler(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Genre> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            _ctx.Add(request.NewGenre);
            await _ctx.SaveChangesAsync();

            return request.NewGenre;
        }
    }
}
