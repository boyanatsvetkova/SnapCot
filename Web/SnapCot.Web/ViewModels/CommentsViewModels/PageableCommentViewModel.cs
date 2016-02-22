namespace SnapCot.Web.ViewModels.CommentsViewModels
{
    using System.Collections.Generic;

    public class PageableCommentViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}