namespace SnapCot.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductCartItem 
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public decimal Quantity { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int? ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
