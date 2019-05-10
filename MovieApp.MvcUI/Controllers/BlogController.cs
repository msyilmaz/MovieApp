using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Abstract;
using MovieApp.Data.ViewModel;

namespace MovieApp.MvcUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            var viewModel = new BlogsViewModel();
            viewModel.Blog = _blogService.GetAllBlog();

            return View(viewModel);

        }

        public IActionResult Detail(int id)
        {
            var viewModel = new BlogViewModel();
            viewModel.Blog = _blogService.GetBlog(p => p.Id == id);
            return View(viewModel);

        }

        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(BlogViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _blogService.AddBlog(viewModel.Blog);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var viewModel = new BlogViewModel();
            viewModel.Blog = _blogService.GetBlog(p => p.Id == id);

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(BlogViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Blog.UserId = 1;
                viewModel.Blog.Status = true;
                _blogService.UpdateBlog(viewModel.Blog);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id==0)
            {
                return NotFound();
            }
            _blogService.DeleteBlog(id);
            return RedirectToAction("Index");
        }


    }
}