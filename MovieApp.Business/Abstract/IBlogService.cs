using MovieApp.Data.Dto;
using MovieApp.Data.Entity;
using MovieApp.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieApp.Business.Abstract
{
    public interface IBlogService
    {
        BlogDto GetBlog(Expression<Func<Blog,bool>> condition);
        List<BlogDto> GetAllBlog(Expression<Func<Blog,bool>> condition=null);
        void AddBlog(BlogDto blog);
        void UpdateBlog(BlogDto blog);
        void DeleteBlog(int id);
    }
}
