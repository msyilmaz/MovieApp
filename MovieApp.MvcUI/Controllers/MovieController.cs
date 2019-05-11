using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Abstract;
using MovieApp.Data.Entity;
using MovieApp.Data.ViewModel;

namespace MovieApp.MvcUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var viewModel = new MoviesViewModel();
            viewModel.Movies = _movieService.GetAllMovie();
            return View(viewModel);
        }
        public IActionResult Detail(int id)
        {
            var viewModel = new MovieViewModel();
            viewModel.Movie = _movieService.GetMovie(x => x.Id == id);

            return View(viewModel);
           
        }
    }

}