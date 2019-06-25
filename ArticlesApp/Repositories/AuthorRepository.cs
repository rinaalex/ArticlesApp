using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ArticlesApp.Interfaces;
using ArticlesApp.Model;
using ArticlesApp.ViewModels;
using ArticlesApp.ViewModels.QueryObjects;

namespace ArticlesApp.Repositories
{
    public class AuthorRepository: Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ArticlesContext context)
            :base(context)
        {            
        }

        public AuthorViewModel GetAuthorViewModel(int id)
        {
            Author author = this.Get(id);
            if(author!=null)
            {
                ArticlesContext.Entry(author).Collection(a => a.Articles).Load();
                ArticlesContext.Entry(author).Collection(a => a.Articles).Query().Select(q => q.Reviews).Load();
                return author.MapToViewModel();
            }
            return null;
        }

        public IEnumerable<AuthorViewModel> GetAuthorsViewModels()
        {
            return ArticlesContext.Authors.Include(p=>p.Articles).ThenInclude(q=>q.Reviews).MapToViewModel();
        }

        // добавить сортировку и фильтрацию
        public Author GetAuthorWithArticles(int id)
        {
            return ArticlesContext.Authors.Include(p => p.Articles).SingleOrDefault(p => p.Id == id);
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
