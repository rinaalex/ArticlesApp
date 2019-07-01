using System;

namespace ArticlesApp.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        int Complete();
    }
}
