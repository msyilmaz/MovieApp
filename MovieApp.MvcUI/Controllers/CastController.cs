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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CastViewModel viewModel)
        {
            _castService.Add(viewModel.cast);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            _castService.Delete(Id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int Id)
        {
            var viewModel = new CastViewModel();
            viewModel.cast = _castService.GetCast(p => p.Id == Id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CastViewModel viewModel)
        {
            _castService.Update(viewModel.cast);
            return RedirectToAction("Index");
        }

    }
}