using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ArticlesApp.Interfaces;
using ArticlesApp.Model;

namespace ArticlesApp.Repositories
{
    public class AuthorRepository: Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ArticlesContext context)
            :base(context)
        {            
        }

        public Author GetAuthorWithArticles(int id)
        {
            return ArticlesContext.Authors.Include(p => p.Articles).SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Author>GetTopAuthors()
        {
            // добавить формирование рейтинга
            return ArticlesContext.Authors.ToList();
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
