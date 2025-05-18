using EngelTaniApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EngelTaniApi.Infrastructure.Data
{
    public class EngelTaniDbContext:DbContext
    {
        public EngelTaniDbContext(DbContextOptions<EngelTaniDbContext> options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; } = null!;
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
