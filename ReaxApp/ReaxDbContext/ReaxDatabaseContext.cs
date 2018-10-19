using Microsoft.EntityFrameworkCore;
using ReaxApp.ReaxDbContext.Entities;
using ReaxApp.SampleData;

namespace ReaxApp.ReaxDbContext
{
    public interface IReaxDatabaseContext
    {
        DbSet<Movie> Movies { get; set; }
    }

    public class ReaxDatabaseContext: DbContext, IReaxDatabaseContext
    {
        public ReaxDatabaseContext(DbContextOptions<ReaxDatabaseContext> options)
            : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sampleMovies = new SampleDataBuilder().GetSampleData();
            sampleMovies.ForEach(movie => modelBuilder.Entity<Movie>().HasData(movie));

        }
    }
}
