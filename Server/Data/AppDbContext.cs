using TornowizeAPI.Server;
using Microsoft.EntityFrameworkCore;

namespace TornowizeAPI.Server.Data{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; } 
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new MemoryConfiguration());
        }
    }




}
