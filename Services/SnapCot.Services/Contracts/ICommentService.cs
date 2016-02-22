namespace SnapCot.Services.Contracts
{
    using SnapCot.Data.Models;
    using System.Linq;

    public interface ICommentService
    {
        IQueryable<Comment> All();

        IQueryable<Comment> All(int page);

        void Add(Comment comment);

        Comment GetCommentById(int id);

        void DeleteComment(Comment comment);
    }
}
