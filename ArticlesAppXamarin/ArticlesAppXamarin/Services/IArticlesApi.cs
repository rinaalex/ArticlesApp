using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using ArticlesAppXamarin.Models;

namespace ArticlesAppXamarin.Services
{
    public interface IArticlesApi
    {
        [Get("/api/articles/")]
        Task<List<ArticleModel>> GetArticles();
    }
}
