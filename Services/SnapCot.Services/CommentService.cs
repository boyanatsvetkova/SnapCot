namespace SnapCot.Services
{
    using Data.Models;
    using Data.Repositories;
    using SnapCot.Services.Contracts;
    using System.Linq;
    using System;
    using Common;

    public class CommentService : ICommentService
    {
        private IRepository<Comment> comments;

        public CommentService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void Add(Comment comment)
        {
            this.comments.Add(comment);
            this.comments.SaveChanges();
        }

        public IQueryable<Comment> All()
        {
            return this.comments.All();
        }

        public IQueryable<Comment> All(int page)
        {
            return this.comments
               .All()
               .OrderByDescending(c => c.CreatedOn)
               .Skip((page - 1) * GlobalConstants.CommentsPerPage)
               .Take(GlobalConstants.CommentsPerPage);
        }

        public void DeleteComment(Comment comment)
        {
            this.comments.Delete(comment);
            this.comments.SaveChanges();
        }

        public Comment GetCommentById(int id)
        {
            return this.comments.GetById(id);
        }
    }
}
