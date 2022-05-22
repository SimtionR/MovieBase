using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Abstractions
{
    public interface IActorRepository
    {
         Task<Actor> CreateActorAsync(Actor actor);
         Task<ICollection<Actor>> GetAllActorsAsync();
         Task<Actor> GetActorByIdAsync(int id);
         Task<IEnumerable<Actor>> GetActorsBySearchAsync(string search);    
    }
}
