namespace SnapCot.Web.ViewModels.ProducerViewModels
{
    using System;
    using AutoMapper;
    using SnapCot.Data.Models;
    using SnapCot.Web.Infrastructure.Mapping;

    public class ProducerViewModel : IMapFrom<Producer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public string Country { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Producer, ProducerViewModel>()
                .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Country.Name));
        }
    }
}