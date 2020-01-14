using MovieApp.Core.Data.Entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Entity
{
    public class Blog : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CommendId { get; set; }
        public virtual List<Comment>  Comments { get; set; }
        public string Tags { get; set; }
        public bool Status { get; set; }
        public DateTime CreateTime { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
