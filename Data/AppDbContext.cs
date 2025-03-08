using Microsoft.EntityFrameworkCore;
using MyBlog.Models;

namespace MyBlog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
    }
}
