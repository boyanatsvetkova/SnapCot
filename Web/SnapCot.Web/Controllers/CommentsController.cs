namespace SnapCot.Web.Controllers
{
    using Services.Contracts;
    using Infrastructure.Mapping;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.CommentsViewModels;
    using Data.Models;
    using Microsoft.AspNet.Identity;

    public class CommentsController : Controller
    {
        private ICommentService comments;

        public CommentsController(ICommentService comments)
        {
            this.comments = comments;
        }

        public ActionResult All(int page = 1)
        {
            var model = this.GetComments(page);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newComment = new Comment
                {
                    Content = model.Content,
                    CreatedOn = DateTime.UtcNow,
                    AuthorId = this.User.Identity.GetUserId()
                };

                this.comments.Add(newComment);
             
            }

            return this.PartialView("_AllCommentsPartialView", this.GetComments());
        }

        private PageableCommentViewModel GetComments(int page = 1)
        {
            var allItemsCount = this.comments.All().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / 5M);
            var comments = this.comments
                .All(page)
                .To<CommentViewModel>()
                .ToList();

            var viewModel = new PageableCommentViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Comments = comments
            };

            return viewModel;
        }
    }
}