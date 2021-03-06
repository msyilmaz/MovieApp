﻿using MovieApp.Business.Abstract;
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
        private readonly IUnitOfWork _unitOfWork;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(CommentDto commentDto)
        {
            var comment = new Comment()
            {
                UserId = commentDto.UserId,
                Content = commentDto.Content,
                BlogId = commentDto.BlogId,
                CommentTime = DateTime.Now
            };

            _unitOfWork.GetRepository<Comment>().Add(comment);
            _unitOfWork.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = _unitOfWork.GetRepository<Comment>().Get(p => p.Id == id);
            _unitOfWork.GetRepository<Comment>().Delete(comment);
            _unitOfWork.SaveChanges();
        }

        public CommentDto GetComment(Expression<Func<Comment, bool>> condition)
        {
            var comment = _unitOfWork.GetRepository<Comment>().Get(condition);
            var result = new CommentDto()
            {
                BlogId = comment.BlogId,
                Content = comment.Content,
                UserId = comment.UserId,
                Id = comment.Id,
                CommentTime = comment.CommentTime
            };

            return result;
        }

        public CommentDto GetCommentByUserId(int UserId)
        {
            var comment = _unitOfWork.GetRepository<Comment>().Get(p => p.UserId == UserId);
            var result = new CommentDto()
            {
                UserId = comment.UserId,
                Content = comment.Content
            };
            return result;
        }

        public List<CommentDto> GetComments(Expression<Func<Comment, bool>> condition)
        {
            var comments = _unitOfWork.GetRepository<Comment>().GetList(condition);
            var result = new List<CommentDto>();

            foreach (var item in comments)
            {
                var commentDto = new CommentDto()
                {
                    Id = item.Id,
                    BlogId = item.BlogId,
                    Content = item.Content,
                    UserId = item.UserId

                };
                result.Add(commentDto);
            }
            return result;
        }

        public void UpdateComment(CommentDto comment)
        {
            var entity = new Comment()
            {
                Id = comment.Id,
                CommentTime = DateTime.Now,
                Content = comment.Content,
                BlogId = comment.BlogId,
                UserId = comment.UserId
            };
            _unitOfWork.GetRepository<Comment>().Update(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
