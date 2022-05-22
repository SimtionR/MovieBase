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
    public class ActorRepository : IActorRepository
    {
        private readonly MovieBaseDbContext _ctx;

        public ActorRepository(MovieBaseDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Actor> CreateActorAsync(Actor actor)
        {
            _ctx.Actors.Add(actor);
            await _ctx.SaveChangesAsync();
            return actor;
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
           return await _ctx.Actors.Include(a=> a.PersonalDetails).Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Actor>> GetActorsBySearchAsync(string search)
        {
            var actors = await _ctx.Actors.Where(a => (a.FirstName + a.LastName).Contains(search)).ToListAsync();
            return actors;
        }

        public async Task<ICollection<Actor>> GetAllActorsAsync()
        {
            return await _ctx.Actors.ToListAsync();
        }
    }
}
