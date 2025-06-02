using Jcf.WhereToPark.Api.Applications.User.Entities;
using Jcf.WhereToPark.Api.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Jcf.WhereToPark.Api.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
