using MovieApp.Core.Data.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Data.Entity
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
      //  [ForeignKey("Casts")]
        public string Cast { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
       // public virtual ICollection<Casts> Cast { get; set; }
    }
}