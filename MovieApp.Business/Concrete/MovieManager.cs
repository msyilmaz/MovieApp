using MovieApp.Business.Abstract;
using MovieApp.Data.Abstract;
using MovieApp.Data.Dto;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieApp.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieDal _movieDal;
        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public List<MovieDto> GetAllMovie(Expression<Func<Movie, bool>> condition)
        {
            var movies = _movieDal.GetList(condition);

            var result = new List<MovieDto>();
            foreach (var item in movies)
            {
                var movieDto = new MovieDto()
                {
                    Cast = item.Cast,
                    Director=item.Director,
                    Id=item.Id,
                    Name=item.Name,
                    ReleaseDate=item.ReleaseDate,
                    Score=item.Score,
                    Type=item.Type
                };
                result.Add(movieDto);
            }
            
            return result;
        }

        public MovieDto GetMovie(Expression<Func<Movie, bool>> condition)
        {
            var movie = _movieDal.Get(condition);
            var result = new MovieDto()
            {
                Cast = movie.Cast,
                Id = movie.Id,
                Director = movie.Director,
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                Score = movie.Score,
                Type = movie.Type
            };
            return result;
        }
    }

}
