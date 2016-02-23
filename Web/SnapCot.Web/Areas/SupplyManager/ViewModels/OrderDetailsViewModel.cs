namespace SnapCot.Web.Areas.SupplyManager.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;

    public class OrderDetailsViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ReceivedDate { get; set; }

        public string IsApproved { get; set; }

        public string IsActive { get; set; }

        public string ShippingTerms { get; set; }

        public string TransportMode { get; set; }

        public string User { get; set; }

        public string CreditLimit { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Order, OrderDetailsViewModel>()
               .ForMember(x => x.User, opt => opt.MapFrom(x => x.User.Email))
               .ForMember(x => x.CreditLimit, opt => opt.MapFrom(x => x.User.CreditLimit.ToString()))
               .ForMember(x => x.ShippingTerms, opt => opt.MapFrom(x => x.ShippingTerms.ToString()))
               .ForMember(x => x.IsApproved, opt => opt.MapFrom(x => x.IsApproved ? "Yes" : "No"))
               .ForMember(x => x.IsActive, opt => opt.MapFrom(x => x.IsActive ? "Pending" : "Done"))
               .ForMember(x => x.TransportMode, opt => opt.MapFrom(x => x.TransportMode.Mode));
        }
    }
}