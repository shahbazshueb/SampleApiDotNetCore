using Microsoft.EntityFrameworkCore;

namespace sampleApi.Models
{
    public class SampleContext : DbContext
    {
        
        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}