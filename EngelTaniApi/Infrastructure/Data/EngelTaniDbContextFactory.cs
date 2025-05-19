using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EngelTaniApi.Infrastructure.Data
{
    public class EngelTaniDbContextFactory : IDesignTimeDbContextFactory<EngelTaniDbContext>
    {
        public EngelTaniDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EngelTaniDbContext>();

            // 👇 Bağlantı stringini buraya yaz, ya da appsettings'ten oku
            optionsBuilder.UseSqlServer("Server=.;Database=EngelTaniDb;Trusted_Connection=True;TrustServerCertificate=True");

            return new EngelTaniDbContext(optionsBuilder.Options);
        }
    }
}
