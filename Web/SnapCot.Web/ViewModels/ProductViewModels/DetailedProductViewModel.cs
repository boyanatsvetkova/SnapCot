﻿namespace SnapCot.Web.ViewModels.ProductViewModels
{
    using SnapCot.Data.Models;
    using SnapCot.Web.Infrastructure.Mapping;
    using CommonViewModels;
    using System.Collections.Generic;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using ForumSystem.Web.Infrastructure;

    public class DetailedProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        ISanitizer sanitizer;
        public DetailedProductViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string SanitizedContent
        {
            get { return this.sanitizer.Sanitize(this.Description); }
        }

        [UIHint("String")]
        public string Quantity { get; set; }

        //public decimal QuantityToBuy { get; set; }

        public decimal Price { get; set; }

        public int? ImageId { get; set; }

        public string Type { get; set; }

        public string Classification { get; set; }

        public string Producer { get; set; }

        public IEnumerable<IndustryViewModel> Industry { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Product, DetailedProductViewModel>()
                .ForMember(p => p.Type, opt => opt.MapFrom(p => p.ProductType.ToString()))
                .ForMember(p => p.Classification, opt => opt.MapFrom(p => p.HazardClassifiction.Class))
                .ForMember(p => p.Industry, opt => opt.MapFrom(p => p.Industries))
                .ForMember(p => p.Producer, opt => opt.MapFrom(p => p.Producer.Name));
        }
    }
}