using Microsoft.EntityFrameworkCore;

namespace DotNet_RedditClone.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Community> Communities { get; set; }

        public DbSet<Flair> Flairs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Rule> Rules { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
