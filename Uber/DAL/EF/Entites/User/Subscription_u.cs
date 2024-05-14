using DAL.EF.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Entites.User
{
    public class Subscription_u
    {
        [Key]
        public int SubscriptionID { get; set; } // Primary Key

        public string Type { get; set; }

        public int Duration { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpiryDate { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; } // Foreign Key to User.UserID

        // Navigation property
        public virtual UserEF User { get; set; }
    }
}