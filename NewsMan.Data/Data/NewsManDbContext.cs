using Microsoft.EntityFrameworkCore;
using NewsMan.Data.Models;

namespace NewsMan.Data.Data
{
    public class NewsManDbContext : DbContext
    {

        public NewsManDbContext(DbContextOptions<NewsManDbContext> options) : base(options)
        { }

        public DbSet<Feed> Feed { get; set; }
        public DbSet<QMaster> QMaster { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<AMaster> AMaster { get; set; }


    }
}
