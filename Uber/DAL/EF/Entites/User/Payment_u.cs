using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.EF.Entities.User; // Import the namespace containing the User entity

namespace DAL.EF.Entities.User
{
    public class Payment_u
    {
        [Key]
        public int PaymentID { get; set; } // Primary Key

        public string PaymentMethod { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime Timestamp { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; } // Foreign key property

        public virtual UserEF User { get; set; } // Navigation property
    }
}
