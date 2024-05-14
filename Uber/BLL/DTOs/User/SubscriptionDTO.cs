using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.User
{
  
    public class SubscriptionDTO
    {
        public int SubscriptionID { get; set; } // Primary Key

        public string Type { get; set; }

        public int Duration { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int UserID { get; set; } // Foreign Key to User.UserID

        // You can include additional properties or navigation properties as needed
    }
}