using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Abstract;
using MovieApp.Data.ViewModel;

namespace MovieApp.MvcUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var userId = 1;
            var viewModel = new CommentsViewModel();

            viewModel.Comments = _commentService.GetComments(p => p.UserId == userId);

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CommentViewModel viewModel)
        {
            _commentService.Add(viewModel.Comment);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var viewModel = new CommentViewModel();

            viewModel.Comment = _commentService.GetComment(p => p.Id == id);

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var viewModel = new CommentViewModel();

            viewModel.Comment = _commentService.GetComment(p => p.Id == id);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CommentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _commentService.UpdateComment(viewModel.Comment);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }


            _commentService.DeleteComment(id);

            return RedirectToAction("Index");
        }
    }
}