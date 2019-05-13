using MovieApp.Business.Abstract;
using MovieApp.Data.Abstract;
using MovieApp.Data.Dto;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieApp.Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void AddBlog(BlogDto blogDto)
        {
            var blog = new Blog()
            {
                UserId = blogDto.UserId,
                Title = blogDto.Title,
                Content = blogDto.Content,
                Tags = blogDto.Tags,
                CreateTime = DateTime.Now,
                Status = true
            };
            _blogDal.Add(blog);
            _blogDal.Save();
        }

        public void DeleteBlog(int id)
        {
            var entity = _blogDal.Get(p => p.Id == id);
            _blogDal.Delete(entity);
            _blogDal.Save();
        }

        public List<BlogDto> GetAllBlog(Expression<Func<Blog, bool>> condition = null)
        {
            var blogList = new List<BlogDto>();
            var blogs = _blogDal.GetList(condition);

            foreach (var item in blogs)
            {
                var blog = new BlogDto()
                {
                    CommendId = item.CommendId,
                    Content = item.Content,
                    CreateTime = item.CreateTime,
                    Id = item.Id,
                    Status = item.Status,
                    Tags = item.Tags,
                    Title = item.Title,
                    UpdateTime = item.UpdateTime,
                    UserId = item.UserId
                };

                blogList.Add(blog);
            }

            return blogList;
        }

        public BlogDto GetBlog(Expression<Func<Blog, bool>> condition)
        {
            var blog = _blogDal.Get(condition);
            var result = new BlogDto()
            {
                CommendId = blog.CommendId,
                Content = blog.Content,
                CreateTime = blog.CreateTime,
                Id = blog.Id,
                Status = blog.Status,
                Tags = blog.Tags,
                Title = blog.Title,
                UpdateTime = blog.UpdateTime,
                UserId = blog.UserId
            };
            return result;
        }

        public void UpdateBlog(BlogDto blogDto)
        {
            var blog = new Blog()
            {
                Id = blogDto.Id,
                Title=blogDto.Title,
                Content=blogDto.Content,
                Tags=blogDto.Tags,
                UpdateTime=blogDto.UpdateTime,
                UserId = blogDto.UserId,
                Status = blogDto.Status

            };
            _blogDal.Update(blog);
            _blogDal.Save();

        }
    }
}
