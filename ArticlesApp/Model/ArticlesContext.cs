using Microsoft.EntityFrameworkCore;

namespace ArticlesApp.Model
{
    public class ArticlesContext: DbContext
    {
        public ArticlesContext(DbContextOptions<ArticlesContext>options)
            :base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
    }
}
