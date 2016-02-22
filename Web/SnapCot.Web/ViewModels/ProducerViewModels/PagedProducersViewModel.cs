namespace SnapCot.Web.ViewModels.ProducerViewModels
{
    using System.Collections.Generic;

    public class PagedProducersViewModel
    {
        public IEnumerable<ProducerViewModel> Producers { get; set; }

        public int PageCount { get; set; }

        public int PageNumber { get; set; }

        public string Order { get; set; }
    }
}