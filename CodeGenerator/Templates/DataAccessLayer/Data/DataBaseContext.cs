using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DataBaseContext: DbContext
    {

        public DataBaseContext(string connectionString)
           : base(new DbContextOptionsBuilder<DataBaseContext>().UseSqlServer(connectionString).Options)
        {
        }

        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
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
