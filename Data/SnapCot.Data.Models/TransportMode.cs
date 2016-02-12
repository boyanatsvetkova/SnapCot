namespace SnapCot.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TransportMode 
    {
        private ICollection<Order> orders;

        public TransportMode()
        {
            this.orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 20)]
        public string Mode { get; set; }

        public virtual ICollection<Order> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }
    }
}
