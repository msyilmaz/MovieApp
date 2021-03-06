﻿using MovieApp.Core.Data.Entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Entity
{
    public class Cast : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
