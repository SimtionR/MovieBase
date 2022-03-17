using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Infrastructure
{
    public class MovieBaseDbContext : IdentityDbContext<User>

    {

        public MovieBaseDbContext(DbContextOptions options): base (options)
        {

        }

        public DbSet<Profile> Profiles{ get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<CriticReview> CriticReviews { get; set; }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<Actor> MovieStars { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Filmography> Filmographies { get; set; }
        public DbSet<Critic> Critics { get; set; }
        public DbSet<Award> Awards { get; set; }


     
    }
}
