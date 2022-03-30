using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Abstractions
{
    public interface IPersonalDetailsRepository
    {
        Task<PersonalDetails> CreatePersonalDetailsAsync(PersonalDetails personalDetails, int actorId);
        Task<PersonalDetails> UpdatePersonalDetailsAsync();
        Task<PersonalDetails> GetPersonalDetailsAsync(int actorId);
    }
}
