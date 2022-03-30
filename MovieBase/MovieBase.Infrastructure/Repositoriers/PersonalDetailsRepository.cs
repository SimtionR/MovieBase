using Microsoft.EntityFrameworkCore;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure.Repositoriers
{
    public class PersonalDetailsRepository : IPersonalDetailsRepository
    {
        private readonly MovieBaseDbContext _ctx;
        public PersonalDetailsRepository(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }
       
        public async Task<PersonalDetails> CreatePersonalDetailsAsync(PersonalDetails personalDetails, int actorId)
        {
            var actor = await _ctx.Actors.Where(a => a.Id ==actorId).FirstOrDefaultAsync();



            _ctx.PersonalDetails.Add(personalDetails);

            await _ctx.SaveChangesAsync();


            actor.PersonalDetails = personalDetails;
            actor.PersonalDetailsId = personalDetails.Id;

            await _ctx.SaveChangesAsync();

            return personalDetails;
        }

        public async Task<PersonalDetails> GetPersonalDetailsAsync(int actorId)
        {
            return await _ctx.PersonalDetails.Where(p => p.ActorId == actorId).FirstOrDefaultAsync();
        }

        public Task<PersonalDetails> UpdatePersonalDetailsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
