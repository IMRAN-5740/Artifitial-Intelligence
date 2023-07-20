using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtifitialIntelligence.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public int Id { get; set; }
        [Display(Name = "Order Number")]
        public string OrderNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        [DisplayName("Total Amount")]
        public double? TotalOrderAmount { get; set; }
      
        [DisplayName("Transaction ID")]
        public string TransactionID { get; set; }
       
        [DisplayName("Online Order ID")]
        public string OrderProcessID { get;set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
