using MovieApp.Data.Dto;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieApp.Business.Abstract
{
    public interface IMovieService
    {
        MovieDto GetMovie(Expression<Func<Movie, bool>> condition);
        List<MovieDto> GetAllMovie(Expression<Func<Movie, bool>> condition = null);
    }
}
