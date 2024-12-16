using CleanCodeLabb2.Model;
using Microsoft.EntityFrameworkCore;

namespace CleanCodeLabb2
{
    public class MicroServiceDbContext : DbContext
    {
        public MicroServiceDbContext(DbContextOptions<MicroServiceDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
