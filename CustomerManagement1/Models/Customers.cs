using System.ComponentModel.DataAnnotations;

namespace CustomerManagement1.Models
{
    public class Customers
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string product { get; set; }
       
        public int price { get; set; }
      


    }
}
