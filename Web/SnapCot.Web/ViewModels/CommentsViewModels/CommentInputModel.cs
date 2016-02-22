namespace SnapCot.Web.ViewModels.CommentsViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CommentInputModel
    {
        [Required]
        [AllowHtml]
        [StringLength(1000, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}