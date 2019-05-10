using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Data.EntityFramework;
using MovieApp.Data.Abstract;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Concrete.EntityFramework
{
    public class efCommentDal : efRepositoryBase<Comment> , ICommentDal
    {
        public efCommentDal(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
