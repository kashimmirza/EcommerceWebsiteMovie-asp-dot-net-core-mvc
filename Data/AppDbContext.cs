using EcommerceWebsiteMovie.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebsiteMovie.Data
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> Options):base(Options)
        //{

        //}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Actor_Movie>().HasKey(am => new
        //    {
        //        am.ActorId,
        //        am.MovieId
        //    });
        //    //modelBuilder.Entity<Actor_Movie>().HasOne(modelBuilder => modelBuilder.Movie).WithMany(AbandonedMutexException => AbandonedMutexException.Actor_Movies).HasForeignKey(m => m.MovieId);
        //    //modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actors.WithMany(am => am.Actor_Movie).HasForeignKey(m => m.ActorId);
        //    modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.MovieId);
        //    modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actors).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.ActorId);

        //    base.OnModelCreating(modelBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.Actor_Movies)
                .HasForeignKey(am => am.MovieId);

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Actors)
                .WithMany(a => a.Actor_Movies)
                .HasForeignKey(am => am.ActorId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }

    }
}


