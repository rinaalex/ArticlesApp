using ArticlesApp.Interfaces;
using ArticlesApp.Model;

namespace ArticlesApp.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ArticlesContext context;
        private Repository<Author> authorsRepository;
        private Repository<Article> articlesRepository;
        private Repository<Review> reviewsRepository;

        public UnitOfWork(ArticlesContext context)
        {
            this.context = context;
        }

        public Repository<Author> AuthorsRepository
        {
            get
            {
                if(this.authorsRepository==null)
                {
                    this.authorsRepository = new Repository<Author>(context);
                }
                return this.authorsRepository;
            }
        }

        public Repository<Article> ArticlesRepository
        {
            get
            {
                if (this.articlesRepository == null)
                {
                    this.articlesRepository = new Repository<Article>(context);
                }
                return this.articlesRepository;
            }
        }

        public Repository<Review> ReviewsRepository
        {
            get
            {
                if (this.reviewsRepository == null)
                {
                    this.reviewsRepository = new Repository<Review>(context);
                }
                return reviewsRepository;
            }
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
