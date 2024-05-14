using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Driver
{
    public class Subscription
    {
        [Key]
        public int SubscriptionID { get; set; } // Primary Key

        public string Type { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
