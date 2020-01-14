using MovieApp.Business.Abstract;
using MovieApp.Core.Data;
using MovieApp.Core.Data.EntityFramework;
using MovieApp.Data.Abstract;
using MovieApp.Data.Dto;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieApp.Business.Concrete
{

    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public CommentDto GetCommentByUserName(string UserName)
        {
            var comment =  _commentDal.Get(p => p.UserId == UserName);
            var result = new CommentDto()
            {
                Comment = comment.Comments,
                UserName = comment.UserId
            };

            return result;

        }
    }
}
