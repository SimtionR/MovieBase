using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Core.Abstractions
{
    public interface IGenreRepository
    {
        Task<Genre> CreateGenreAsync(Genre genre);
        Task<Genre> GetGenreByNameAsync(string name);
        Task<Genre> GetGenreByIdAsync(int id);
        Task<IEnumerable<Genre>> GetAllGenreAsync();
    }
}
