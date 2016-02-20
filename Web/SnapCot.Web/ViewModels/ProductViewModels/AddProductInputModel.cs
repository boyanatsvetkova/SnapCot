namespace SnapCot.Web.ViewModels.ProductViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddProductInputModel
    {
        public int Id { get; set; }

        //[Required]
        [UIHint("Decimal")]
        [Range(0.0, Double.MaxValue)]
        public decimal QuantityToOrder { get; set; }
    }
}