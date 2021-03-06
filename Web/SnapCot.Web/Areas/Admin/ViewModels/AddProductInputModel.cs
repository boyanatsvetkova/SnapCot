﻿namespace SnapCot.Web.Areas.Admin.ViewModels
{
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    public class AddProductInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(1000, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity should be a positive number")]
        [Range(0.01, double.MaxValue)]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Product type is required")]
        [Display(Name = "Type")]
        public ProductType? ProductType { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }

        [Display(Name = "Producer")]
        [Required(ErrorMessage = "Producer is required")]
        public string ProducerId { get; set; }

        public IEnumerable<SelectListItem> Producers { get; set; }

        [Required(ErrorMessage = "Hazard Class is required")]
        [Display(Name = "Hazard")]
        public string HazardClassificationId { get; set; }

        public IEnumerable<SelectListItem> HazardClassifications { get; set; }

        public IList<IndustryInputViewModel> Industries { get; set; }
    }
}