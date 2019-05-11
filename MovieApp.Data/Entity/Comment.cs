using MovieApp.Core.Data.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Data.Entity
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }
        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}

