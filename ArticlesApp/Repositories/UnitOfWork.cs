using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArticlesApp.Interfaces;
using ArticlesApp.Model;

namespace ArticlesApp.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ArticlesContext context;

        public UnitOfWork(ArticlesContext context)
        {
            this.context = context;
            Authors = new AuthorRepository(context);
            Articles = new ArticleRepository(context);
            Reviews = new ReviewRepository(context);
        }

        public IAuthorRepository Authors { get; private set; }
        public IArticleRepository Articles { get; private set; }
        public IReviewRepository Reviews { get; private set; }

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
