using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LegacyOrderPortal.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
