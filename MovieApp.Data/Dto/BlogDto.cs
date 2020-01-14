using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Dto
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CommendId{ get; set; }
        public string Tags { get; set; }
        
        public bool Status { get; set; }
        public DateTime CreateTime { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime UpdateTime { get; set; }

        //public List<Comment> Comments { get; set; }
    }
}
