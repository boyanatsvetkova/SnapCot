namespace SnapCot.Web.ViewModels.CommentsViewModels
{
    using SnapCot.Data.Models;
    using SnapCot.Web.Infrastructure.Mapping;
    using System;
    using AutoMapper;
    using ForumSystem.Web.Infrastructure;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        ISanitizer sanitizer;
        public CommentViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public string SanitizedContent
        {
            get { return this.sanitizer.Sanitize(this.Content); }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.Name));
        }
    }
}