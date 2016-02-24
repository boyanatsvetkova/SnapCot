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
    using ForumSystem.Web.Infrastructure;
    using Common;
    using CrossJob.Controls.Notifier;

    public class CommentsController : Controller
    {
        private ICommentService comments;
        private ISanitizer sanitizer;

        public CommentsController(ICommentService comments, ISanitizer sanitizer)
        {
            this.comments = comments;
            this.sanitizer = sanitizer;
        }

        public ActionResult All(int page = GlobalConstants.DefaultPage)
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
                    Content = this.sanitizer.Sanitize(model.Content),
                    CreatedOn = DateTime.UtcNow,
                    AuthorId = this.User.Identity.GetUserId()
                };

                this.comments.Add(newComment);             
            }

            return this.PartialView("_AllCommentsPartialView", this.GetComments());
        }

        public ActionResult DeleteComment(int id)
        {
            var comment = this.comments.GetCommentById(id);
            if (comment != null)
            {
                this.comments.DeleteComment(comment);
                this.TempData["Notification"] = "Comment deleted successfully!";
                //Notifier.Success("Comment deleted successfully!");
            }

            return RedirectToAction("All");
        }

        private PageableCommentViewModel GetComments(int page = GlobalConstants.DefaultPage)
        {
            var allItemsCount = this.comments.All().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)GlobalConstants.CommentsPerPage);
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