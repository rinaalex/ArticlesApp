using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ArticlesApp.Interfaces;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;
using ArticlesApp.ViewModels.QueryObjects;

//using System.Linq.Expressions;
//using System;

namespace ArticlesApp.Repositories
{
    public class ReviewRepository: Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ArticlesContext context)
            :base(context)
        { 
        }

        //public override IEnumerable<Review> Find(Expression<Func<Review, bool>> predicate)
        //{
        //    return ArticlesContext.Reviews.Include(r=>r.Article).Include(r=>r.Author).Where(predicate);
        //}

        //public ReviewViewModel GetReviewViewModel(int id)
        //{
        //    Review review = ArticlesContext.Reviews.Find(id);
        //    if (review!=null)
        //    {
        //        ArticlesContext.Entry(review).Reference(r => r.Author).Load();
        //        return review.MapToViewModel();                
        //    }
        //    return null;
        //}

        //public IEnumerable<ReviewViewModel> GetReviewsViewModels(int articleId)
        //{
        //    return ArticlesContext.Reviews.Where(p=>p.ArticleId==articleId).Include(r => r.Author).Include(r=>r.Article).MaptoViewModel();
        //}

        //public IEnumerable<ReviewViewModel> GetReviewsViewModelsByAuthor(int authorId)
        //{
        //    return this.All(filter:q=>q.AuthorId==authorId, 
        //        orderBy:r=>r.OrderBy(q=>q.PublicationDate), 
        //        includeProperties:"Author,Article").MaptoViewModel();            
        //}


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
