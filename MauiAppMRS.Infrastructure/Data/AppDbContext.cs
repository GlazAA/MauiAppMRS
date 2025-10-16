using Microsoft.EntityFrameworkCore;

namespace MauiAppMRS.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // ѕока без DbSet - добавим после проверки запуска
    }
}