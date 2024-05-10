using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class TemplateContext : DbContext
    {

        public TemplateContext(string connectionString)
           : base(new DbContextOptionsBuilder<TemplateContext>().UseSqlServer(connectionString).Options)
        {
        }
        public TemplateContext()
        {
        }

        public TemplateContext(DbContextOptions<TemplateContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("TestConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
