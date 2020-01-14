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
            var viewModel = new CommentViewModel();
            viewModel.Comment = _commentService.GetCommentByUserName("Sefa");
            return View(viewModel);
        }
    }
}