using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Abstract;
using MovieApp.Data.ViewModel;

namespace MovieApp.MvcUI.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;
        public CastController(ICastService castService)
        {
            _castService = castService;
        }
        public IActionResult Index()
        {
            var Id = 1;
            var viewModel = new CastsViewModel();
            viewModel.Casts = _castService.GetCasts(p => p.Id == Id);
            return View(viewModel);
        }
    }
}