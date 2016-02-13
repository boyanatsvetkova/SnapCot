namespace SnapCot.Web.ViewModels.ProductViewModels
{
    using System;
    using AutoMapper;
    using Data.Models;
    using SnapCot.Web.Infrastructure.Mapping;
    using Paging;

    public class AllProductsViewModel : IMapFrom<Product>, IHaveCustomMappings
    { 
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? ImageId { get; set; }

        public string Type { get; set; }

        public string Classification { get; set; }

        public string Producer { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Product, AllProductsViewModel>()
                .ForMember(p => p.Type, opt => opt.MapFrom(p => p.ProductType.ToString()))
                .ForMember(p => p.Classification, opt => opt.MapFrom(p => p.HazardClassifiction.Class))
                .ForMember(p => p.Producer, opt => opt.MapFrom(p => p.Producer.Name));
        }
    }
}