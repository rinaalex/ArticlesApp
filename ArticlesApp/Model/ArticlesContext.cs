using Microsoft.EntityFrameworkCore;

namespace ArticlesApp.Model
{
    public class ArticlesContext: DbContext
    {
        public ArticlesContext(DbContextOptions<ArticlesContext>options)
            :base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
