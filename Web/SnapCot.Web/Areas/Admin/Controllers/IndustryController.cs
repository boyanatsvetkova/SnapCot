namespace SnapCot.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using SnapCot.Data.Models;
    using Services.Contracts;
    using Web.ViewModels.CommonViewModels;
    using Infrastructure.Mapping;
    using ViewModels;

    public class IndustryController : Controller
    {
        private IIndustryService industries;

        public IndustryController(IIndustryService industries)
        {
            this.industries = industries;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Industries_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.industries
                .All()
                .To<IndustryViewModel>()
                .ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Industries_Create([DataSourceRequest]DataSourceRequest request, IndustryInputModel industry)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                var entity = new Industry
                {
                    Name = industry.Name
                };

                id = this.industries.Add(entity);
            }

            var industryToDisplay = this.industries
                .All()
                .Where(x => x.Id == id)
                .To<IndustryViewModel>()
                .FirstOrDefault();
            return Json(new[] { industryToDisplay }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Industries_Update([DataSourceRequest]DataSourceRequest request, IndustryInputModel industry)
        {
            if (ModelState.IsValid)
            {
                var industryToUpdate = this.industries.GetById(industry.Id);
                this.industries.Update(industryToUpdate, industry.Name);
            }

            var industryToDisplay = this.industries
                           .All()
                           .Where(x => x.Id == industry.Id)
                           .To<IndustryViewModel>()
                           .FirstOrDefault();

            return Json(new[] { industryToDisplay }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            this.industries.Dispose();
            base.Dispose(disposing);
        }
    }
}
