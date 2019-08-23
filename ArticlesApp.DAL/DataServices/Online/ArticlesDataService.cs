using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using ArticlesApp.DAL.DataObjects;

namespace ArticlesApp.DAL.DataServices.Online
{
    public class ArticlesDataService
    {
        private readonly IArticlesDataService _articlesDataService;

        public ArticlesDataService(string token=""):base()
        {
            _articlesDataService = RestService.For<IArticlesDataService>(Constants.BaseAddress, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(token)
            });
        }

        public async Task<List<ArticleObject>>GetArticlesList()
        {
            try
            {
                return await _articlesDataService.GetArticlesList();
            }
            catch(ApiException ex)
            {
                return null;
            }            
        }

        public async Task<ArticleObject>GetArticle(int articleId)
        {
            try
            {
                return await _articlesDataService.GetArticle(articleId);
            }
            catch(ApiException ex)
            {
                return null;
            }
        }

        public async Task<List<ArticleObject>>GetArticlesByAuthor(int authorId)
        {
            try
            {
                return await _articlesDataService.GetArticlesByAuthor(authorId);
            }
            catch(ApiException ex)
            {
                return null;
            }
        }

        public async Task<ArticleObject>CreateArticle(ArticleObject article)
        {
            try
            {
                return await _articlesDataService.CreateArticle(article);
            }
            catch(ApiException ex)
            {
                return null;
            }
        }

        public async Task<ArticleObject>UpdateArticle(ArticleObject article)
        {
            try
            {
                return await _articlesDataService.UpdateArticle(article);
            }
            catch(ApiException ex)
            {
                return null;
            }
        }

        public async Task RemoveArticle(int articleId)
        {
            try
            {
                await _articlesDataService.RemoveArticle(articleId);
            }
            catch(ApiException ex)
            {
                return;
            }
        }
    }
}
