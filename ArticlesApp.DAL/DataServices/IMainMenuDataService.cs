using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArticlesApp.DAL.DataObjects;
using Refit;

namespace ArticlesApp.DAL.DataServices
{
    
    public interface IMainMenuDataService
    {        
        [Get("/articles")]
        [Headers("Authorization: Bearer")]
        Task<List<ArticleObject>> GetArticlesList();
    }
}
