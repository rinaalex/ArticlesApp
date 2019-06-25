using System.Collections.Generic;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;

namespace ArticlesApp.Interfaces
{
    public interface IAuthorRepository: IRepository<Author>
    {
        Author GetAuthorWithArticles(int id);
        AuthorViewModel GetAuthorViewModel(int id);
        IEnumerable<AuthorViewModel> GetAuthorsViewModels();
    }
}
