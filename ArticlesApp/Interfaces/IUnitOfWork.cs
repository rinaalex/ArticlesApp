using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlesApp.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IAuthorRepository Authors { get; }
        IArticleRepository Articles { get; }
        IReviewRepository Reviews { get; }
        int Complete();
    }
}
