using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ArticlesApp.Interfaces;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;
using ArticlesApp.ViewModels.QueryObjects;

namespace ArticlesApp.Repositories
{
    public class ReviewRepository: Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ArticlesContext context)
            :base(context)
        { 
        }

        public ReviewViewModel GetReviewViewModel(int id)
        {
            Review review = ArticlesContext.Reviews.Find(id);
            if (review!=null)
            {
                ArticlesContext.Entry(review).Reference(r => r.Author).Load();
                return review.MapToViewModel();                
            }
            return null;
        }

        public IEnumerable<ReviewViewModel> GetReviewsViewModels(int articleId)
        {
            return ArticlesContext.Reviews.Where(p=>p.ArticleId==articleId).Include(r => r.Author).MaptoViewModel();
        }

        public ArticlesContext ArticlesContext
        {
            get
            {
                return context as ArticlesContext;
            }
        }

        //public override IEnumerable<Review> All()
        //{
        //    return ArticlesContext.Reviews.Include(a => a.Author);
        //}
    }
}
