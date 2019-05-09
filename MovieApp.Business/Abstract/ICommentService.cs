using MovieApp.Data.Dto;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieApp.Business.Abstract
{
    public interface ICommentService
    {
        CommentDto GetComment(Expression<Func<Comment, bool>> condition);
        CommentDto GetCommentByUserId(int UserId);
        void Add(CommentDto commentDto);
        List<CommentDto> GetComments(Expression<Func<Comment, bool>> condition);
        void UpdateComment(CommentDto comment);
        void DeleteComment(int id);




    }
}
