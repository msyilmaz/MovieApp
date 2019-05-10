using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Data.EntityFramework;
using MovieApp.Data.Abstract;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Concrete.EntityFramework
{
    public class efBlogDal : efRepositoryBase<Blog>, IBlogDal
    {
        public efBlogDal(DbContext dbContext) : base (dbContext)
        {

        }
    }
}
