using Microsoft.EntityFrameworkCore;
using ArticlesApp.Interfaces;
using ArticlesApp.Model;

namespace ArticlesApp.Repositories
{
    public class ReviewRepository: Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ArticlesContext context)
            :base(context)
        { 
        }

        public ArticlesContext ArticlesContext
        {
            get
            {
                return context as ArticlesContext;
            }
        }
    }
}
