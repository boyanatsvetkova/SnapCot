namespace SnapCot.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        private ICollection<Industry> industries;
        private ICollection<ProductCartItem> productCartItems;

        public Product()
        {
            this.industries = new HashSet<Industry>();
            this.productCartItems = new HashSet<ProductCartItem>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public Image Picture { get; set; }

        public ProductType ProductType { get; set; }

        public DateTime DateAdded { get; set; }

        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        public int HazardClassificationId { get; set; }

        public virtual HazardClassification HazardClassifiction { get; set; }

        public virtual ICollection<Industry> Industries
        {
            get { return this.industries; }
            set { this.industries = value; }
        }

        public virtual ICollection<ProductCartItem> ProductCartItems
        {
            get { return this.productCartItems; }
            set { this.productCartItems = value; }
        }
    }
}
