using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogDal blogDal { get; }
        ICastDal castDal { get; }
        ICommentDal commentDal { get; }
        IUserDal userDal { get; }

        int SaveChanges();
    }
}
