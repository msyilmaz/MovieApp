using MovieApp.Core.Data.Entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Entity
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Status { get; set; }
        public int RoleId { get; set; }

    }
}
