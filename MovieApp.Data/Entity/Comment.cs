using MovieApp.Core.Data.Entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Entity
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Comments { get; set; }
        public DateTime CommentTime { get; set; }
    }
}
