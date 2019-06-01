using System.Collections.Generic;
using ArticlesApp.Model;

namespace ArticlesApp.Interfaces
{
    public interface IAuthorRepository: IRepository<Author>
    {
        Author GetAuthorWithArticles(int id);
        IEnumerable<Author> GetTopAuthors();        
    }
}
