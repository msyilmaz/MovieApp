using MovieApp.Data.Dto;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Abstract
{
    public interface ICommentService
    {
        CommentDto GetCommentByUserName(string UserName);

    }
}
