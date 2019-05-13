using MovieApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Concrete.EntityFramework
{
    public class efUnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _dbContext;
        public efUnitOfWork(MovieDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext boş");
        }

        private IBlogDal _blogDal;
        private ICastDal _castDal;
        private ICommentDal _commentDal;
        private IUserDal _userDal;
        public IBlogDal blogDal {
            get
            {
                return _blogDal ?? (_blogDal = new efBlogDal(_dbContext));
            }
        }

        public ICastDal castDal {
            get
            {
                return _castDal ?? (_castDal = new efCastDal(_dbContext));
            }
        }

        public ICommentDal commentDal {
            get
            {
                return _commentDal ?? (_commentDal = new efCommentDal(_dbContext));
            }
        }

        public IUserDal userDal {
            get
            {
                return _userDal ?? (_userDal = new efUserDal(_dbContext));
            }
        }
        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }


    }
}
