using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class AddPersonalDetailsCommandHandler : IRequestHandler<AddPersonalDetailsCommand, PersonalDetails>
    {
        private readonly MovieBaseDbContext _ctx;

        public AddPersonalDetailsCommandHandler(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<PersonalDetails> Handle(AddPersonalDetailsCommand request, CancellationToken cancellationToken)
        {
             
            var actor = await _ctx.Actors.Where(a => a.Id == request.NewPersonalDetails.ActorId).FirstOrDefaultAsync();

            /* await _ctx.PersonalDetails.AddAsync(request.NewPersonalDetails);

             var personalDetails =  _ctx.PersonalDetails.Where(p => p.ActorId == actor.Id);*/

          _ctx.PersonalDetails.Add(request.NewPersonalDetails);

            await _ctx.SaveChangesAsync();


            actor.PersonalDetails = request.NewPersonalDetails;
            actor.PersonalDetailsId = request.NewPersonalDetails.Id;

            await _ctx.SaveChangesAsync();

            return request.NewPersonalDetails;

            
    
            


            await _ctx.SaveChangesAsync();
            return request.NewPersonalDetails;
        }
    }
}
