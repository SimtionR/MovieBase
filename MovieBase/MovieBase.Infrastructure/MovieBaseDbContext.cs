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
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDetails> MovieDetails { get; set; }
        public DbSet<Filmography> Filmographies { get; set; }
        public DbSet<Critic> Critics { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);
                

            builder.Entity<Movie>()
                .HasOne(m => m.MovieDetails)
                .WithOne(m => m.Movie)
                .HasForeignKey<MovieDetails>(m => m.MovieId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<MovieDetails>()
                .HasMany(m => m.Actors);

            builder.Entity<MovieDetails>()
                .HasMany(m=> m.Genres);

            builder.Entity<Actor>()
                .HasOne(p => p.PersonalDetails)
                .WithOne(p => p.Actor)
                .HasForeignKey<PersonalDetails>(p => p.ActorId);

            builder.Entity<Actor>()
                .HasOne(a => a.Filmography)
                .WithOne(a => a.Actor)
                .HasForeignKey<Filmography>(a => a.ActorId);

            
                
                    
                


           
        }
    }
}
