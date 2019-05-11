using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Cast { get; set; }
        public string Type { get; set; }

    }
}
